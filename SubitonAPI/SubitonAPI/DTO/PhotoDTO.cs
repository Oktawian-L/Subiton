using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubitonAPI.DTO
{
    public class PhotoDTO
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int OrderNr { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        public int Set_user_nrid { get; set; }
    }
}

