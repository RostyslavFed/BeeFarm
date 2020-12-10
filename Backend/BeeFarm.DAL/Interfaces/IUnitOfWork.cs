using BeeFarm.DAL.Entity;

namespace BeeFarm.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<BeeGarden> BeeGardens { get; }
        IRepository<Beehive> Beehives { get; }
        IRepository<Statistic> Statistics { get; }
        IRepository<User> Users { get; }
        void Save();
    }
}
