using Microsoft.AspNetCore.Identity;

namespace Web_Hotel.Data
{
    public class RoleMenegerServise
    {
        readonly RoleManager<IdentityRole> _roleManager;

        public Dictionary<string, string> MyRoles { get; set; } = new Dictionary<string, string>();
        public RoleMenegerServise(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public  Dictionary<string, string> GetAllRoles()
            {
            MyRoles = new Dictionary<string, string>();
            var roles = _roleManager.Roles;
            foreach (var item in roles)
            {
                MyRoles.Add(item.Id, item.Name);
            }
            return MyRoles;
        }
    }
}
