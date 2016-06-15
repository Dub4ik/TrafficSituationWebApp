using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TrafficSituationDAL;
using TrafficSituationDAL.Context;
using TrafficSituationDAL.Entities;

namespace TrafficSituationBLL
{
    public class TrafficSituationDataManager
    {
        Repository repository;
        ReportGenerator reportGenerator;
        //TrafficSituationContext context;
        public TrafficSituationDataManager()
        {
            //context = new TrafficSituationContext();
            repository = new Repository();
            reportGenerator = new ReportGenerator();
        }

        public void AddStreetsToDataBase(string countryName, string cityName, string streetName)
        {
            Country country = repository.GetCountryByName(countryName);
            if (country == null)
            {
                throw new NullReferenceException();
            }

            City city = repository.GetCity(cityName, country.Id);
            if (city == null)
            {
                throw new NullReferenceException();
            }

            Street street = repository.GetStreet(streetName, city.Id);
            if (street == null)
            {
                repository.AddStreet(streetName, city);
            }
        }
        // Разбить на несколько методов
        public void AddAutomaticallyGeneratedData(string countryName, string cityName, string streetName,
            double speed, double acceleration, DateTime date)
        {
            Country country = repository.GetCountryByName(countryName);
            if (country == null)
            {
                throw new NullReferenceException();
            }

            City city = repository.GetCity(cityName, country.Id);
            if (city == null)
            {
                throw new NullReferenceException();
            }

            Street street = repository.GetStreet(streetName, city.Id);
            if (street == null)
            {
                throw new NullReferenceException();
            }

            repository.AddAutomaticallyGeneratedData(speed, acceleration, date, street);
        }

        public void AddTrafficReports()
        {
            var streetList = repository.GetStreetList();
            foreach(var street in streetList)
            {
                var agdForCurrentStreet //agd - automatically generated data
                    = repository.GetAutomaticallyGeneratedDataByStreetId(street.Id);
                var report = reportGenerator.Generate(agdForCurrentStreet);
                if (report!=null)
                {
                    repository.AddTrafficSituationReport(report);

                    RemoveUnnecessaryAutomaticallyData(agdForCurrentStreet);
                }
                
            }
        }

        private void RemoveUnnecessaryAutomaticallyData(List<AutomaticallyGeneratedData> agdList)
        {
            repository.RemoveAGDRange(agdList);
        }

        public void GenerateTestData()
        {
            for (int i = 0; i < 10; i++)
            {
                AddAutomaticallyGeneratedData("Ukraine", "Kharkiv", "Valeriia Chkalova vulytsia, 11", 53 + i, 0.0, DateTime.Now);
            }
            AddTrafficReports();
        }
        public string GetTestData ()
        {
            var country = repository.GetCountryList().FirstOrDefault();
            if (country == null)
            {
                return null;
            }
            return country.Name;
        }

        //TODO Решить проблему с точностью времени
        public List<TrafficData> GetTrafficDataForExactTime(string countryName, string cityName,
            string streetName, DateTime date)
        {
            List<TrafficData> resultList = new List<TrafficData>();

            int streetId = GetStreetId(countryName, cityName, streetName); 
            var reportList = repository.GetTrafficSituationReportList(streetId, date);
            foreach (var item in reportList)
            {
                resultList.Add(new TrafficData() { Date = item.DataOfGeneration, TrafficLevel = item.TrafficLevel });
            }
            return resultList;
        }

        public List<TrafficData> GetTrafficDataPerHour(string countryName, string cityName,
            string streetName, DateTime date)
        {
            List<TrafficData> resultList = new List<TrafficData>();

            int streetId = GetStreetId(countryName, cityName, streetName);
            var reportList = repository.GetTrafficSituationReportListPerHour(streetId, date);
            foreach (var item in reportList)
            {
                resultList.Add(new TrafficData() { Date = item.DataOfGeneration, TrafficLevel = item.TrafficLevel });
            }
            return resultList;
        }

        public int GetStreetId(string countryName, string cityName, string streetName)
        {
            Country country = repository.GetCountryByName(countryName);
            if (country == null)
            {
                throw new NullReferenceException();
            }

            City city = repository.GetCity(cityName, country.Id);
            if (city == null)
            {
                throw new NullReferenceException();
            }

            Street street = repository.GetStreet(streetName, city.Id);
            if (street == null)
            {
                throw new NullReferenceException();
            }
            return street.Id;
        }

        public List<RoadInformation> GetActualRoadInformation()
        {
            var reportsList = repository.GetTrafficSituationReportsFor(TimeSpan.FromMinutes(5));
            var resultList = new List<RoadInformation>();

            foreach (var report in reportsList)
            {
                resultList.Add(new RoadInformation
                {
                    TrafficLevel = report.TrafficLevel,
                    Geoposition = GetCoordinates(report.Streetid)
                });
            }

            return resultList;
        }

        public string GetCoordinates(int streetId)
        {
            var resultList = new List<BasicGeoposition>();

            Street street = repository.GetStreetById(streetId);

            if (street.Geolocation != string.Empty)
            {
                /*string pattern = @"\[(\d+.\d+)[^\d](\d+.\d+)\]";
                foreach (Match item in Regex.Matches(street.Geolocation, pattern))
                {
                    resultList.Add(new BasicGeoposition
                    {
                        Latitude = Convert.ToDouble(item.Groups[1].Value),
                        Longitude = Convert.ToDouble(item.Groups[2].Value),
                        Altitude = 0
                    });
                }*/

                return street.Geolocation;
            }
            else
            {
                //TODO: Переделать передачу координат
                return String.Empty;//Костыль
            }
        }
    }
}
