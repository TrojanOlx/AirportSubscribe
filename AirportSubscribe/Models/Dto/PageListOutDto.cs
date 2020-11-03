using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportSubscribe.Models.Dto
{
    public class PageListOutDto<T> : List<T>
    {
        public PageListOutDto(List<T> list, int pageIndex, int pageSize, int sumCount, string key)
        {
            this.AddRange(list);
            SumCount = sumCount;
            PageIndex = pageIndex;
            PageSize = pageSize;
            Key = key;
        }

        public int SumCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Key { get; set; }
    }
}
