

using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Attachment
    {
        public int AttchmentID { get; set; }
        public string filename { get; set; }
        public string ServerFileName { get; set; }
        public int filesize { get; set; }


        public DateTime CreatedDate { get; set; }
        [ForeignKey(nameof(Ticket))]
        public int? TicketID { get; set; }
        public Ticket Ticket { get; set; }


        [ForeignKey(nameof(Disscussion))]
        public int? DisscussionID { get; set; }
        public Disscussion Disscussion { get; set; }


    }
}
