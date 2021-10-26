using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Model.Repositories.Intefaces;

namespace WPFApp1.ViewModel
{
    public class ResponsPersonsPageViewModel : BindableBase
    {
        private readonly IResponsPersonsRepository _responsPersonsRepository;
        public ObservableCollection<Respons_persons> ResponsPersons { get; set; }

        public ResponsPersonsPageViewModel(IResponsPersonsRepository responsPersonsRepository)
        {
            _responsPersonsRepository = responsPersonsRepository;
            ResponsPersons = new ObservableCollection<Respons_persons>(_responsPersonsRepository.GetAllPersons());
        }

    }
}
