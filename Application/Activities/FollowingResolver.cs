using System.Linq;
using Application.interfaces;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class FollowingResolver : IValueResolver<UserActivity, AttendeeDTO, bool>
    {
        private readonly DataContext _context;
        private readonly IUserAccessor _userAccesor;
        public FollowingResolver(DataContext context, IUserAccessor userAccesor)
        {
            _userAccesor = userAccesor;
            _context = context;
        }

        public bool Resolve(UserActivity source, AttendeeDTO destination, bool destMember, ResolutionContext context)
        {
            var currentUser = _context.Users.SingleOrDefaultAsync(x => x.UserName == _userAccesor.GetCurrentUsername()).Result;

            if(currentUser.Followings.Any(x => x.TargetId == source.AppUserId))
            return true;

            return false;
        }
    }
}