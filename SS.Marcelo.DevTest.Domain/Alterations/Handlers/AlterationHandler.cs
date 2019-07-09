using FluentValidator;
using MediatR;
using SS.Marcelo.DevTest.Domain.Alterations.Commands;
using SS.Marcelo.DevTest.Domain.Alterations.Contracts;
using SS.Marcelo.DevTest.Domain.Alterations.Entities;
using SS.Marcelo.DevTest.Domain.Alterations.Enums;
using SS.Marcelo.DevTest.Domain.Alterations.Notifications;
using System.Threading;
using System.Threading.Tasks;

namespace SS.Marcelo.DevTest.Domain.Alterations.Handlers
{
	public class AlterationHandler :
		Notifiable,
		IRequestHandler<CreateAlterationsOrderCommand, Alteration>,
		IRequestHandler<ChangeAlterationOrderStatusCommand>
	{
		private readonly IAlterationRepository _alterationRepository;
		private readonly IMediator _mediator;

		public AlterationHandler(IAlterationRepository alterationRepository, IMediator mediator)
		{
			this._alterationRepository = alterationRepository;
			this._mediator = mediator;
		}

		public async Task<Alteration> Handle(CreateAlterationsOrderCommand request, CancellationToken cancellationToken)
		{
			var customer = new Customer(request.CustomerName, request.CustomerEmail);
			var alteration = new Alteration(customer, request.Side, request.AlterationSize, request.AlterationType);
			AddNotifications(alteration.Notifications);

			if (Invalid)
				return null;

			_alterationRepository.Create(alteration);

			await _mediator.Publish(new AlterationCreated(alteration));

			return alteration;
		}

		public async Task<Unit> Handle(ChangeAlterationOrderStatusCommand request, CancellationToken cancellationToken)
		{
			var alteration = _alterationRepository.GetById(request.AlterationId);

			switch (request.AlterationStatus)
			{
				case EAlterationStatus.AwaitingPickup:
					alteration.SetPickupDate(request.PickupDate.Value);
					//TODO: Create AlterationFinished to notify Customer
					await _mediator.Publish(new AlterationStatusChanged(alteration));
					break;
				case EAlterationStatus.Paied:
					alteration.ChangeStatus(request.AlterationStatus);
					//TODO: Create OrderPaid to notify Tailor
					await _mediator.Publish(new AlterationStatusChanged(alteration));
					break;
				default:
					alteration.ChangeStatus(request.AlterationStatus);
					break;
			}

			_alterationRepository.AlterStatus(alteration);

			return Unit.Value;
		}
	}
}
