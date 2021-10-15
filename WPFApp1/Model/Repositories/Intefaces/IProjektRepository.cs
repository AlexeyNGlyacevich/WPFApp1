using System.Linq;
using WPFApp1.Model.AppDBcontext;

namespace WPFApp1.Model.Repositories.Intefaces
{
    public interface IProjektRepository
    {
        int ProjektID { get; set; }

        IQueryable<Main_Reestr> GetProjekts();

        IQueryable<Main_Reestr> GetProjektsToView();

        IQueryable<Contracts> GetContractsForCurrentProjekt(int projektID);

        IQueryable<Tenders> GetTendersForCurrentProject(int projektID);

        IQueryable<TTN> GetTTNsForCurrentProjekt(int projektID);

        void UpdateProjekt(Main_Reestr projekt);

        void GetCurrentProjectID(Main_Reestr projekt);

        bool CheckCustomerID(string name);

        Main_Reestr GetCurrentProjekt(int projektID);

        void AddNewProjekt(Main_Reestr projekt);

        bool CheckObjektRegistrationNumber(int projektNumber);


    }
}
