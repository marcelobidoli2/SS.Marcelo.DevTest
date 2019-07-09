using FluentValidator;
using FluentValidator.Validation;
using SS.Marcelo.DevTest.Domain.Alterations.Enums;
using System;

namespace SS.Marcelo.DevTest.Domain.Alterations.Entities
{
	public class Alteration : Notifiable
	{
		private readonly double MAXALTERATIONSIZE = 5;
		private readonly double MINALTERATIONSIZE = -5;

		public Alteration(Customer customer, EAlterationSide side, double size, EAlterationType type)
		{
			this.Id = Guid.NewGuid();
			this.Customer = customer;
			this.Side = side;
			this.Size = size;
			this.Type = type;
			this.Status = EAlterationStatus.New;

			this.Validate();
		}

		public Guid Id { get; }
		public Customer Customer { get; }
		public EAlterationSide Side { get; }
		public double Size { get; }
		public EAlterationType Type { get; }
		public EAlterationStatus Status { get; private set; }

		public void ChangeStatus(EAlterationStatus alterationStatus)
		{
			if ((int)alterationStatus > (int)this.Status)
				this.Status = alterationStatus;
		}

		private bool InvlaidSize => MINALTERATIONSIZE < Size && Size < MAXALTERATIONSIZE;

		private void Validate()
		{
			AddNotifications(new ValidationContract()
				.IsTrue(InvlaidSize, nameof(Size), $"Alteration Size must be grater then {MINALTERATIONSIZE} and lower then {MAXALTERATIONSIZE}")
			);
		}
	}
}
