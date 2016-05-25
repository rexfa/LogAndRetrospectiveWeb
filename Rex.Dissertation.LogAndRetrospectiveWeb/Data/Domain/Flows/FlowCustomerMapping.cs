using System;
using System.Collections.Generic;
using Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.Customers;
namespace Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.Flows
{
    public class FlowCustomerMapping : BaseEntity
    {
        public virtual Customer ObserverCustomer { get; set; }
        public virtual Customer ProducerCustomer { get; set; }
        public int ObserverCustomerId { get; set; }
        public int ProducerCustomerId { get; set; }
        public int Tag { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
