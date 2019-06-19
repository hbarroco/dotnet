using HB.Vendas.Online.Domain.Entities;
using HB.Vendas.Online.Presentation.Models.Infra;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HB.Vendas.Online.Presentation.Utilities.Authentication
{
    public static class AuthenticationHandler
    {
        public static void Loggin(User entity)
        {
            if (entity == null || entity.Id == 0)
                throw new ArgumentException("Usuário não autenticado no sistema");

            ClearLooginSession();

            Helpers.AppContext.Current.Session.SetString(SessionLoggedUser.IdLoggedUser, entity.Id.ToString());
            Helpers.AppContext.Current.Session.SetString(SessionLoggedUser.NameLoggedUser, entity.Name);
            Helpers.AppContext.Current.Session.SetString(SessionLoggedUser.RoleLoggedUser, AuthorizationRoles.Administrator.ToString());
            Helpers.AppContext.Current.Session.SetString(SessionLoggedUser.UserNameLoggedUser, entity.UserName);
            Helpers.AppContext.Current.Session.SetString(SessionLoggedUser.PasswordLoggedUser, entity.Password);
            Helpers.AppContext.Current.Session.SetString(SessionLoggedUser.StoreIdLoggedUser, entity.Store.Id.ToString());
            Helpers.AppContext.Current.Session.SetString(SessionLoggedUser.StoreNameLoggedUser, entity.Store.Name);
        }

        public static void LogOut()
        {
            ClearLooginSession();
        }

        public static LoggedUser GetCurrentUser()
        {
            var loggedUser = new LoggedUser();

            if (string.IsNullOrWhiteSpace(Helpers.AppContext.Current.Session.GetString(SessionLoggedUser.IdLoggedUser)))
                return new LoggedUser();

            loggedUser.Id = Convert.ToInt32(Helpers.AppContext.Current.Session.GetString(SessionLoggedUser.IdLoggedUser));
            loggedUser.Name = Helpers.AppContext.Current.Session.GetString(SessionLoggedUser.NameLoggedUser);
            loggedUser.Role = (AuthorizationRoles)Enum.Parse(typeof(AuthorizationRoles), Helpers.AppContext.Current.Session.GetString(SessionLoggedUser.RoleLoggedUser));
            loggedUser.UserName = Helpers.AppContext.Current.Session.GetString(SessionLoggedUser.UserNameLoggedUser);
            loggedUser.Password = Helpers.AppContext.Current.Session.GetString(SessionLoggedUser.PasswordLoggedUser);
            loggedUser.StoreId = Convert.ToInt32(Helpers.AppContext.Current.Session.GetString(SessionLoggedUser.StoreIdLoggedUser));
            loggedUser.StoreName = Helpers.AppContext.Current.Session.GetString(SessionLoggedUser.StoreNameLoggedUser);

            return loggedUser;
        }

        public static bool UserLogged()
        {
            var userLogged = GetCurrentUser();

            if (userLogged.Id > 0)
                return true;
            else
                return false;
        }

        private static void ClearLooginSession()
        {
            Helpers.AppContext.Current.Session.Clear();
        }
    }
}
