using RestaurantManager.Model.Entities.Base;
using RestaurantManager.Model.Enums;

namespace RestaurantManager.Model.Entities
{
    public class User : BaseEntity
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public UserRoleEnum Role { get; set; }
    }
}
