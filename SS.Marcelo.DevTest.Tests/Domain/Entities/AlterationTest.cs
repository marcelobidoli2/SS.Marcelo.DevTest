using SS.Marcelo.DevTest.Domain.Alterations.Entities;
using SS.Marcelo.DevTest.Domain.Alterations.Enums;
using System;
using Xunit;

namespace SS.Marcelo.DevTest.Tests.Domain.Entities
{
	public class AlterationTest
	{
		private Alteration ValidAlteration { get; set; }

		public AlterationTest()
		{
			var customer = new Customer("Marcelo Bidoli Fernandes", "marcelobidoli@test.com");
			ValidAlteration = new Alteration(customer, EAlterationSide.Both, 3.2, EAlterationType.Sleeve);
		}

		[Fact]
		public void CreateAlterationWithInvalidSize()
		{
			var customer = new Customer("Marcelo Bidoli Fernandes", "marcelobidoli@test.com");
			var alteration = new Alteration(customer, EAlterationSide.Left, 10, EAlterationType.Sleeve);

			Assert.True(alteration.Invalid);
			Assert.Contains(alteration.Notifications, n => n.Property == nameof(alteration.Size));
		}

		[Fact]
		public void ChangeAlterationStatusWithValidStatus()
		{
			ValidAlteration.ChangeStatus(EAlterationStatus.InProgress);

			Assert.Equal(EAlterationStatus.InProgress, ValidAlteration.Status);
		}

		[Fact]
		public void ChangeAlterationStatusWithInvalidStatus()
		{
			ValidAlteration.ChangeStatus(EAlterationStatus.InProgress);
			ValidAlteration.ChangeStatus(EAlterationStatus.New);

			Assert.Equal(EAlterationStatus.InProgress, ValidAlteration.Status);
			Assert.Contains(ValidAlteration.Notifications, n => n.Property == nameof(ValidAlteration.ChangeStatus));
		}

		[Fact]
		public void SetPickupDateForAlterationShouldSetStatusToAwaitingPickup()
		{
			ValidAlteration.SetPickupDate(DateTime.Now.AddDays(1));

			Assert.Equal(EAlterationStatus.AwaitingPickup, ValidAlteration.Status);
			Assert.True(ValidAlteration.Valid);
		}

		[Fact]
		public void SetInvalidPickupDateForAlterationShouldNotChangeStatusAndHaveNotification()
		{
			ValidAlteration.SetPickupDate(DateTime.Now.AddDays(-1));

			Assert.NotEqual(EAlterationStatus.AwaitingPickup, ValidAlteration.Status);
			Assert.True(ValidAlteration.Invalid);
			Assert.Contains(ValidAlteration.Notifications, n => n.Property == nameof(ValidAlteration.PickupDate));
		}
	}
}
