using MediatR;
using Microsoft.AspNetCore.Mvc;
using SS.Marcelo.DevTest.Domain.Alterations.Commands;
using SS.Marcelo.DevTest.Domain.Alterations.Contracts;
using System;
using System.Threading.Tasks;

namespace SS.Marcelo.DevTest.WebApi.Controllers
{
	[Route("api/[controller]")]
	public class AlterationsController : Controller
	{
		private readonly IMediator _mediator;
		private readonly IAlterationRepository _alterationRepository;

		public AlterationsController(IMediator mediator, IAlterationRepository alterationRepository)
		{
			this._mediator = mediator;
			this._alterationRepository = alterationRepository;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var alterations = this._alterationRepository.GetAll();
			return Ok(alterations);
		}

		[HttpGet("{id}")]
		public IActionResult Get(Guid id)
		{
			if(id == Guid.Empty) { BadRequest($"{nameof(id)} must be valid"); }

			var alteration = this._alterationRepository.GetById(id);
			return Ok(alteration);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateAlterationCommand createAlterationCommand)
		{
			if(createAlterationCommand is null) { return BadRequest($"{nameof(createAlterationCommand)} must be valid"); }

			var alteration = await this._mediator.Send(createAlterationCommand);

			return Created(alteration.Id.ToString(), alteration);
		}

		[HttpPut]
		public async Task<IActionResult> AlterStatus([FromBody] ChangeAlterationOrderStatusCommand changeStatusAlterationCommand)
		{
			if(changeStatusAlterationCommand is null
				|| changeStatusAlterationCommand.AlterationId == Guid.Empty) { return BadRequest($"{nameof(changeStatusAlterationCommand)} must be valid"); }

			await this._mediator.Send(changeStatusAlterationCommand);

			return NoContent();
		}
	}
}
