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
		public DateTime PickupDate { get; private set; }

		public void ChangeStatus(EAlterationStatus alterationStatus)
		{
			if ((int)alterationStatus < (int)this.Status)
			{
				AddNotification(nameof(this.ChangeStatus), "Status can only go forward");
				return;
			}
			if(alterationStatus == EAlterationStatus.AwaitingPickup && this.PickupDate == DateTime.MinValue)
			{
				AddNotification(nameof(this.Status), "Please add a pickup date before changing status do awating pickup");
				return;
			}

			this.Status = alterationStatus;
		}

		public void SetPickupDate(DateTime pickupDate)
		{
			if(pickupDate <= DateTime.Now)
			{
				AddNotification(nameof(this.PickupDate), "Pickup date must be today or a later date");
				return;
			}

			this.PickupDate = pickupDate;
			this.ChangeStatus(EAlterationStatus.AwaitingPickup);
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
