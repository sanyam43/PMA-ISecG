using ProjectManagement.Model;
using ProjectManagement.SPHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.DAL
{
    public class LocationDal
    {
        public static LocationInfo[] GetAllLocations()
        {
            ArrayList al = new ArrayList();

            int retValue = -1;


            //Generated Code for query : dbo.GetAllVendors
            using (SqlDataReader dr = ProjManagementAdmin.GetAllLocations(out retValue)) //Initialize and retrieve code for Datareader goes here
            {

                while (dr.Read())
                {
                    LocationInfo location = new LocationInfo();

                    location.LocationName = dr["location_name"].ToString();
                    location.CreatedDate = Convert.ToDateTime(dr["created_date"]);
                    location.ChangedDate = Convert.ToDateTime(dr["changed_date"]);
                    location.ChangedBy = dr["changed_by"].ToString();

                    al.Add(location);
                }
                //dr.Close();
            }

            LocationInfo[] allInfo = new LocationInfo[al.Count];
            al.CopyTo(allInfo);
            return allInfo;
        }
    }
}
