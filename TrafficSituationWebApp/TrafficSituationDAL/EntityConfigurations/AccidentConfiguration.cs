using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficSituationDAL.Entities;

namespace TrafficSituationDAL.EntityConfigurations
{
    class AccidentConfiguration:EntityTypeConfiguration<Accident>
    {
        public AccidentConfiguration()
        {
            HasRequired(accident => accident.Street)
                .WithMany(street => street.Accidents)
                .HasForeignKey(streetFK => streetFK.StreetId);

            Property(accident => accident.Description).IsRequired();
    }
    }
}
