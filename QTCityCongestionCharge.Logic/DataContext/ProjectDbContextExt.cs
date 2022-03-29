namespace QTCityCongestionCharge.Logic.DataContext
{
    partial class ProjectDbContext
    {
        public DbSet<Entities.Owner>? OwnerSet { get; set; }
        public DbSet<Entities.Car>? CarSet { get; set; }
        public DbSet<Entities.Detection>? DetectionSet { get; set; }
        public DbSet<Entities.Payment>? PaymentSet { get; set; }

        partial void GetDbSet<E>(ref DbSet<E>? dbSet, ref bool handled) where E : Entities.IdentityEntity
        {
            if (typeof(E) == typeof(Entities.Owner))
            {
                handled = true;
                dbSet = OwnerSet as DbSet<E>;
            }
            else if (typeof(E) == typeof(Entities.Car))
            {
                handled = true;
                dbSet = CarSet as DbSet<E>;
            }
            if (typeof(E) == typeof(Entities.Detection))
            {
                handled = true;
                dbSet = DetectionSet as DbSet<E>;
            }
            if (typeof(E) == typeof(Entities.Payment))
            {
                handled = true;
                dbSet = PaymentSet as DbSet<E>;
            }
        }
    }
}
