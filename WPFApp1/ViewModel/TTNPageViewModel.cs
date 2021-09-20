using DevExpress.Mvvm;
using System.Windows;
using System.Windows.Input;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Services;

namespace WPFApp1.ViewModel
{
    public class TTNPageViewModel : BindableBase
    {
        private readonly PageService _navigation;
        private readonly DataService _dataservice;
        public TTN TTN { get; set; } = new TTN();

        public TTNPageViewModel(PageService navigation, DataService dataservice)
        {
            _dataservice = dataservice;
            _navigation = navigation;
            TTN = _dataservice.GetCurrentTTN(_dataservice.TTNID);
        }

        public ICommand ContractSaveChanged => new DelegateCommand(() =>
        {
            try
            {
                _dataservice.UpdateTTN(TTN);
                _ = MessageBox.Show("Изменения Успешно Сохранены", "Cохранение Изменений", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                _ = MessageBox.Show("Ошибка", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        });
    }
}
