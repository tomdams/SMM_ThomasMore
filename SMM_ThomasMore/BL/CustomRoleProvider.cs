using SMM_ThomasMore.DAL.EF;
using SMM_ThomasMore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
//3
namespace SC.BL
{
  class CustomRoleProvider : RoleProvider
  {
    public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public override void AddUsersToRoles(string[] usernames, string[] roleNames)
    {
      throw new NotImplementedException();
    }

    public override void CreateRole(string roleName)
    {
      throw new NotImplementedException();
    }

    public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
    {
      throw new NotImplementedException();
    }

    public override string[] FindUsersInRole(string roleName, string usernameToMatch)
    {
      throw new NotImplementedException();
    }

    public override string[] GetAllRoles()
    {
      throw new NotImplementedException();
    }

    public override string[] GetRolesForUser(string username)
    {
      using (SMMDbContext ctx = new SMMDbContext())
      {
        User user = ctx.Users.FirstOrDefault(u => u.username == username);
        if (user == null)
          return new string[] { };
         return new string[] { user.type.ToString() };
      }
    }

    public override string[] GetUsersInRole(string roleName)
    {
      throw new NotImplementedException();
    }

    public override bool IsUserInRole(string username, string roleName)
    {
      using(SMMDbContext ctx = new SMMDbContext()) {
        User user = ctx.Users.SingleOrDefault(u => u.username == username);
        return user.type.ToString() == roleName;
      }
    }

    public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
    {
      throw new NotImplementedException();
    }

    public override bool RoleExists(string roleName)
    {
      throw new NotImplementedException();
    }
  }
}
