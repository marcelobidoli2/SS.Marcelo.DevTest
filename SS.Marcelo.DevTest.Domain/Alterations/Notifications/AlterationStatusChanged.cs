using MediatR;
using SS.Marcelo.DevTest.Domain.Alterations.Entities;

namespace SS.Marcelo.DevTest.Domain.Alterations.Notifications
{
	public class AlterationStatusChanged : INotification
	{
		private readonly Alteration alteration;

		public AlterationStatusChanged(Alteration alteration)
		{
			this.alteration = alteration;
		}
	}
}
