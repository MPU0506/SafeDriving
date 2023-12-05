using SafeDriving.Models;
using SafeDriving.Service.API;

namespace SafeDriving.Service
{
    public class UserService
    {
        private static readonly string _authToken = "0IwGWvhf%2Bd9UGa7wkj8qTyAM8vW86T7HPzV11B9GNLvxMTZgPEFWacFk%2BbO2lmIVpB4FZl3gw4Gl4vqwmhv0ZvDpXNe5XGYCIDnXsxi%2Ba74OZq1SuJFcSdEIbJ43v4CU8zWhSl4Wn1MG8EJNUiwHDy75090t7ym31uBCuOR2OyY%3D\\";

        private User _user;
        public User Getuser() => _user;

        private readonly IApi _api;
        public UserService(IApi api)
        {
            _api = api;
        }

        public async Task<bool> Login(string name, string password)
        {
            // TODO: тут мы типа логиним пользователя, получаем токен и сохраняем его
            // code ...
            _api.SetAuthToken(_authToken);
            _user = await _api.GetUser(name, password);
            return true;
        }
    }
}
