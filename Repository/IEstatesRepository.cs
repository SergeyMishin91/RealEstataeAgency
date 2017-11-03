using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IEstatesRepository
    {
        IEnumerable<Estate> GetAll();
        void AddEstate (Estate estate);
        void UpdateEstate(Estate estate);
        void DeleteEstate(Estate estate);
    }
}
