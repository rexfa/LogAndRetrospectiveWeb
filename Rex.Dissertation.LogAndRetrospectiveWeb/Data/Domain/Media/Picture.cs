using System;
using System.Collections.Generic;

namespace Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain.Media
{
    public class Picture :BaseEntity
    {
        public byte[] PictureBinary { get; set; }
    }
}
