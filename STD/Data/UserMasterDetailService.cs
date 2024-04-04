using STD.Components.Models;

namespace STD.Data
{
    public class UserMasterDetailService
    {
        custConnections objUsers = new custConnections();
        public async Task<UserMaster[]> GetCustDetails(string login, string password)
        {
            UserMaster[] custsObjs;
            custsObjs = objUsers.GetCustDetails(login, password).Result.ToArray();
            return custsObjs;
        }

        //public async Task<UserMaster[]> MultiWallet(decimal wallet)
        //{
           // UserMaster[] custsObjs;
            //custsObjs = objUsers.GetCustDetails(wallet).Result.ToArray();
            //return custsObjs;
        //}
    }
}
