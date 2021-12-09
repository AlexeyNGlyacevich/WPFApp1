using System.Linq;
using WPFApp1.Model.AppDBcontext;

namespace WPFApp1.Model.Repositories.Intefaces
{
    public interface ITenderRepository
    {
        int GetTenderID();

        void SetCurrentTenderID(Tenders tender);

        Tenders GetCuttentTender(int TenderID);

        bool CheckTenderRegistrationNumber(string number);

        void AddNewTender(Tenders tender);

        void RemoveCurrentTender(int TenderID);

        void UpdateTender(Tenders tender);

        IQueryable<Tenders> GetAlltenders();

        IQueryable<Currency_type> GetAllTypes();
    }
}
