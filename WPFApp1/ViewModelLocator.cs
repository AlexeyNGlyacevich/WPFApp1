using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    }
}
