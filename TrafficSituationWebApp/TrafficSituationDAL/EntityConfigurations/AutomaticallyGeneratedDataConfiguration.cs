using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficSituationDAL.Entities;

namespace TrafficSituationDAL.EntityConfigurations
{
    class AutomaticallyGeneratedDataConfiguration:EntityTypeConfiguration<AutomaticallyGeneratedData>
    {
        public AutomaticallyGeneratedDataConfiguration()
        {
            HasRequired(agd => agd.Street)
                .WithMany(street => street.AutomaticallyGeneratedDataList)
                .HasForeignKey(agdFK => agdFK.StreetId);
        }
    }
}
