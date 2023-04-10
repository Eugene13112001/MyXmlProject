using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyXmlProject.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public double Sum { get; set; }
        public DateTime Date { get; set; }

        public int UserId { get; set; }
        
        public User User { get; set; }
       
        public List<SalesOfOrder> SalesOfOrder { get; set; }
    }
}
