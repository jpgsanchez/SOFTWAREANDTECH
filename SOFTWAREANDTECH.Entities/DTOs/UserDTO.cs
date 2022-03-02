using System;

namespace SOFTWAREANDTECH.Entities.DTOs
{
    public class UserDTO
    {
        public int? tuid { get; set; }

        public int? tgid { get; set; }

        public string email { get; set; }

        public string uname { get; set; }

        public string upwd { get; set; }

        public bool? ustatus { get; set; }

        public DateTime? creationdate { get; set; }
    }
}