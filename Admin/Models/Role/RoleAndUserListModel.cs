using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HanifStore.Admin.Models.Role
{
    public class RoleAndUserListModel
    {
        public RoleAndUserListModel()
        {
            roleListModel = new List<RoleListModel>();
            usersInformationModels = new List<UsersInformationModel>();
        }
        public IList<RoleListModel>  roleListModel { get; set; }
        public IList<UsersInformationModel> usersInformationModels { get; set; }
    }
}
