using System.Linq;
using System.Collections.Generic;

using SOFTWAREANDTECH.Entities.DTOs;

using SOFTWAREANDTECH.DataAccess.DA;

namespace SOFTWAREANDTECH.Business.Gender
{
    public class GenderProcess
    {
        #region "Variables..."
        DAProcess<GenderDTO, GenderDTO> da;
        #endregion

        public GenderProcess()
        { da = new DAProcess<GenderDTO, GenderDTO>(); }

        public List<GenderDTO> GetGenderList(GenderDTO obj = null)
        {
            try
            {
                var result = da.ObtieneLista("sps_gender", obj);

                return result.Cast<GenderDTO>().ToList();
            }
            catch
            { throw; }
        }
    }
}