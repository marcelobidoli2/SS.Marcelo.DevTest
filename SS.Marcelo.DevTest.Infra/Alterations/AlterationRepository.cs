using System;
using System.Collections.Generic;
using System.Linq;
using SS.Marcelo.DevTest.Domain.Alterations.Contracts;
using SS.Marcelo.DevTest.Domain.Alterations.Entities;
using SS.Marcelo.DevTest.Infra.Context;

namespace SS.Marcelo.DevTest.Infra.Alterations
{
	public class AlterationRepository : IAlterationRepository
	{
		private readonly DBContext _context;
		public AlterationRepository(DBContext context)
		{
			this._context = context;
		}

		public Alteration GetById(Guid alterationId)
		{
			return _context.Alterations.FirstOrDefault(a => a.Id == alterationId);
		}

		public IEnumerable<Alteration> GetAll()
		{
			return _context.Alterations;
		}

		public bool AlterStatus(Alteration alteration)
		{
			this._context.Alterations = this._context.Alterations.Where(a => a.Id != alteration.Id).ToList();
			this._context.Alterations.Add(alteration);

			return true;
		}

		public void Create(Alteration alteration)
		{	
			this._context.Alterations.Add(alteration);
		}
	}
}
