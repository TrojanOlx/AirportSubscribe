using AirportSubscribe.Models;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AirportSubscribe.Servers.Urls
{
    public class AddAirportUrl
    {
        public class AddAipportUrlCommand : IRequest<bool>
        {
            public string UrlName { get; set; }
            public string UrlString { get; set; }
            public UrlTypeEnum UrlType { get; set; } = UrlTypeEnum.V2ray;
        }

        public class Handler : IRequestHandler<AddAipportUrlCommand, bool>
        {
            private readonly AirportContext _context;
            private readonly IMapper _mapper;

            public Handler(AirportContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<bool> Handle(AddAipportUrlCommand message, CancellationToken cancellationToken)
            {
                var urlModel = _mapper.Map<UrlModel>(message);
                urlModel = (await _context.UrlModels.AddAsync(urlModel)).Entity;
                try
                {
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                
            }
        }

    }
}
