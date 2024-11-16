using Actions.CountryDataStore;
using Info.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStoreInMemory.Country
{
    public class CityRepository : ICityRepository
    {
        private List<City> cities;

        public CityRepository()
        {
            cities = new List<City>()
            {
                new City { Id = 1, CityName= "Тошкент"},
                new City { Id = 2, CityName= "Бухоро"},
                new City { Id = 3, CityName= "Хива"},
            };
        }

        public void AddCity(City city)
        {
            if (cities.Any(a => a.CityName.Equals(city.CityName, StringComparison.CurrentCultureIgnoreCase))) return;

            if (cities != null && cities.Count > 0)
            {
                var maxId = cities.Max(a => a.Id);
                city.Id = maxId + 1;
            }
            else
            {
                city.Id = 1;
            }

            cities.Add(city);
        }

        public void DeleteCity(int cityid)
        {
            cities?.Remove(GetCityById(cityid));
        }

        public void EditCity(City city)
        {
            var cityToEdit = GetCityById(city.Id);
            if (cityToEdit != null)
            {
                cityToEdit.CityName = city.CityName;
            }
        }

        public IEnumerable<City> GetCity()
        {
            return cities;
        }

        public City GetCityById(int cityid)
        {
            return cities.FirstOrDefault(f => f.Id == cityid);
        }

    }
}
