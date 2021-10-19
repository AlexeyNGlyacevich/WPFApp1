using DevExpress.Mvvm;
using System;
using System.Windows;
using System.Windows.Input;
using WPFApp1.Model.AppDBcontext;
using WPFApp1.Model.Repositories.Intefaces;

namespace WPFApp1.ViewModel
{
    public class TenderViewModel : BindableBase
    {
        private readonly ITenderRepository _tenderRepository;
        public Tenders Tender { get; set; }

        private int? _idKey;
        public int? IDKey
        {
            get => _idKey;
            set
            {
                _idKey = value;
                RaisePropertiesChanged();
            }
        }
        private DateTime? _date_purchase;
        public DateTime? Date_purchase
        {
            get => _date_purchase;
            set
            {
                _date_purchase = value;
                RaisePropertiesChanged();
            }
        }
        private DateTime? _final_proposal_date;
        public DateTime? Final_proposal_date
        {
            get => _final_proposal_date;
            set
            {
                _final_proposal_date = value;
                RaisePropertiesChanged();
            }
        }
        private DateTime? _traiding_date;
        public DateTime? Traiding_date
        {
            get => _traiding_date;
            set
            {
                _traiding_date = value;
                RaisePropertiesChanged();
            }
        }
        private string _objekt_name;
        public string Objekt_Name
        {
            get => _objekt_name;
            set
            {
                _objekt_name = value;
                RaisePropertiesChanged();
            }
        }
        private string _subject_of_contract;
        public string Subject_of_Contract
        {
            get => _subject_of_contract;
            set
            {
                _subject_of_contract = value;
                RaisePropertiesChanged();
            }
        }
        private decimal? _starting_price;
        public decimal? Starting_price
        {
            get => _starting_price;
            set
            {
                _starting_price = value;
                RaisePropertiesChanged();

            }
        }
        private decimal? _price_date_submission;
        public decimal? Price_date_submission
        {
            get => _price_date_submission;
            set
            {
                _price_date_submission = value;
                RaisePropertiesChanged();
            }
        }
        private decimal? _price_inclusive_reduction;
        public decimal? Price_inclusive_reduction
        {
            get => _price_inclusive_reduction;
            set
            {
                _price_inclusive_reduction = value;
                RaisePropertiesChanged();
            }
        }
        private string _result;
        public string Result
        {
            get => _result;
            set
            {
                _result = value;
                RaisePropertiesChanged();
            }
        }
        private DateTime? _acceptance_date;
        public DateTime? Acceptance_date
        {
            get => _acceptance_date;
            set
            {
                _acceptance_date = value;
                RaisePropertiesChanged();
            }
        }
        private DateTime? _term_of_contract;
        public DateTime? Term_of_contract
        {
            get => _term_of_contract;
            set
            {
                _term_of_contract = value;
                RaisePropertiesChanged();
            }
        }
        private decimal? _final_price;
        public decimal? Final_price
        {
            get => _final_price;
            set
            {
                _final_price = value;
                RaisePropertiesChanged();
            }
        }
        private string _tender_number;
        public string Tender_number
        {
            get => _tender_number;
            set
            {
                _tender_number = value;
                RaisePropertiesChanged();
            }
        }
        private string _repository;
        public string Repository
        {
            get => _repository;
            set
            {
                _repository = value;
                RaisePropertiesChanged();
            }
        }

        public TenderViewModel(ITenderRepository tenderRepository)
        {
            _tenderRepository = tenderRepository;

            Tender = _tenderRepository.GetCuttentTender(_tenderRepository.GetTenderID());

            IDKey = Tender.IDKey;
            Date_purchase = Tender.Date_purchase;
            Final_proposal_date = Tender.final__proposal_date;
            Traiding_date = Tender.trading_date;
            Objekt_Name = Tender.Object_name;
            Subject_of_Contract = Tender.subject_of_a_contract;
            Starting_price = Tender.starting_price;
            Price_date_submission = Tender.price_date_submission;
            Price_inclusive_reduction = Tender.price_inclusive_reduction;
            Result = Tender.Result;
            Acceptance_date = Tender.Acceptance_date;
            Term_of_contract = Tender.Term_of_the_contract;
            Final_price = Tender.final_price;
            Tender_number = Tender.Tender_number;
            Repository = Tender.Repository;
        }

