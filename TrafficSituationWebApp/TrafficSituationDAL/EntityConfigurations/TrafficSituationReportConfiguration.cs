using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficSituationDAL.Entities;

namespace TrafficSituationDAL.EntityConfigurations
{
    class TrafficSituationReportConfiguration:EntityTypeConfiguration<TrafficSituationReport>
    {
        public TrafficSituationReportConfiguration()
        {
            HasRequired(report => report.Street)
                .WithMany(street => street.TrafficSituationReports)
                .HasForeignKey(reportFK => reportFK.Streetid);
        }
    }
}
