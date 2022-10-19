using ECommerceAPI.Models;

namespace ECommerceAPI.Repository
{
    public interface IUser
    {
        public string AddUserDetails(UserDetails userDetails);//SaveDetails Function 
        
        public string EditUserDetails(UserDetails userDetails);//UpdateDetails function

        public string DeleteUserDetails(int UserId);  //DeleteDetails Function

        List<UserDetails> GetAllUserDetails();//DisplayDetails Function

        UserDetails GetUserDetailsbyId(int UserId);//DisplayDetails Function using id parameter

        UserDetails GetUserDetailsbyEmail(string Email);//DisplayDetails Function using email parameter for login function
    }
}
