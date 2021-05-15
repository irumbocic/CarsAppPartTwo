using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Project.Common
{
    public interface IPaging<T>
    {

        public int? page { get; set; }

        public Task<IPagedList<T>> PagingListAsync(IQueryable<T> pagedModel);
    }
}
