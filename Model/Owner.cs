using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Owner
    {
        public int OwnerID { get; set; }
        public string OwnerName { get; set; }
        public int OwnerUNP { get; set; }
        public string OwnerAdress { get; set; }
        public int OwnerContractOfSaleID { get; set; }
        public string OwnerPhone { get; set; }
        public string OwnerContractOfSaleNumber { get; set; }
    }
}
