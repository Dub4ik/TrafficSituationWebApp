using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficSituationDAL.Context;
using TrafficSituationDAL.Entities;

namespace TrafficSituationDAL
{
    public class Repository
    {
        TrafficSituationContext context;

        public Repository()
        {
            context = new TrafficSituationContext();
        }

        public void AddCountry(string countryName)
        {
            context.Countries.Add(new Country() { Name = countryName });
            context.SaveChanges();
        }

        public void AddCity(string cityName, Country country)
        {
            context.Cities.Add(new City() { Name = cityName, Country = country });
            context.SaveChanges();
        }

        public void AddStreet(string streetName, City city)
        {
            context.Streets.Add(new Street() { Name = streetName, City = city });
            context.SaveChanges();
        }
        public void AddAutomaticallyGeneratedData(double speed, double acceleration, DateTime dateOfCreation, Street street)
        {
            context.AutomaticallyGeneratedDataDbSet.Add(new AutomaticallyGeneratedData()
            {
                Speed = speed,
                Acceleration = acceleration,
                DateOfCreation = dateOfCreation,
                StreetId = street.Id
            });
            context.SaveChanges();
        }

        public void AddTrafficSituationReport(TrafficSituationReport obj)
        {
            context.TrafficSituationReports.Add(obj);
            context.SaveChanges();
        }

        public void RemoveAGDRange(List<AutomaticallyGeneratedData> agdList)
        {
            context.AutomaticallyGeneratedDataDbSet.RemoveRange(agdList);
            context.SaveChanges();
        }

        public Country GetCountryByName(string countryName)
        {
            return context.Countries.FirstOrDefault(country => country.Name == countryName);
        }

        public City GetCity(string cityName, int countryId)
        {
            return context.Cities.FirstOrDefault(city => city.CountryId == countryId && city.Name == cityName);
        }

        public Street GetStreet(string streetName, int cityId)
        {
            return context.Streets.FirstOrDefault(street => street.CityId == cityId && street.Name == streetName);
        }

        public List<AutomaticallyGeneratedData> GetAutomaticallyGeneratedDataByStreetId(int id)
        {
            return context.AutomaticallyGeneratedDataDbSet.Where(agd => agd.StreetId == id).ToList();
        }

        #region Получение списков
        public List<Country> GetCountryList()
        {
            return context.Countries.ToList();
        }

        public List<City> GetCityList()
        {
            return context.Cities.ToList();
        }

        public List<City> GetCityListByCountry(string countryName)
        {
            return context.Cities.Where(city => city.Country.Name == countryName).ToList();
        }

        public List<Street> GetStreetList()
        {
            return context.Streets.ToList();
        }
        public Street GetStreetById(int id)
        {
            return context.Streets.FirstOrDefault(s => s.Id == id);
        }

        public List<Street> GetStreetListByCity(string cityName)
        {
            return context.Streets.Where(street => street.City.Name == cityName).ToList();
        }

        public List<TrafficSituationReport> GetTrafficSituationReportList()
        {
            return context.TrafficSituationReports.ToList();
        }

        public List<Accident> GetAccidentList()
        {
            return context.Accidents.ToList();
        }

        public List<ManuallyGeneratedData> GetManuallyGeneratedDataList()
        {
            return context.ManuallyGeneratedDataDbSet.ToList();
        }

        public List<AutomaticallyGeneratedData> GetAutomaticallyGeneratedDataList()
        {
            return context.AutomaticallyGeneratedDataDbSet.ToList();
        }

        public List<TrafficSituationReport> GetTrafficSituationReportList(int streetId, DateTime date)
        {
            return context.TrafficSituationReports.Where(tsr => tsr.Streetid == streetId
                                                            && tsr.DataOfGeneration == date).ToList();
        }

        public List<TrafficSituationReport> GetTrafficSituationReportListPerHour(int streetId, DateTime date)
        {
            TimeSpan hour = new TimeSpan(1, 0, 0);
            DateTime endDate = date + hour;
            return context.TrafficSituationReports.Where(tsr => tsr.Streetid == streetId
                                                            && tsr.DataOfGeneration >= date && tsr.DataOfGeneration<=endDate).ToList();
        }
        public List<TrafficSituationReport> GetTrafficSituationReportList(int streetId, DateTime dateFrom, DateTime dateTo)
        {
            return context.TrafficSituationReports.Where(tsr => tsr.Streetid == streetId 
                                                            && tsr.DataOfGeneration >= dateFrom 
                                                            && tsr.DataOfGeneration <= dateTo).ToList();
        }

        public List<TrafficSituationReport> GetTrafficSituationReportsFor(TimeSpan timeSpan)
        {
            DateTime forTime = DateTime.Now - timeSpan;
            return context.TrafficSituationReports.Where(tsr => tsr.DataOfGeneration <= DateTime.Now &&
                                                                tsr.DataOfGeneration >= forTime).ToList();
        }

        #endregion


        public void Add<T>(T entity) where T : Entity
        {
            context.Set<T>().Add(entity);
        }

        public void Delete<T>(T entity) where T : Entity
        {
            context.Set<T>().Remove(entity);
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }
    }
}
