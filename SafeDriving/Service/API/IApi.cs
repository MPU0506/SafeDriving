using SafeDriving.Models;

namespace SafeDriving.Service.API
{
    public interface IApi
    {
        Task<Schedule> GetSchedule(string groupName);

        Task<User> GetUser(string name, string password);

        void SetAuthToken(string authToken);
    }
}
