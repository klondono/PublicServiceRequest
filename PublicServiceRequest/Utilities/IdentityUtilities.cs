using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Configuration;
using System.Web;
using System.Reflection;
using System.Web.Security;

namespace CustomerService_PSR.Utilities
{
    public static class IdentityUtilities
    {
        public static string GetActiveDirectoryDisplayName(this IIdentity identity)
        {
            string userName = identity.Name.Replace("\\", "/");
            DirectoryEntry de = new DirectoryEntry("WinNT://" + userName);
            return de.Properties["fullName"].Value.ToString();
        }

        public static String GetEmail(this IIdentity userIdentity)
        {
            using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, "Miamidade"))
            {
                return UserPrincipal.FindByIdentity(principalContext, userIdentity.Name).EmailAddress;
            }
        }

        public static String GetFullName(this IIdentity userIdentity)
        {
            using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, "Miamidade"))
            {
                var userPrincipal = UserPrincipal.FindByIdentity(principalContext, userIdentity.Name);
                return userPrincipal.GivenName + " " + userPrincipal.Surname;
            }
        }

        public static bool IsInActiveDirectoryGroup(this IPrincipal user, string group)
        {
            if (String.IsNullOrEmpty(group))
            {
                return false;
            }

            return user.IsInRole(@"Miamidade\"+group);
        }

        public static List<String> GetActiveDirectoryGroups(this IIdentity userIdentity)
        {
            return Roles.GetRolesForUser().Select(x=>x.Split('\\').Last()).ToList();
        }

        public static Guid? GetUserID(this IIdentity userIdentity)
        {
            using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, "Miamidade"))
            {
                return UserPrincipal.FindByIdentity(principalContext, userIdentity.Name).Guid;
            }
        }
    }
}