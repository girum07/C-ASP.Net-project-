using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Domain.Entity
{
    public class Ticket
    {
        public Ticket() {
            Attachments = new HashSet<Attachment>();
        }

        public int Id { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpectedDate { get; set; }
        public string AssignedtoId { get; set; }
        [ForeignKey(nameof(AssignedtoId))]
        public User? AssignedtoUser { get; set; }
        public string Raisedby { get; set; }
        [ForeignKey(nameof(Raisedby))]
        public User? RaisedbyUser { get; set; }
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public int CatagoryId { get; set; }
        [ForeignKey(nameof(CatagoryId))]

        public int PriortyId { get; set; }  
        [ForeignKey(nameof(PriortyId))]
        public Priorty priorty { get; set; }

        public string status { get; set; }  

        public virtual ICollection<Attachment> Attachments { get; set; }


    }
}
