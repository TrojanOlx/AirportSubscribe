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
    public class RemoveAirportUrl
    {

        public class RemoveAirportUrlCommand : IRequest<bool>
        {
            public RemoveAirportUrlCommand(int id)
            {
                Id = id;
            }

            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<RemoveAirportUrlCommand, bool>
        {
            private readonly AirportContext _context;
            private readonly IMapper _mapper;

            public Handler(AirportContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<bool> Handle(RemoveAirportUrlCommand message, CancellationToken cancellationToken)
            {
                var urlModel = await _context.UrlModels.FindAsync(message.Id);
                if (urlModel == null)
                {
                    return false;
                }
                else
                {
                    _context.UrlModels.Remove(urlModel);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
        }

    }
}
