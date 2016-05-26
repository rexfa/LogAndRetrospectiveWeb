using System;
using System.Collections.Generic;

namespace Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.Media
{
    public class Picture :BaseEntity
    {
        public byte[] PictureBinary { get; set; }
        public int SubjectId { get; set; }
        public int ActionLogId { get; set; }
        public int CustomerId { get; set; }

        public virtual Customers.Customer Customer { get; set; }
        public virtual ActionLogs.ActionLog ActionLog { get; set; }
        public virtual Subjects.Subject Subject { get; set; }
    }
}
