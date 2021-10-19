using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Model.Repositories.Intefaces;

namespace WPFApp1.ViewModel
{
    public class AddNewTTNPageViewModel : BindableBase
    {
        public int TTNNumber { get; set; }
        public int ContractKey { get; set; }
        public Main_Reestr CurrentObjekt { get; set; }
        public ObservableCollection<Contracts> Contracts { get; set; }

        private readonly IProjektRepository _projektRepository;
        private readonly ITTNRepository _tTNRepository;
        private readonly IContractRepository _contractRepository;


        public AddNewTTNPageViewModel(IProjektRepository projektRepository, ITTNRepository tTNRepository, IContractRepository contractRepository)
        {
            _projektRepository = projektRepository;
            _tTNRepository = tTNRepository;
            _contractRepository = contractRepository;
            CurrentObjekt = _projektRepository.GetCurrentProjekt(_projektRepository.ProjektID);
            Contracts = new ObservableCollection<Contracts>(_contractRepository.GetProjektContracts(CurrentObjekt.ID));
        }

        public ICommand AddNewTTN => new DelegateCommand(() =>
        {
            if (_tTNRepository.CheckTTNRegistrationNumber(TTNNumber))
            {
                _ = MessageBox.Show("Накладная с указанным номером уже зарегистрирована!", "Добавление Накладной", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                TTN ttn = new TTN
                {
                    ContractID = ContractKey,
                    Act_number = TTNNumber
                };
                _tTNRepository.AddNewTTN(ttn);
                var windows = Application.Current.Windows;
                foreach (Window window in windows)
                {
                    if (window.Name.Equals("TTN"))
                    {
                        window.DialogResult = true;
                        _ = MessageBox.Show("Накладная Зарегистрирована", "Добавление Накладной", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                }
                _ = MessageBox.Show("Новая Накладная Успешно Добавлена", "Добавление Накладной", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }, () => TTNNumber != 0 && TTNNumber > 9 && ContractKey != 0);
    }

}