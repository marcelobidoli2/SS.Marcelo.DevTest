using SS.Marcelo.DevTest.Domain.Alterations.Commands;
using Xunit;

namespace SS.Marcelo.DevTest.Tests
{
	public class CreateAlterationsOrderCommandTest
	{
		private CreateAlterationsOrderCommand InvalidCommand { get; set; }

		public CreateAlterationsOrderCommandTest()
		{
			InvalidCommand = new CreateAlterationsOrderCommand
			{
				CustomerName = "",
				CustomerEmail = "NotAnEmail",
				AlterationSize = 0
			};
		}

		[Fact]
		public void CreateAlterationsOrderCommandInvalidCustomerName()
		{
			Assert.False(InvalidCommand.IsValid());
			Assert.Contains(InvalidCommand.Notifications, n => n.Property == nameof(InvalidCommand.CustomerName));
		}

		[Fact]
		public void CreateAlterationsOrderCommandInvalidCustomerEmail()
		{
			Assert.False(InvalidCommand.IsValid());
			Assert.Contains(InvalidCommand.Notifications, n => n.Property == nameof(InvalidCommand.CustomerEmail));
		}

		[Fact]
		public void CreateAlterationsOrderCommandInvalidAltrationSize()
		{
			Assert.False(InvalidCommand.IsValid());
			Assert.Contains(InvalidCommand.Notifications, n => n.Property == nameof(InvalidCommand.AlterationSize));
		}
	}
}
