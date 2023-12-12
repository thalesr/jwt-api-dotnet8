using RestaurantManager.Business.Definitions;
using RestaurantManager.Business.Implementations.Base;
using RestaurantManager.Database.UOW;
using RestaurantManager.Model.Entities;

namespace RestaurantManager.Business.Implementations
{
    public class UserBusiness : GenericBusiness<User>, IUserBusiness
    {
        public UserBusiness(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<User> Authenticate(string login, string password)
        {
            var user = await Repository.Get(expression: query => query.Login.Equals(login)
                                                     && query.Password.Equals(password));
            return user;
        }

    }
}
