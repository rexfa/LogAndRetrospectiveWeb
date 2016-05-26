using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain;
namespace Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.Subjects
{
    public class Subject : BaseEntity
    {
        public string SubjectName { get; set; }
        public int SubjectTypeId { get; set; }

        public List<Flows.FlowCustomerMapping> Observers { get; set; }

        public List<Media.Picture> Pictures { get; set; }
        public List<Locations.Location> Locations { get; set; }
    }
}
