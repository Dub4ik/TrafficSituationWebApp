using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficSituationDAL.Entities;

namespace TrafficSituationDAL.EntityConfigurations
{
    public class CityConfiguration:EntityTypeConfiguration<City>
    {
        public CityConfiguration()
        {
            HasRequired(city => city.Country)
                .WithMany(country => country.Cities)
                .HasForeignKey(cityFK => cityFK.CountryId);
        }
    }
}
