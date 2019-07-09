using SS.Marcelo.DevTest.Domain.Alterations.Entities;
using MediatR;

namespace SS.Marcelo.DevTest.Domain.Alterations.Handlers
{
	internal class AlterationCreated : INotification
	{
		private readonly Alteration alteration;

		public AlterationCreated(Alteration alteration)
		{
			this.alteration = alteration;
		}
	}
}