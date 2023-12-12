using RestaurantManager.API.DTO.Base;
using RestaurantManager.Model.Enums;

namespace RestaurantManager.API.DTO
{

    public class CreateUserDTO : BaseCreateDTO
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public UserRoleEnum Role { get; set; }
    }

    public class UpdateUserDTO : BaseUpdateDTO
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public UserRoleEnum Role { get; set; }
    }

    public class UserDTO : BaseDTO
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public UserRoleEnum Role { get; set; }
    }

}
