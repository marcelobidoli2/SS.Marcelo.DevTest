using FluentValidator;
using FluentValidator.Validation;
using MediatR;
using SS.Marcelo.DevTest.Domain.Alterations.Entities;
using SS.Marcelo.DevTest.Domain.Alterations.Enums;

namespace SS.Marcelo.DevTest.Domain.Alterations.Commands
{
	public class CreateAlterationsOrderCommand : Notifiable, IRequest<Alteration>
	{
		public EAlterationSide Side { get; set; }
		public double AlterationSize { get; set; }
		public EAlterationType AlterationType { get; set; }
		public string CustomerEmail { get; set; }
		public string CustomerName { get; set; }
		public string CustomerId { get; set; }

		public bool IsValid()
		{
			AddNotifications(new ValidationContract()
				.IsEmail(CustomerEmail, nameof(CustomerEmail), "Email must be valid")
				.HasMinLen(CustomerName, 3, nameof(CustomerName), "Name must have at lest 3 leters")
				.IsFalse(AlterationSize == 0, nameof(AlterationSize), "Alteration size must be different then 0"));

			return Valid;
		}
	}
}
