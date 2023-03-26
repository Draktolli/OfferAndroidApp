using App1.Buisness;
using App1.Mappers;
using App1.Mappers.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace App1
{
	internal static class AppServiceProvider
	{
		public static IServiceProvider ServiceProvider { get; set; }

		public static void SetUpServices()
		{
			var services = new ServiceCollection();

			services.AddTransient<IGetOffersCommand, GetOffersCommand>();
			services.AddTransient<IOfferMapper, OfferMapper>();

			ServiceProvider = services.BuildServiceProvider();
		}
	}
}