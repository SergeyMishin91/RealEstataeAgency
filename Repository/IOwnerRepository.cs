using System.Collections.Generic;
using Model;

namespace Repository
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> GetAll();
        void AddOwner(Owner owner);
        void UpdateOwner(Owner owner);
        void DeleteOwner(Owner owner);
    }
}
