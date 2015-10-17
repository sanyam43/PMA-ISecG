using ProjectManagement.DAL;
using ProjectManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.BL
{
    public class LocationBl
    {
        public static LocationInfo[] GetAllLocations()
        {
            LocationInfo[] locationInfo = LocationDal.GetAllLocations();
            return locationInfo;

        }
    }
}
