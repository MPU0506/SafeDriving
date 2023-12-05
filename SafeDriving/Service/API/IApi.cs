using SafeDriving.Models;

namespace SafeDriving.Service.API
{
    public interface IApi
    {
        Task<Schedule> GetSchedule(string groupName);

        void SetAuthToken(string authToken);
    }
}
