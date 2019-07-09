using SS.Marcelo.DevTest.Domain.Alterations.Entities;
using SS.Marcelo.DevTest.Domain.Alterations.Enums;
using System;
using System.Collections.Generic;

namespace SS.Marcelo.DevTest.Infra.Context
{
	public class DBContext
	{
		public DBContext()
		{
			var customer = new Customer("Marcelo Bidoli", "Marcelo@bidoli.com");
			this.Alterations = new List<Alteration>();
			this.Alterations.Add(new Alteration(customer, EAlterationSide.Left, 3.2D, EAlterationType.Sleeve));
			this.Alterations.Add(new Alteration(customer, EAlterationSide.Right, 2.2D, EAlterationType.Sleeve));
			this.Alterations.Add(new Alteration(customer, EAlterationSide.Left, 3.2D, EAlterationType.Trousers));
			this.Alterations.Add(new Alteration(customer, EAlterationSide.Right, 0.8D, EAlterationType.Trousers));
		}

		public IList<Alteration> Alterations { get; set; }
	}
}
