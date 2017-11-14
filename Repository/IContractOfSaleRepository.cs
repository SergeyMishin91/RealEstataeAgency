using System.Collections.Generic;
using Model;

namespace Repository
{
    public interface IContractOfSaleRepository
    {
        IEnumerable<ContractOfSale> GetAll();
        void AddContractOfSale(ContractOfSale estate);
        void UpdateContractOfSale(ContractOfSale estate);
        void DeleteContractOfSale(ContractOfSale estate);
    }
}
