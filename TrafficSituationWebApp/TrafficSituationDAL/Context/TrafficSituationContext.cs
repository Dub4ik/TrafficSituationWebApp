using System;
using System.Collections.Generic
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficSituationDAL.Entities;

namespace TrafficSituationDAL.Context
{
    class TrafficSituationContext:DbContext
    {
        public TrafficSituationContext()
        {
            //TODO: решить траблы с инициализатором
        }

        public DbSet<Country> Countries{ get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Street> Streets{ get; set; }
        public DbSet<TrafficSituationReport> TrafficSituationReports { get; set; }
        public DbSet<Accident> Accidents { get; set; }
        public DbSet<ManuallyGeneratedData> ManuallyGeneratedDataDbSet { get; set; }
        public DbSet<AutomaticallyGeneratedData> AutomaticallyGeneratedDataDbSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
