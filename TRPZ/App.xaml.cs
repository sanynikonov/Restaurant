using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TRPZ.Business;
using TRPZ.Data;

namespace TRPZ
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();

            var connectionString = ConfigurationManager.ConnectionStrings["EliteRestaurantDbConnection"].ConnectionString;
            services.AddDbContext<EliteRestaurantContext>(opt =>
                opt.UseSqlServer(connectionString));

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile(new AutomapperConfig());
            });
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IDishRepository, DishRepositoryMock>();
            services.AddTransient<ICookRepository, CookRepositoryMock>();
            services.AddTransient<IDishService, DishService>();
            services.AddTransient<ICookService, CookServiceMock>();
            services.AddTransient<IOrderService, OrderServiceMock>();
            services.AddTransient<MainViewModel, MainViewModel>();

            DependencyResolver = services.BuildServiceProvider();

            

        }

        public static IServiceProvider DependencyResolver { get; private set; }
    }
}
