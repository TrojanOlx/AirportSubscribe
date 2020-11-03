using AirportSubscribe.Models;
using AirportSubscribe.Models.Dto;
using AirportSubscribe.Models.UrlModels;
using AirportSubscribe.Models.UrlModels.Dto;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AirportSubscribe.Servers.Urls
{
    public class GetAirportUrlList
    {
        public class GetAirportUrlListQuery : IRequest<PageListOutDto<UrlModelOutDto>>
        {
            public int PageIndex { get; set; }
            public int PageSize { get; set; }
            public string Key { get; set; }
        }

        public class Handler : IRequestHandler<GetAirportUrlListQuery, PageListOutDto<UrlModelOutDto>>
        {
            private readonly AirportContext _context;
            private readonly IMapper _mapper;

            public Handler(AirportContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<PageListOutDto<UrlModelOutDto>> Handle(GetAirportUrlListQuery message, CancellationToken cancellationToken)
            {
                var query = _context
                            .UrlModels;

                var count = await query.CountAsync();

                Random ran = new Random();

                var list = await query
                            .OrderByDescending(o => o.CreateTime)
                            .Skip((message.PageIndex - 1) * message.PageSize)
                            .Take(message.PageSize)
                            .Select(s => new UrlModelOutDto
                            {
                                Id = s.Id,
                                UrlName = s.UrlName,
                                UrlString = s.UrlString,
                                UrlType = s.UrlType,
                                IconUrl = GetIconUrl(s.UrlType),
                                Speed = ran.Next(0, 5000),
                                CreateTime = s.CreateTime,
                                CreateUser = s.CreateUser,
                                LastUpdateTime = s.LastUpdateTime,
                                LastUpdateUser = s.LastUpdateUser
                            })
                            .ToListAsync();




                return new PageListOutDto<UrlModelOutDto>(list, message.PageIndex, message.PageSize, count, message.Key);
            }


            private static string GetIconUrl(UrlTypeEnum urlType) => urlType switch
            {
                UrlTypeEnum.V2ray => "http://images.oulongxing.com/Icon/V2ray.png",
                UrlTypeEnum.SSR => "http://images.oulongxing.com/Icon/SSR.png",
                UrlTypeEnum.SS => "http://images.oulongxing.com/Icon/SS.png",
                _ => "http://images.oulongxing.com/Icon/unknown.png"
            };

        }
    }
}
