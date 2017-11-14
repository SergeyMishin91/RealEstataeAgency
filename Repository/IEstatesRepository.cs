using Model;
using System.Collections.Generic;

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
