using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficSituationDAL.Entities;

namespace TrafficSituationDAL.EntityConfigurations
{
    class CountryConfiguration:EntityTypeConfiguration<Country>
    {
        public CountryConfiguration()
        {
            Property(c => c.Name).IsRequired();
        }
    }
}
