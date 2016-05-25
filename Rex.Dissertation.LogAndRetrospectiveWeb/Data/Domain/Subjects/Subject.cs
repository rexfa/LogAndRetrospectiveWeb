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
    }
}
