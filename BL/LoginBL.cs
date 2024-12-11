using DTO;
using DL;
namespace BL
{
    public class LoginBL
    {
        public bool Login(UserAccount account)
        {
            try
            {
                return new LoginDL().Login(account);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Dictionary<string, string> GetLoginInfo(UserAccount account)
        {
            Dictionary<string, string> accountInfo = new Dictionary<string, string>();
            Dictionary<string, string> additionalInfo = GetAdditionalInfo(account);

            accountInfo.Add("Username", account.Username);
            accountInfo.Add("Password", account.Password);

            foreach(KeyValuePair<string, string> kvp in additionalInfo)
            {
                accountInfo.Add(kvp.Key, kvp.Value);
            }
            
            return accountInfo;
        }

        public Dictionary<string, string> GetAdditionalInfo(UserAccount account)
        {
            try
            {
                return new LoginDL().GetAdditionalInfo(account);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
