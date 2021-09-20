using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Services;
using WPFApp1.ViewModel;

namespace WPFApp1
{
    public static class IoC
    {
        private static readonly ServiceProvider _provider;

        static IoC()
        {
            var services = new ServiceCollection();

            _ = services.AddSingleton<MainViewModel>();
            _ = services.AddSingleton<SelectRolePageViewModel>();
            _ = services.AddTransient<LoginPageViewModel>();
            _ = services.AddSingleton<AdminPageViewModel>();
            _ = services.AddTransient<MainDataReestrViewModel>();
            _ = services.AddTransient<ObjectPageViewModel>();
            _ = services.AddTransient<AllContractsViewModel>();
            _ = services.AddTransient<UserEditoPageViewModel>();
            _ = services.AddTransient<AllUsersEditorPageViewModel>();
            _ = services.AddTransient<UpdateUserPageViewModel>();
            _ = services.AddTransient<AddNewObjektPageViewModel>();
            _ = services.AddTransient<ContractViewModel>();
            _ = services.AddTransient<AddNewConrtactViewModel>();
            _ = services.AddTransient<TenderViewModel>();
            _ = services.AddTransient<AddNewTenderViewModel>();
            _ = services.AddTransient<AllTendersPageViewModel>();
            _ = services.AddTransient<AddNewTTNPageViewModel>();
            _ = services.AddTransient<TTNPageViewModel>();


            _ = services.AddScoped<StDBEntities>();
            _ = services.AddSingleton<PageService>();
            _ = services.AddScoped<DataService>();
            _ = services.AddSingleton<MessageBus>();
            _ = services.AddSingleton<EventSubscriber>();
            _ = services.AddSingleton<EventBus>();

            _provider = services.BuildServiceProvider();
        }

        public static T Resolve<T>() => _provider.GetRequiredService<T>();

    }


}


