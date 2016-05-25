using System;
using System.Collections.Generic;
namespace Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.Locations
{
    public class Location : BaseEntity
    {
        public int LocationTypeId { get; set; }
        public string LocationData { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
