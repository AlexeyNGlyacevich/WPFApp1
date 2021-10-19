using DevExpress.Mvvm;
using System.Windows;
using System.Windows.Input;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Model.Repositories.Intefaces;

namespace WPFApp1.ViewModel
{
    public class AddNewTenderViewModel : BindableBase
    {
        public string TenderNumber { get; set; }
        public int ObjektID { get; set; }
        public int? ObjektNumber { get; set; }
        public Main_Reestr CurrentObjekt { get; set; }

        private readonly IProjektRepository _projektRepository;
        private readonly ITenderRepository _tenderRepository;

        public AddNewTenderViewModel(IProjektRepository projektRepositoty, ITenderRepository tenderRepository)
        {
            _projektRepository = projektRepositoty;
            _tenderRepository = tenderRepository;
            CurrentObjekt = _projektRepository.GetCurrentProjekt(_projektRepository.ProjektID);
            ObjektNumber = CurrentObjekt.Doc_Number;
        }
        public ICommand AddNewTender => new DelegateCommand(() =>
        {
            if (_tenderRepository.CheckTenderRegistrationNumber(TenderNumber))
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
                _tenderRepository.AddNewTender(tender);
                var windows = Application.Current.Windows;
                foreach (Window window in windows)
                {
                    if (window.Name.Equals("Tender"))
                    {
                        window.DialogResult = true;
                        _ = MessageBox.Show("Тендер Зарегистрирован", "Добавление Тендера", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                }
                _ = MessageBox.Show("Новый Тендер Успешно Добавлен", "Новый Тендер", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }, () => !string.IsNullOrEmpty(TenderNumber) && ObjektNumber != 0 && TenderNumber != "0");
    }
}