        public ICommand TenderSaveChanged => new DelegateCommand(() =>
        {
            if (_tenderRepository.CheckTenderRegistrationNumber(Tender_number) && Tender.Tender_number != Tender_number)
            {
                _ = MessageBox.Show("Тендер с указанным номером уже существует!", "Сохраненить Изменения", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                Tender.IDKey = IDKey;
                Tender.Date_purchase = Date_purchase;
                Tender.final__proposal_date = Final_proposal_date;
                Tender.trading_date = Traiding_date;
                Tender.Object_name = Objekt_Name;
                Tender.subject_of_a_contract = Subject_of_Contract;
                Tender.starting_price = Starting_price;
                Tender.price_date_submission = Price_date_submission;
                Tender.price_inclusive_reduction = Price_inclusive_reduction;
                Tender.Result = Result;
                Tender.Acceptance_date = Acceptance_date;
                Tender.Term_of_the_contract = Term_of_contract;
                Tender.final_price = Final_price;
                Tender.Tender_number = Tender_number;
                Tender.Repository = Repository;

                _tenderRepository.UpdateTender(Tender);
                _ = MessageBox.Show("Изменения Успешно Сохранены", "Cохранение Изменений", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }, () => IDKey != Tender.IDKey || Date_purchase != Tender.Date_purchase || Final_proposal_date != Tender.final__proposal_date || Objekt_Name != Tender.Object_name || Traiding_date != Tender.trading_date || Traiding_date != Tender.trading_date ||
                 Subject_of_Contract != Tender.subject_of_a_contract || Starting_price != Tender.starting_price || Price_date_submission != Tender.price_date_submission ||
                 Price_inclusive_reduction != Tender.price_inclusive_reduction || Result != Tender.Result || Acceptance_date != Tender.Acceptance_date || Term_of_contract != Tender.Term_of_the_contract ||
                 Final_price != Tender.final_price || Tender_number != Tender.Tender_number || Repository != Tender.Repository);

        public ICommand RestoreTenderdata => new DelegateCommand(() =>
        {
            IDKey = Tender.IDKey;
            Date_purchase = Tender.Date_purchase;
            Final_proposal_date = Tender.final__proposal_date;
            Traiding_date = Tender.trading_date;
            Objekt_Name = Tender.Object_name;
            Subject_of_Contract = Tender.subject_of_a_contract;
            Starting_price = Tender.starting_price;
            Price_date_submission = Tender.price_date_submission;
            Price_inclusive_reduction = Tender.price_inclusive_reduction;
            Result = Tender.Result;
            Acceptance_date = Tender.Acceptance_date;
            Term_of_contract = Tender.Term_of_the_contract;
            Final_price = Tender.final_price;
            Tender_number = Tender.Tender_number;
            Repository = Tender.Repository;

        }, () => IDKey != Tender.IDKey || Date_purchase != Tender.Date_purchase || Final_proposal_date != Tender.final__proposal_date || Objekt_Name != Tender.Object_name || Traiding_date != Tender.trading_date || Traiding_date != Tender.trading_date ||
                 Subject_of_Contract != Tender.subject_of_a_contract || Starting_price != Tender.starting_price || Price_date_submission != Tender.price_date_submission ||
                 Price_inclusive_reduction != Tender.price_inclusive_reduction || Result != Tender.Result || Acceptance_date != Tender.Acceptance_date || Term_of_contract != Tender.Term_of_the_contract ||
                 Final_price != Tender.final_price || Tender_number != Tender.Tender_number || Repository != Tender.Repository);
    }
}
