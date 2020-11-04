using AirportSubscribe.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AirportSubscribe.Servers.Urls
{
    public class GetSubscribe
    {

        public class GetSubscribeQuery : IRequest<string>
        {

        }

        public class Handler : IRequestHandler<GetSubscribeQuery, string>
        {
            private readonly AirportContext _context;
            private readonly IMapper _mapper;

            public Handler(AirportContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<string> Handle(GetSubscribeQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var list = _context.UrlModels.ToList();

                    var str = string.Join(Environment.NewLine, list.Select(s => s.UrlString));

                    byte[] bytes = Encoding.Default.GetBytes(str);

                    return Convert.ToBase64String(bytes);
                }
                catch (Exception ex)
                {

                    throw;
                }
                
            }
        }
    }
}
