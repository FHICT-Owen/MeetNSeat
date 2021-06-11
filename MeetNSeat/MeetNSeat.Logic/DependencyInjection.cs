using MeetNSeat.Logic.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MeetNSeat.Logic
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLogic(this IServiceCollection services)
        {
            services.AddSingleton<IManageProblems, ProblemCollection>();
            services.AddTransient<IManageFeedback, FeedbackCollection>();
            services.AddSingleton<IManageLocation, LocationCollection>();
            services.AddSingleton<IManageRoom, Floor>();
            services.AddTransient<IManageUser, User>();
            
            // Location manages floors.
            services.AddSingleton<IManageFloor, Location>();

            return services;
        }
    }

}