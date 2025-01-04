using System.ComponentModel.DataAnnotations;

namespace AgateProject.Data.Models
{
    public class ClientContact
    {
        [Key]
        public int ClientContactID { get; set; }
        public string? ClientContactName { get; set; }
        public int ClientID { get; set; }
    }
}
