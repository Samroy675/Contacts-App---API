using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace contacts_app.Models
{
    [Table("Contacts")]
    public class Contact
    {
        [Key] public int contactId { get; set; }
        [Required] public string contactName { get; set; }
        [Required] public long contactPhoneNo { get; set; }
        [Required] public string contactPhoto { get; set; }
    }
}
