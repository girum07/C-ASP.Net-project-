
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
namespace Domain.Entity
{
    public class Disscussion
    {
        public Disscussion()
        {
            Attachments = new HashSet<Attachment>();
        }
        public int DisscussionId { get; set; }
        public string Messsage { get; set; }
        public DateTime Created { get; set; }
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [ForeignKey(nameof(Ticket))]
        public int? TicketID { get; set; }
        public Ticket Ticket { get; set; }



        public virtual ICollection<Attachment> Attachments { get; set; }

    }
}
