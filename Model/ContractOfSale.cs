using System;

namespace Model
{
    public class ContractOfSale
    {
        public int  ContractOfSaleID { get; set; }
        public int ContractOfSaleBuyerID { get; set; }
        public int ContractOfSaleOwnerID { get; set; }
        public string ContractOfSaleNumber { get; set; }
        public DateTime ContractOfSaleDate { get; set; }
        public string ContractOfSaleOwner { get; set; }
        public string ContractOfSaleBuyer { get; set; }
        public double ContractOfSaleCost { get; set; }
    }
}
