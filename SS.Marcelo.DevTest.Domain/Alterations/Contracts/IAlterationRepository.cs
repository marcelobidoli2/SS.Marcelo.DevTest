using SS.Marcelo.DevTest.Domain.Alterations.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SS.Marcelo.DevTest.Domain.Alterations.Contracts
{
	public interface IAlterationRepository
	{
		Alteration GetById(Guid alterationId);
		IEnumerable<Alteration> GetAll();
		void Create(Alteration alteration);
		bool AlterStatus(Alteration alteration);
	}
}
