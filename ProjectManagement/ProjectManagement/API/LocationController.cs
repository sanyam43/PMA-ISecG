using ProjectManagement.BL;
using ProjectManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectManagement.API
{
    public class LocationController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<LocationInfo> Get()
        {

            LocationInfo[] ListOfLocations = LocationBl.GetAllLocations();

            var location = from c in ListOfLocations
                           select c;


            return location.ToList();

        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}