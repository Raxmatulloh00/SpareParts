using Actions.CountryDataStore;
using Info.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStoreInMemory.Country
{
    public class StreetRepository : IStreetRepository
    {
        private List<Street> streets;

        public StreetRepository()
        {
            streets = new List<Street>()
            {
                new Street {StreetId = 1, DistrictConnectId = 1, StreetName = "Фарход бозори"},
            };
        }

        public void AddStreet(Street street)
        {
            if (streets.Any(a => a.StreetName.Equals(street.StreetName, StringComparison.OrdinalIgnoreCase))) return;

            if (streets != null && streets.Count > 0)
            {
                var maxId = streets.Max(m => m.StreetId);
                street.StreetId = maxId + 1;
            }
            else
            {
                street.StreetId = 1;
            }

            streets.Add(street);
        }

        public void DeleteStreet(int streetid)
        {
            streets.Remove(GetStreetById(streetid));
        }

        public void EditStreet(Street street)
        {
            var streatToEdit = GetStreetById(street.StreetId);
            if (streatToEdit != null)
            {
                streatToEdit.StreetName = street.StreetName;
                streatToEdit.DistrictConnectId = street.DistrictConnectId;
            }
        }

        public IEnumerable<Street> GetStreet()
        {
            return streets;
        }

        public Street GetStreetById(int streetid)
        {
            return streets.FirstOrDefault(f => f.StreetId == streetid);
        }
    }
}
