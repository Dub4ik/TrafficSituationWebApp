using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficSituationDAL.Entities;

namespace TrafficSituationBLL
{
    public class ReportGenerator
    {
        const int intervalCount = 12; //Временная мера
        //Всего 12 интервалов с шагом 5
        public int GetInterval(double value)
        {
            if (value>=0.0 && value<30.0)
            {
                if (value>=0.0 && value<15.0)
                {
                    if (value>=0.0 && value<10.0)
                    {
                        if (value<5.0)
                        {
                            return 1;
                        }
                        else
                        {
                            return 2;
                        }
                    }
                    else
                    {
                        return 3;
                    }
                }
                else
                {
                    if (value>=15.0 && value<25.0)
                    {
                        if (value<20.0)
                        {
                            return 4;
                        }
                        else
                        {
                            return 5;
                        }
                    }
                    else
                    {
                        return 6;
                    }
                }
            }
            else
            {
                if (value >= 30.0 && value < 45.0)
                {
                    if (value >= 30.0 && value < 40.0)
                    {
                        if (value < 35.0)
                        {
                            return 7;
                        }
                        else
                        {
                            return 8;
                        }
                    }
                    else
                    {
                        return 9;
                    }
                }
                else
                {
                    if (value >= 45.0 && value < 55.0)
                    {
                        if (value < 50.0)
                        {
                            return 10;
                        }
                        else
                        {
                            return 11;
                        }
                    }
                    else
                    {
                        return 12;
                    }
                }
            }
        }
        public TrafficSituationReport Generate(List<AutomaticallyGeneratedData> dataList)
        {
            if (dataList.Count!=0)
            {
                int[] counters = new int[12];

                foreach (var data in dataList)
                {
                    counters[GetInterval(data.Speed) - 1]++;
                }

                var maxCounter = 0;
                for (int i = 0; i < counters.Length; i++)
                {
                    if (counters[i] > maxCounter)
                    {
                        maxCounter = counters[i];
                    }
                }

                int streetId = dataList[0].StreetId;
                int trafficLevel = 10 - (maxCounter / 12 * 10);
                var report = new TrafficSituationReport()
                {
                    TrafficLevel = (byte)trafficLevel,
                    DataOfGeneration = DateTime.Now,
                    Streetid = streetId
                };

                return report;
            }
            else
            {
                return null;
            }
            
        }
    }
}
