using DevExpress.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WPFApp1.DialogWindows;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Model.Repositories.Intefaces;
using WPFApp1.Pages;
using WPFApp1.Pages.Contract;
using WPFApp1.Pages.Tender;
using WPFApp1.Pages.TTN;
using WPFApp1.Services;

namespace WPFApp1.ViewModel
{
    internal class ObjectPageViewModel : BindableBase
    {
        private readonly PageService _navigation;
        private readonly DataService _dataservice;
        private readonly IResponsPersonsRepository _responsPersonsRepository;
        private readonly IProjektRepository _projektRepository;
        private readonly ICustomersRepository _customersRepository;
        public Main_Reestr CurrentObjekt { get; set; }
        public ObservableCollection<Contracts> CurrentObjektContracts { get; set; }
        public ObservableCollection<Tenders> CurrentObjektTenders { get; set; }
        public ObservableCollection<TTN> CurrentObjektTns { get; set; }
        public ObservableCollection<Customers> Customers { get; set; }
        public ObservableCollection<Respons_persons> RespPersons { get; set; }
        public ObservableCollection<Respons_persons> AllAdmPersons { get; set; }
        private Customers _customer;
        public Customers ThisCustomer
        {
            get => _customer;
            set
            {
                _customer = value;
                RaisePropertiesChanged();
            }
        }

        private int? _doc_Number;
        public int? Doc_Number
        {
            get => _doc_Number;
            set
            {
                _doc_Number = value;
                RaisePropertiesChanged();
            }
        }


        public string CustomerName
        {
            get => CurrentObjekt.Customers.Customer_Name;
            set => RaisePropertiesChanged();
        }
        private string _object_name;
        public string Object_Name
        {
            get => _object_name;
            set
            {
                _object_name = value;
                RaisePropertiesChanged();
            }
        }
        private int? _customerID;
        public int? CustomerID
        {
            get => _customerID;
            set
            {
                _customerID = value;
                RaisePropertiesChanged();
                ThisCustomer = _customersRepository.GetThisCustomer((int)CustomerID);
            }
        }
        private string _projekt_Type;
        public string Project_type
        {
            get => _projekt_Type;
            set
            {
                _projekt_Type = value;
                RaisePropertiesChanged();
            }
        }
        private string _stage;
        public string Stage
        {
            get => _stage;
            set
            {
                _stage = value;
                RaisePropertiesChanged();
            }
        }
        private DateTime? _creationDate;
        public DateTime? CreationDate
        {
            get => _creationDate;
            set
            {
                _creationDate = value;
                RaisePropertiesChanged();
            }
        }


        public ObjectPageViewModel(PageService navigation, IProjektRepository projektRepository, ICustomersRepository customersRepository, DataService dataService, IResponsPersonsRepository responsPersonsRepository)
        {
            _navigation = navigation;
            _dataservice = dataService;
            _projektRepository = projektRepository;
            _customersRepository = customersRepository;
            _responsPersonsRepository = responsPersonsRepository;

            CurrentObjekt = _projektRepository.GetCurrentProjekt(_projektRepository.ProjektID);
            CurrentObjektContracts = new ObservableCollection<Contracts>(_projektRepository.GetContractsForCurrentProjekt(_projektRepository.ProjektID));
            CurrentObjektTenders = new ObservableCollection<Tenders>(_projektRepository.GetTendersForCurrentProject(_projektRepository.ProjektID));
            CurrentObjektTns = new ObservableCollection<TTN>(_projektRepository.GetTTNsForCurrentProjekt(_projektRepository.ProjektID));
            Customers = new ObservableCollection<Customers>(_customersRepository.GetAllActiveCustommers());
            RespPersons = new ObservableCollection<Respons_persons>(_responsPersonsRepository.GetAdminstrativePersonsByCurrentProjekt(CurrentObjekt.ID));
            AllAdmPersons = new ObservableCollection<Respons_persons>(_responsPersonsRepository.GetAdminstrativePersons());

            Doc_Number = CurrentObjekt.Doc_Number;
            Object_Name = CurrentObjekt.Object_name;
            CustomerID = CurrentObjekt.CustomerID;
            Project_type = CurrentObjekt.project_type;
            Stage = CurrentObjekt.stage;
            CreationDate = CurrentObjekt.Creation_Date;
        }

