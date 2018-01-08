using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection
{
	public static class ServiceExtensions
	{
		public static IServiceCollection RegisterServices(
			this IServiceCollection services)
		{
			services.AddTransient<ITopicAreaService, TopicAreaService>();
			// Add all other services here.
			return services;
		}
	}
}
