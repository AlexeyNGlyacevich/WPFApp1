using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
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
    public class AddNewTenderViewModel : BindableBase
    {
        public string TenderNumber { get; set; }
        public int ObjektID { get; set; }
        public int? ObjektNumber { get; set; }
        public Main_Reestr CurrentObjekt { get; set; }

        private readonly PageService _navigation;
        private readonly DataService _dataservice;

        public AddNewTenderViewModel(DataService dataservice, PageService navigation)
        {
            _navigation = navigation;
            _dataservice = dataservice;
            CurrentObjekt = _dataservice.GetCurrentObjektInfo(_dataservice.CurrentObjektID);
            ObjektNumber = CurrentObjekt.Doc_Number;
        }
        public ICommand AddNewTender => new DelegateCommand(() =>
        {
            if (_dataservice.CheckTenderRegistrationNumber(TenderNumber))
            {
                _ = MessageBox.Show("Тендер с указанным номером уже зарегистрирован!", "Новый Тендер", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                Tenders tender = new Tenders
                {
                    IDKey = CurrentObjekt.ID,
                    Tender_number = TenderNumber
                };
                _dataservice.AddNewTender(tender);
                _ = MessageBox.Show("Новый Тендер Успешно Добавлен", "Новый Тендер", MessageBoxButton.OK, MessageBoxImage.Information);
                _navigation.Refresh();
                _navigation.Refresh();
                _navigation.Navigate(new ObjectPage());
            }

        }, () => !string.IsNullOrEmpty(TenderNumber) && ObjektNumber != 0 && TenderNumber != "0");
    }
}
