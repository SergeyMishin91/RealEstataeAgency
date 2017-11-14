using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public interface IBuyerRepository
    {
        IEnumerable<Buyer> GetAll();
        void AddBuyer(Buyer estate);
        void UpdateBuyer(Buyer estate);
        void DeleteBuyer(Buyer estate);
    }
}
