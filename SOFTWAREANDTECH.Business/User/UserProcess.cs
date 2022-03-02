using System.Linq;
using System.Collections.Generic;

using SOFTWAREANDTECH.Entities.DTOs;
using SOFTWAREANDTECH.Entities.Models;

using SOFTWAREANDTECH.DataAccess.DA;

namespace SOFTWAREANDTECH.Business.User
{
    public class UserProcess
    {
        #region "Variables..."
        DAProcess<MUser, UserDTO> da;
        #endregion

        public UserProcess()
        { da = new DAProcess<MUser, UserDTO>(); }

        public List<MUser> GetUserList(UserDTO obj)
        {
            try
            {
                var result = da.ObtieneLista("spr_user", obj);

                return result.Cast<MUser>().ToList();
            }
            catch
            { throw; }
        }

        public bool ProcesaInformacion(UserDTO obj)
        {
            try
            {
                bool result = da.EjecutaProceso("sp_userprocess", obj);

                return result;
            }
            catch
            { throw; }
        }

        public bool DeleteUser(UserDTO obj)
        {
            bool result = da.EjecutaProceso("spd_user", obj);

            return result;
        }
    }
}