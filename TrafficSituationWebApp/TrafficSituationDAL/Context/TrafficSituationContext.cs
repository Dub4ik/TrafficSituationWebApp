using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficSituationDAL.Entities;
using TrafficSituationDAL.EntityConfigurations;

namespace TrafficSituationDAL.Context
{
    public class TrafficSituationContext:DbContext
    {
        public TrafficSituationContext():base("TrafficSituation")
        {
            //TODO: решить траблы с инициализатором
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TrafficSituationContext>());
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
            modelBuilder.Configurations.Add(new AccidentConfiguration());
            modelBuilder.Configurations.Add(new AutomaticallyGeneratedDataConfiguration());
            modelBuilder.Configurations.Add(new CityConfiguration());
            modelBuilder.Configurations.Add(new CountryConfiguration());
            modelBuilder.Configurations.Add(new ManuallyGeneratedDataConfiguration());
            modelBuilder.Configurations.Add(new TrafficSituationReportConfiguration());
        }

    }
}
