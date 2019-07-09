using MediatR;
using SS.Marcelo.DevTest.Domain.Alterations.Enums;
using System;

namespace SS.Marcelo.DevTest.Domain.Alterations.Commands
{
	public class ChangeAlterationOrderStatusCommand : IRequest
	{
		public Guid	AlterationId { get; set; }
		public EAlterationStatus AlterationStatus { get; set; }
	}
}
