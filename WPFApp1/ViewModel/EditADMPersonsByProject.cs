using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Model.Repositories.Intefaces;
using WPFApp1.Services;

namespace WPFApp1.ViewModel
{
    public class EditADMPersonsByProject : BindableBase
    {
        private readonly IResponsPersonsRepository _responsPersonsRepository;
        private readonly IProjektRepository _projektRepository;
        private readonly ResponcePersonsService _personsService;

        public int CurrentProjectID { get; set; }
        public ObservableCollection<Respons_persons> AssignedADMPersons { get; set; }
        public ObservableCollection<Respons_persons> RemainingADMPersons { get; set; }
        public Respons_persons Person { get; set; }
        public Respons_persons AddPerson { get; set; }


        public EditADMPersonsByProject(IResponsPersonsRepository responsPersonsRepository, IProjektRepository projektRepository, ResponcePersonsService personsServive)
        {
            _responsPersonsRepository = responsPersonsRepository;
            _projektRepository = projektRepository;
            _personsService = personsServive;
            CurrentProjectID = _projektRepository.ProjektID;
            AssignedADMPersons = new ObservableCollection<Respons_persons>(_responsPersonsRepository.GetAdminstrativePersonsByCurrentProjekt(CurrentProjectID));
            RemainingADMPersons = new ObservableCollection<Respons_persons>(_personsService.SelectRemainingADMPersons(CurrentProjectID));
        }

        public ICommand SaveChangesByResp_Persons => new DelegateCommand(() =>
        {
            _responsPersonsRepository.UpdateAdminstrativePersonsByCurrentProject(CurrentProjectID, AssignedADMPersons);
            var windows = Application.Current.Windows;
            foreach (Window window in windows)
            {
                if (window.Name.Equals("AMD_PersonEdit"))
                {
                    window.DialogResult = true;
                    return;
                }
            }
        });

        public ICommand RemoveFromCurrentADMcollection => new DelegateCommand(() =>
        {
            if (Person == null)
            {
                return;
            }
            else
            {
                RemainingADMPersons.Add(Person);
                _ = AssignedADMPersons.Remove(Person);

            }
        });

        public ICommand AddToCurrentADMcollection => new DelegateCommand(() =>
        {
            if(AddPerson == null)
            {
                return;
            }
            else
            {
                AssignedADMPersons.Add(AddPerson);
                RemainingADMPersons.Remove(AddPerson);
            }
        });

    }
}
