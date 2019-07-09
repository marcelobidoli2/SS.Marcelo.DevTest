using MediatR;
using SS.Marcelo.DevTest.Domain.Alterations.Entities;
using SS.Marcelo.DevTest.Domain.Alterations.Enums;

namespace SS.Marcelo.DevTest.Domain.Alterations.Commands
{
	public class CreateAlterationCommand : IRequest<Alteration>
	{
		public EAlterationSide Side { get; internal set; }
		public double AlterationSize { get; internal set; }
		public EAlterationType AlterationType { get; internal set; }
		public Customer Customer { get; set; }
		public string CustomerEmail { get; internal set; }
		public string CustomerName { get; internal set; }
		public string CustomerId { get; internal set; }
	}
}
