using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SS.Marcelo.DevTest.Domain.Alterations.Commands;
using SS.Marcelo.DevTest.Domain.Alterations.Contracts;
using SS.Marcelo.DevTest.Domain.Alterations.Entities;
using SS.Marcelo.DevTest.Infra.Alterations;
using SS.Marcelo.DevTest.Infra.Context;

namespace SS.Marcelo.DevTest.WebApi.Dependencies
{
	public static class IoC
	{
		public static void AddToIoC(this IServiceCollection services)
		{
			services.AddSingleton(new DBContext());

			services.AddScoped<IAlterationRepository, AlterationRepository>();

			//services.AddScoped<IRequestHandler<CreateAlterationCommand, Alteration>>();
			//services.AddScoped<IRequestHandler<ChangeStatusAlterationCommand>>();
		}
	}
}
