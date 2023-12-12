using RestaurantManager.Business.Definitions.Base;
using RestaurantManager.Model.Entities;

namespace RestaurantManager.Business.Definitions
{
    public interface IUserBusiness : IGenericBusiness<User>
    {
        Task<User> Authenticate(string login, string password);
    }
}
