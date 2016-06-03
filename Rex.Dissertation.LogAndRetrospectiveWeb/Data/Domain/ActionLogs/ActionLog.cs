using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
namespace Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.ActionLogs
{
    public class ActionLog : BaseEntity
    {
        public string Message { get; set; }
        public int CustomerId { get; set; }
        public int SubjectId { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<Media.Picture> Pictures { get; set; }
        public virtual Customers.Customer Customer { get; set; }
        public virtual Subjects.Subject Sunject { get; set; }

    }
}
