using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficSituationDAL.Entities;

namespace TrafficSituationDAL.EntityConfigurations
{
    class ManuallyGeneratedDataConfiguration:EntityTypeConfiguration<ManuallyGeneratedData>
    {
        public ManuallyGeneratedDataConfiguration()
        {
            HasRequired(mgd => mgd.Street)
                .WithMany(street => street.ManuallyGeneratedDataList)
                .HasForeignKey(mgdFK => mgdFK.StreetId);
        }
    }
}
