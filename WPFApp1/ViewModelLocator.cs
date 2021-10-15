using WPFApp1.ViewModel;

namespace WPFApp1
{
    internal class ViewModelLocator
    {
        public MainViewModel MainViewModel => IoC.Resolve<MainViewModel>();

        public SelectRolePageViewModel SelectRolePageViewModel => IoC.Resolve<SelectRolePageViewModel>();

        public LoginPageViewModel LoginPageViewModel => IoC.Resolve<LoginPageViewModel>();

        public AdminPageViewModel AdminPageViewModel => IoC.Resolve<AdminPageViewModel>();

        public MainDataReestrViewModel MainDataReestrViewModel => IoC.Resolve<MainDataReestrViewModel>();

        public ObjectPageViewModel ObjectPageViewModel => IoC.Resolve<ObjectPageViewModel>();

        public AllContractsViewModel AllContractsViewModel => IoC.Resolve<AllContractsViewModel>();

        public UserEditoPageViewModel UserEditorPageViewModel => IoC.Resolve<UserEditoPageViewModel>();

        public AllUsersEditorPageViewModel AllUsersEditorPageViewModel => IoC.Resolve<AllUsersEditorPageViewModel>();

        public UpdateUserPageViewModel UpdateUserPageViewModel => IoC.Resolve<UpdateUserPageViewModel>();

        public AddNewObjektPageViewModel AddNewObjektPageViewModel => IoC.Resolve<AddNewObjektPageViewModel>();

        public ContractViewModel ContractViewModel => IoC.Resolve<ContractViewModel>();

        public AddNewConrtactViewModel AddNewConrtactViewModel => IoC.Resolve<AddNewConrtactViewModel>();

        public TenderViewModel TenderViewModel => IoC.Resolve<TenderViewModel>();

        public AddNewTenderViewModel AddNewTenderViewModel => IoC.Resolve<AddNewTenderViewModel>();

        public AllTendersPageViewModel AllTendersPageViewModel => IoC.Resolve<AllTendersPageViewModel>();

        public AddNewTTNPageViewModel AddNewTTNPageViewModel => IoC.Resolve<AddNewTTNPageViewModel>();

        public TTNPageViewModel TTNPageViewModel => IoC.Resolve<TTNPageViewModel>();

        public AllTTNPageViewModel AllTTNPageViewModel => IoC.Resolve<AllTTNPageViewModel>();

        public ResponsPersonsPageViewModel ResponsPersonsPageViewModel => IoC.Resolve<ResponsPersonsPageViewModel>();

        public CustomersCatalogPageViewModel CustomersCatalogPageViewModel => IoC.Resolve<CustomersCatalogPageViewModel>();

    }
}
