using System.Linq;
using WPFApp1.Model.AppDBcontext;

namespace WPFApp1.Model.Repositories.Intefaces
{
    public interface ITTNRepository
    {
        void SetTTN_ID(TTN ttn);

        int GetTTN_ID();

        IQueryable<TTN> GetAllTTN();

        void RemoveCurrentTTN(int TTN_ID);

        TTN GetCurrentTTN(int TTN_ID);

        void AddNewTTN(TTN ttn);

        void UpdateTTN(TTN ttn);

        bool CheckTTNRegistrationNumber(int TTN_Number);
    }
}
