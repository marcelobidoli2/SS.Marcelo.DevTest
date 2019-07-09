using SS.Marcelo.DevTest.Domain.Alterations.Entities;
using SS.Marcelo.DevTest.Domain.Alterations.Enums;
using Xunit;

namespace SS.Marcelo.DevTest.Tests.Domain.Entities
{
	public class AlterationTest
	{
		[Fact]
		public void CreateAlterationWithInvalidSize()
		{
			var customer = new Customer("Marcelo Bidoli Fernandes", "marcelobidoli@test.com");
			var alteration = new Alteration(customer, EAlterationSide.Left, 10, EAlterationType.Sleeve);

			Assert.True(alteration.Invalid);
			Assert.Contains(alteration.Notifications, n => n.Property == nameof(alteration.Size));
		}
	}
}
