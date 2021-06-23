using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UserManagementSampleApp.ViewModels;

namespace UserManagementSampleApp.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider Services { get; }

        public new static App Current => (App)Application.Current;

        public App()
        {
            Services = ConfigureServices();
        }
        private IServiceProvider ConfigureServices()
        {
            ServiceCollection services = new();

            // Viewmodels
            services.AddTransient<MainViewModel>();
            services.AddTransient<UsersViewModel>();
            services.AddTransient<UserDetailsViewModel>();
            services.AddTransient<AddUserViewModel>();

            // Services
            services.AddSingleton<IUserService, UserService>();

            return services.BuildServiceProvider();
        }
    }
}
