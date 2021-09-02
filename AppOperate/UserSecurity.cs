using System;
using ClassLibrary;
using System.DirectoryServices;

namespace AppOperate
{
    public class UserSecurity
    {
        public static string showLogin(string permission)
        {
            if (permission == "Super" || permission == "Design")
                return "Yes";
            return "No";
        }
        public static string Role(string UserID)
        {
            return getSecurityRole(UserID, "Role");
        }
        public static string Permission(string userID, string role)
        {
            return getSecurityRole(userID, "Permission", role);
        }
        private static string getSecurityRole(string userID, string type)
        {
            string SP = "dbo.tcdsb_LTO_PageUser_RoleAndPermission @UserID, @Type";
            var wt = new { UserID = userID, Type = type };
            return CommonExcute<string>.GeneralValue(SP, wt);
        }
        private static string getSecurityRole(string userID, string type, string role)
        {
            string SP = "dbo.tcdsb_LTO_PageUser_RoleAndPermission @UserID, @Type, @Role";
            var wt = new { UserID = userID, Type = type, Role = role };
            return CommonExcute<string>.GeneralValue(SP, wt);
        }
        public static string UserRole(string userID)
        {
            string SP = "dbo.tcdsb_LTO_PageUser_Role @UserID";
            var wt = new { UserID = userID};
            return CommonExcute<string>.GeneralValue(SP, wt);
        }
        public static bool Authenticate(string domain, string userName, string pwd)
        {
            try
            {

                string _path = WebConfigValue.getValuebyKey("LDAP");
                string domainAndUsername = domain + "'\'" + userName;
                DirectoryEntry entry = new DirectoryEntry(_path, userName, pwd);
                try
                {
                    object obj = entry.NativeObject; //  .NativeObject;
                    DirectorySearcher search = new DirectorySearcher(entry);

                    search.Filter = "(SAMAccountName=" + userName + ")";
                    search.PropertiesToLoad.Add("cn");
                    SearchResult result = search.FindOne();

                    if (result == null)
                        return false;
                    else
                        return true;

                }
                catch (Exception ex)
                {
                    string em = ex.Message;
                    return false; ;

                }

            }
            catch (Exception ex)
            {
                string myEx = ex.Message;
                return false;
            }
        }
        public static string AuthenticateResult(string domain, string userName, string pwd)
        {
            try
            {

                string _path = WebConfigValue.getValuebyKey("LDAP");
                string domainAndUsername = domain + "'\'" + userName;
                DirectoryEntry entry = new DirectoryEntry(_path, userName, pwd);
                try
                {
                    object obj = entry.NativeObject; //  .NativeObject;
                    DirectorySearcher search = new DirectorySearcher(entry);

                    search.Filter = "(SAMAccountName=" + userName + ")";
                    search.PropertiesToLoad.Add("cn");
                    SearchResult result = search.FindOne();

                    if (result == null)
                        return "Login Authentication Failed Name or Password Error";
                    else
                        return "true";

                }
                catch (Exception ex)
                {
                  //  string em = ex.Message;
                    return "Login Authentication Failed at NativeObject - " + ex.Message; 

                }

            }
            catch (Exception ex)
            {
                string myEx = ex.Message;
                return "Login Authentication Failed at DirectoryEntry - " + ex.Message;
            }
        }

        public static string GetCurrentUserName(string type, string cUser)
        {
            int sIndex = cUser.IndexOf("\\");
            var sLeng = cUser.Length;
            if (type == "Domain")
                return cUser.Substring(0, sIndex);
            else
                return cUser.Substring(sIndex + 1, sLeng - sIndex - 1);
        }
    }

}
