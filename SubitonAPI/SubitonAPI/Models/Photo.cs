using System;

namespace SubitonAPI.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string  Url { get; set; }
        public int OrderNr { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        public int set_user_nrid { get; set; }
    }
}