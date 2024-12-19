using DTO;
using DL;
namespace BL
{
    public class LoginBL
    {
        public bool Login(UserAccountDTO account)
        {
            try
            {
                return new LoginDL().Login(account);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public Dictionary<string, string> GetLoginInfo(UserAccountDTO account)
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

        public Dictionary<string, string> GetAdditionalInfo(UserAccountDTO account)
        {
            try
            {
                return new LoginDL().GetAdditionalInfo(account);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
