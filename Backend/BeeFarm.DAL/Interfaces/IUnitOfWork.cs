using BeeFarm.DAL.Entity;
using BeeFarm.DAL.Identity;

namespace BeeFarm.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<BeeGarden> BeeGardens { get; }
        IRepository<Beehive> Beehives { get; }
        IRepository<Statistics> Statistics { get; }
        IRepository<User> Users { get; } //??
        UserManager UserManager { get; }
        void Save();
    }
}
