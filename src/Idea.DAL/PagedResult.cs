using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Idea.Models.Entities;

namespace Idea.DAL
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Collection { get; set; }
        public Int32 CurrentPage { get; set; }
        public Int32 TotalPages { get; set; }
        public Int32 NumberOfRegisters { get; set; }

    }
}