        public ICommand ObjektSaveChanges => new DelegateCommand(() =>
        {
            if (_projektRepository.CheckObjektRegistrationNumber((int)Doc_Number) && CurrentObjekt.Doc_Number != Doc_Number)
            {
                _ = MessageBox.Show("Проект с указанным номером уже существует!", "Сохраненить Изменения", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                try
                {
                    CurrentObjekt.Doc_Number = Doc_Number;
                    CurrentObjekt.Object_name = Object_Name;
                    if (CustomerID == null)
                    {
                        _ = MessageBox.Show("Веден не существующий Заказчик", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    else
                    {
                        CurrentObjekt.CustomerID = CustomerID;
                    }
                    CurrentObjekt.project_type = Project_type;
                    CurrentObjekt.stage = Stage;
                    CurrentObjekt.Creation_Date = CreationDate;

                    _projektRepository.UpdateProjekt(CurrentObjekt);
                    _ = MessageBox.Show("Изменения Успешно Сохранены", "Cохранение Изменений", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    _ = MessageBox.Show("Ошибка", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
        }, () => Object_Name != CurrentObjekt.Object_name || CustomerID != CurrentObjekt.CustomerID || Project_type != CurrentObjekt.project_type ||
                 Stage != CurrentObjekt.stage || CreationDate != CurrentObjekt.Creation_Date || Doc_Number != CurrentObjekt.Doc_Number);


        public ICommand RestoreCurrentData => new DelegateCommand(() =>
        {
            Doc_Number = CurrentObjekt.Doc_Number;
            Object_Name = CurrentObjekt.Object_name;
            CustomerID = CurrentObjekt.CustomerID;
            Project_type = CurrentObjekt.project_type;
            Stage = CurrentObjekt.stage;
            CreationDate = CurrentObjekt.Creation_Date;

        }, () => Object_Name != CurrentObjekt.Object_name || CustomerID != CurrentObjekt.CustomerID || Project_type != CurrentObjekt.project_type ||
                 Stage != CurrentObjekt.stage || CreationDate != CurrentObjekt.Creation_Date || Doc_Number != CurrentObjekt.Doc_Number);


        public ICommand GetCurrentContract => new DelegateCommand<Contracts>((Contracts contract) =>
        {
            _dataservice.GetContractID(contract);
            _navigation.Navigate(new ContractPage());
        });

        //public ICommand CreateNewContract => new DelegateCommand(() =>
        //{
        //    _dataservice.ObjektID = CurrentObjekt.ID;
        //    _navigation.Navigate(new AddNewContractPage());
        //});

        public ICommand CreateNewContract => new DelegateCommand(() =>
        {
            _projektRepository.GetCurrentProjectID(CurrentObjekt);
            AddNewContractWindowDialog contractdialog = new AddNewContractWindowDialog();
            contractdialog.ShowDialog();

        });

        public ICommand DeleteContract => new DelegateCommand<Contracts>((Contracts contract) =>
        {
            MessageBoxResult result = MessageBox.Show("Удалить Договор?", "Удаление Договора", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    _dataservice.RemoveCurrentContract(contract.ID);
                    _ = MessageBox.Show("Договор Успешно удален.", "Удаление договора.", MessageBoxButton.OK, MessageBoxImage.Information);
                    _navigation.Refresh();
                    _navigation.Navigate(new ObjectPage());

                    break;
                case MessageBoxResult.No:
                    _ = MessageBox.Show("Удаление Договора отменено", "Удаление договора", MessageBoxButton.OK, MessageBoxImage.Stop);
                    break;
                case MessageBoxResult.None:
                    break;
                case MessageBoxResult.OK:
                    break;
                case MessageBoxResult.Cancel:
                    break;
                default:
                    break;
            }
        });

        public ICommand CreateNewTender => new DelegateCommand(() =>
        {
            _dataservice.ObjektID = CurrentObjekt.ID;
            _navigation.Navigate(new AddNewTenderPage());
        });

        public ICommand DeleteTender => new DelegateCommand<Tenders>((Tenders tender) =>
        {
            MessageBoxResult result = MessageBox.Show("Удалить Тендер?", "Удаление Тендера", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    _dataservice.RemoveCurrentTender(tender.ID);
                    _ = MessageBox.Show("Тендер Успешно удален.", "Удаление Тендера.", MessageBoxButton.OK, MessageBoxImage.Information);
                    _navigation.Refresh();
                    _navigation.Navigate(new ObjectPage());

                    break;
                case MessageBoxResult.No:
                    _ = MessageBox.Show("Удаление Тендера отменено", "Удаление Тендера", MessageBoxButton.OK, MessageBoxImage.Stop);
                    break;
                case MessageBoxResult.None:
                    break;
                case MessageBoxResult.OK:
                    break;
                case MessageBoxResult.Cancel:
                    break;
                default:
                    break;
            }
        });

        public ICommand EditCurrentTender => new DelegateCommand<Tenders>((Tenders tender) =>
        {
            _dataservice.GetCurrentTenderID(tender);
            _navigation.Navigate(new TenderPage());
        });


        public ICommand CreateNewTTN => new DelegateCommand(() =>
        {
            _dataservice.ObjektID = CurrentObjekt.ID;
            _navigation.Navigate(new AddNewTTNPage());
        });

        public ICommand EditCurrentTTN => new DelegateCommand<TTN>((TTN ttn) =>
        {
            _dataservice.GetCurrentTTNID(ttn);
            _navigation.Navigate(new TTNPage());
        });

        public ICommand DeleteTTN => new DelegateCommand<TTN>((TTN ttn) =>
        {
            MessageBoxResult result = MessageBox.Show("Удалить Накладную?", "Удаление Наклдадной", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    _dataservice.RemoveCurrentTTN(ttn.id);
                    _ = MessageBox.Show("Накладная Успешно удалена.", "Удаление Накладной.", MessageBoxButton.OK, MessageBoxImage.Information);
                    _navigation.Refresh();
                    _navigation.Navigate(new ObjectPage());

                    break;
                case MessageBoxResult.No:
                    _ = MessageBox.Show("Удаление Накладной отменено", "Удаление Накладной", MessageBoxButton.OK, MessageBoxImage.Stop);
                    break;
                case MessageBoxResult.None:
                    break;
                case MessageBoxResult.OK:
                    break;
                case MessageBoxResult.Cancel:
                    break;
                default:
                    break;
            }
        });


    }
}
