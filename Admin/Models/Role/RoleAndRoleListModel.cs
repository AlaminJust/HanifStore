using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Admin.Models.Role
{
    public class RoleAndRoleListModel
    { 
        public RoleAndRoleListModel()
        {
            roleListModels = new List<RoleListModel>();
            roleModel = new RoleModel();
        }
        public RoleModel  roleModel { get; set; }
        public IList<RoleListModel> roleListModels { get; set; }
    }
}
