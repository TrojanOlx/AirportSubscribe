using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportSubscribe.Models.Dto
{
    public class PageListOutDto<T> : List<T>
    {
        public PageListOutDto()
        {

        }
        public PageListOutDto(List<T> list, int pageIndex, int pageSize, int total, string key)
        {
            this.AddRange(list);
            Total = total;
            PageIndex = pageIndex;
            PageSize = pageSize;
            Key = key;
        }

        public int Total { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Key { get; set; }
    }
}
