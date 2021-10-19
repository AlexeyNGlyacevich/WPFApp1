using System.Linq;
using WPFApp1.Model.AppDBcontext;

namespace WPFApp1.Model.Repositories.Intefaces
{
    public interface IContractRepository
    {
        int ContractID { get; set; }
        int ProjektID { get; set; }

        IQueryable<Contracts> GetAllContracts();

        IQueryable<Contracts> GetProjektContracts(int projektID);

        Contracts GetCurrentConract(int contractID);

        Documentation GetDocumentationDataForCurrentContract(int contractID);

        bool CheckContractRegistrationNumber(int number);

        bool ChecContractRegistrationNumberByCorrect(int number);

        void SetContractID(Contracts contract);

        bool AddNewContract(Contracts contract);

        bool AddNewDocumentation(Documentation documentation);

        bool RemoveCurrentContract(int ContractID);

        void UpdateContract(Contracts contract, Documentation documentation);
    }
}
