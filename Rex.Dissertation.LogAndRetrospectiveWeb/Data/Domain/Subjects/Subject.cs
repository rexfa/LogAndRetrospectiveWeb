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
        public virtual SubjectType SubjectType { get;set;}
        public string Description { get; set; }
        public string Tags { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime DeletedOn { get; set; }
        public bool IsDelete { get; set; }
        public List<Flows.FlowSubjectMapping> Observers { get; set; }

        public List<Media.Picture> Pictures { get; set; }
        public List<Locations.Location> Locations { get; set; }
        public List<ActionLogs.ActionLog> ActionLogs { get; set; }
    }
}

