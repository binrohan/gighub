using GigHub.Models;
using System.Collections.Generic;

namespace GigHub.Repositories
{
    public interface IFollowingRepository
    {
        Following GetFollowing(string userId, string artistId);
        IEnumerable<ApplicationUser> GetFollowees(string userId);
    }
}