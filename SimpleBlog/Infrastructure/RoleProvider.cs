using System.Linq;

namespace SimpleBlog.Infrastructure 
{
    public class RoleProvider : System.Web.Security.RoleProvider
    {
        //Authentication - determine if the person is who they say they are.
        //Authorization - What is this authenticated user authorized to do? 
        public override string[] GetRolesForUser(string username)
        {
            return Auth.User.Roles.Select(role => role.Name).ToArray();

//            if(username.ToLower() == "jordan")
//                return new[] { "admin" };
//
//            return new string[] {};
        }

        //None of the below are implemented yet.
        public override bool IsUserInRole(string username, string roleName)
        {
            throw new System.NotImplementedException();
        }

 
        public override void CreateRole(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new System.NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new System.NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new System.NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new System.NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new System.NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}