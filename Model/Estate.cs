using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Estate
    {
        public int EstateID { get; set; }
        public string EstateName { get; set; }
        public string EstateInventoryNumber { get; set; }
        public double EstateSpace { get; set; }
        public string EstateAdress { get; set; }
        public byte[] EstatePhoto { get; set; }
        public string EstateFunction { get; set; }
        public int EstateYear { get; set; }
        public string EstateWall { get; set; }
        public string EstateState { get; set; }
        public string EstateOwner { get; set; }
        public double EstateRentPrice { get; set; }
        public double EstateCostOfSale { get; set; }
        public string EstateDescription { get; set; }
        public string EstateDeal { get; set; }
    }
}
