
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Domain.Entity
{
    public class Ticket
    {
        public Ticket()
        {
            Attachments = new HashSet<Attachment>();
        }

        public int TicketId { get; set; }
        public string Summary { get; set; }  
        public string Description { get; set; }
        public DateTime RaisedDate { get; set; }
        public DateTime ExpectedDate { get; set; }
      
        public User? AssignedtoUser { get; set; }
        public string RaisedBy { get; set; }
        [ForeignKey(nameof(RaisedBy))]
        public User? RaisedbyUser { get; set; }
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public int Category { get; set; }
        [ForeignKey(nameof(Category))]

        public int PriorityId { get; set; }
        [ForeignKey(nameof(PriorityId))]
        public Priority Priority { get; set; }

        public string Status { get; set; }

        public virtual ICollection<Attachment> Attachments { get; set; }


    }
}
