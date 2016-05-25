using System;
using System.Collections.Generic;
using Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.Customers;
using Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.Subjects;
namespace Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.Flows
{
    public class FlowSubjectMapping : BaseEntity
    {
        public virtual Customer ObserverCustomer { get; set; }
        public virtual Subject ProducerSubject { get; set; }
        public int ObserverCustomerId { get; set; }
        public int ProducerSubjectId { get; set; }
        public int Tag { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
