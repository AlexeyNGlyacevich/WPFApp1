using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Pages;
using WPFApp1.Services;

namespace WPFApp1.ViewModel
{
    public class AddNewObjektPageViewModel : BindableBase
    {
        public int registrnumber { get; set; }
        public string cstage { get; set; }
        public string objektName { get; set; }
        public string projektType { get; set; }
        public int resp_person { get; set; }

        private readonly PageService _navigation;
        private readonly DataService _dataservice;
        public ObservableCollection<Main_Reestr> Contract { get; set; } = new ObservableCollection<Main_Reestr>();
        public ObservableCollection<Respons_persons> RespPersons { get; set; } = new ObservableCollection<Respons_persons>();

        public AddNewObjektPageViewModel(PageService navigation, DataService dataservice)
        {
            _navigation = navigation;
            _dataservice = dataservice;
            RespPersons = new ObservableCollection<Respons_persons>(_dataservice.GetAllRespPersons());
        }

        public void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text == null || !e.Text.All(char.IsDigit))
            {
                e.Handled = true;
            }
        }

        public ICommand AddNewObjekt => new DelegateCommand(() =>
        {
            Main_Reestr Newobjekt = new Main_Reestr() { Doc_Number = registrnumber, stage = cstage, Object_name = objektName, project_type = projektType, resp_personID = resp_person};
            _dataservice.AddNewObjekt(Newobjekt);
            MessageBox.Show("Новая запись добавлена в реестр");
            _navigation.Navigate(new MainDataReestrPage());

        }, () => !string.IsNullOrEmpty(objektName) && !string.IsNullOrEmpty(projektType) && !string.IsNullOrEmpty(cstage) && registrnumber != 0);

    }
}
