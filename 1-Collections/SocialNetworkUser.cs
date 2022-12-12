using System.Collections.Generic;
using System.Linq;

namespace Collections
{
    public class SocialNetworkUser<TUser> : User, ISocialNetworkUser<TUser>
        where TUser : IUser
    {
        private readonly Dictionary<string, List<TUser>> _followedUsers = new();

        public SocialNetworkUser(string fullName, string username, uint? age) : base(fullName, username, age)
        {
        }

        public bool AddFollowedUser(string group, TUser user)
        {
            // Trying to get the reference to the list contained as the Dictionary value.
            if (_followedUsers.TryGetValue(group, out var list))
            {
                if (list.Contains(user)) return false;
                list.Add(user);
                return true;
            }

            // Initialising list for the first time.
            _followedUsers.Add(group, new List<TUser> {user});
            return true;
        }

        public IList<TUser> FollowedUsers => _followedUsers.Values.ToList() as IList<TUser>;

        public ICollection<TUser> GetFollowedUsersInGroup(string group) =>
            _followedUsers.ContainsKey(group) ? _followedUsers[group] : new List<TUser>();
    }
}
