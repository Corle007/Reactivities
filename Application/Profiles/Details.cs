
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Profiles
{
    public class Details
    {
        public class Query : IRequest<Profile>
        {

            public string Username { get; set; }
        }

        public class Handler : IRequestHandler<Query, Profile>
        {
            private readonly DataContext _context;
            private readonly IProfileReader _profilereader;
            public Handler(IProfileReader profilereader)
            {
                _profilereader = profilereader;


            }

            public async Task<Profile> Handle(Query request, CancellationToken cancellationToken)
            {

                return await _profilereader.ReadProfile(request.Username);
            }
        }
    }
}