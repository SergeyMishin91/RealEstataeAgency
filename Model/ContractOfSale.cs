using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ContractOfSale
    {
        public int  ContractOfSaleID { get; set; }
        public int EstateBuyerID { get; set; }
        public int EstateOwnerID { get; set; }
        public int EstateID { get; set; }
        public string ContractOfSaleNumber { get; set; }
        public DateTime ContractOfSaleDate { get; set; }
        public string ContractOfSaleOwner { get; set; }
        public string ContractOfSaleBuyer { get; set; }
        public double ContractOfSaleCost { get; set; }
    }
}
