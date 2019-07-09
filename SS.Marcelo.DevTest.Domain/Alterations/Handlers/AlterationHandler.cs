using MediatR;
using SS.Marcelo.DevTest.Domain.Alterations.Commands;
using SS.Marcelo.DevTest.Domain.Alterations.Contracts;
using SS.Marcelo.DevTest.Domain.Alterations.Entities;
using SS.Marcelo.DevTest.Domain.Alterations.Notifications;
using System.Threading;
using System.Threading.Tasks;

namespace SS.Marcelo.DevTest.Domain.Alterations.Handlers
{
	public class AlterationHandler :
		IRequestHandler<CreateAlterationCommand, Alteration>,
		IRequestHandler<ChangeAlterationOrderStatusCommand>
	{
		private readonly IAlterationRepository _alterationRepository;
		private readonly IMediator _mediator;

		public AlterationHandler(IAlterationRepository alterationRepository, IMediator mediator)
		{
			this._alterationRepository = alterationRepository;
			this._mediator = mediator;
		}

		public async Task<Alteration> Handle(CreateAlterationCommand request, CancellationToken cancellationToken)
		{
			var customer = new Customer(request.CustomerId, request.CustomerName, request.CustomerEmail);
			var alteration = new Alteration(customer, request.Side, request.AlterationSize, request.AlterationType);

			_alterationRepository.Create(alteration);

			await _mediator.Publish(new AlterationCreated(alteration));

			return alteration;
		}

		public async Task<Unit> Handle(ChangeAlterationOrderStatusCommand request, CancellationToken cancellationToken)
		{
			var alteration = _alterationRepository.GetById(request.AlterationId);

			alteration.ChangeStatus(request.AlterationStatus);

			_alterationRepository.AlterStatus(alteration);

			await _mediator.Publish(new AlterationStatusChanged(alteration));

			return Unit.Value;
		}
	}
}
