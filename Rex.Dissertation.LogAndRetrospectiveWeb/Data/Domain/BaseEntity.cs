using System;
using Microsoft.EntityFrameworkCore;
namespace Rex.Dissertation.LogAndRetrospectiveWeb.Data.Domain
{
    public class BaseEntity
    {
        /// <summary>
        /// 获取和设置实体的标识符
        /// </summary>
        public int Id { get; set; }
    }
}
