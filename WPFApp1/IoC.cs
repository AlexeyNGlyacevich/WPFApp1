using Microsoft.Extensions.DependencyInjection;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Model.Repositories;
using WPFApp1.Model.Repositories.Intefaces;
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
            _ = services.AddTransient<AdminPageViewModel>();
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
            _ = services.AddTransient<AllTTNPageViewModel>();
            _ = services.AddTransient<ResponsPersonsPageViewModel>();
            _ = services.AddTransient<CustomersCatalogPageViewModel>();
            _ = services.AddTransient<EditADMPersonsByProjectViewModel>();
            _ = services.AddTransient<Contract_ENG_RespPersonsViewModel>();


            _ = services.AddScoped<ProjectStDBEntities>();
            _ = services.AddSingleton<PageService>();
            _ = services.AddScoped<MessageBus>();
            _ = services.AddScoped<EventSubscriber>();
            _ = services.AddScoped<EventBus>();
            _ = services.AddTransient<ResponcePersonsService>();
            _ = services.AddScoped<IResponsPersonsRepository, ResponsPersonsRepository>();
            _ = services.AddScoped<IProjektRepository, ProjektRepository>();
            _ = services.AddScoped<ICustomersRepository, CustomersRepository>();
            _ = services.AddScoped<IContractRepository, ContractRepository>();
            _ = services.AddScoped<IUsersRepository, UsersRepository>();
            _ = services.AddScoped<ITenderRepository, TenderRepository>();
            _ = services.AddScoped<ITTNRepository, TTNRepository>();

            _provider = services.BuildServiceProvider();
        }

        public static T Resolve<T>() => _provider.GetRequiredService<T>();

    }


}


