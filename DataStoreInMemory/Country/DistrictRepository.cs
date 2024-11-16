using Actions.CountryDataStore;
using Info.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStoreInMemory.Country
{
    public class DistrictRepository : IDistrictRepository
    {
        private List<District> districts;

        public DistrictRepository()
        {
            districts = new List<District>()
            {
                new District {DistrictId= 1, CityConnetId = 1, DistrictName="Учтепа тумани" },
                new District {DistrictId= 2, CityConnetId = 2, DistrictName="Шофиркон" },
                new District {DistrictId= 3, CityConnetId = 3, DistrictName="Урганч" },
            };
        }

        public void AddDistrict(District district)
        {
            if (districts.Any(a => a.DistrictName.Equals(district.DistrictName, StringComparison.OrdinalIgnoreCase))) return;

            if (districts != null && districts.Count > 0)
            {
                var maxId = districts.Max(a => a.DistrictId);
                district.DistrictId = maxId + 1;
            }
            else
            {
                district.DistrictId = 1;
            }

            districts.Add(district);
        }

        public void DeleteDistrict(int districtid)
        {
            districts.Remove(GetDistrictById(districtid));
        }

        public void EditDistrict(District district)
        {
            var districtToEdit = GetDistrictById(district.DistrictId);
            if (districtToEdit != null)
            {
                districtToEdit.DistrictName = district.DistrictName;
                districtToEdit.CityConnetId = district.DistrictId;
            }
        }

        public IEnumerable<District> GetDistrict()
        {
            return districts;
        }

        public District GetDistrictById(int districtid)
        {
            return districts.FirstOrDefault(f => f.DistrictId == districtid);
        }
    }
}
