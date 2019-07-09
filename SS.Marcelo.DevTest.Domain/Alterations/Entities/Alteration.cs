using SS.Marcelo.DevTest.Domain.Alterations.Enums;
using System;

namespace SS.Marcelo.DevTest.Domain.Alterations.Entities
{
	public class Alteration
	{
		public Alteration(Customer customer, EAlterationSide side, double size, EAlterationType type)
		{
			this.Id = Guid.NewGuid();
			this.Customer = customer;
			this.Side = side;
			this.Size = size;
			this.Type = type;
			this.Status = EAlterationStatus.New;
		}

		public Guid Id { get; }
		public Customer Customer { get; }
		public EAlterationSide Side { get; }
		public double Size { get; }
		public EAlterationType Type { get; }
		public EAlterationStatus Status { get; private set; }

		public void ChangeStatus(EAlterationStatus alterationStatus)
		{
			if((int)alterationStatus > (int)this.Status)
				this.Status = alterationStatus;
		}
	}
}
