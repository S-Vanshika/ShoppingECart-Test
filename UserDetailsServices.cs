using ECommerceAPI.Data;
using ECommerceAPI.Models;
using ECommerceAPI.Repository;

namespace ECommerceAPI.Services
{
    public class UserDetailsServices
    {
        private IUser _userDetailsRepository;

        //UserDetailsServices Constructor
        public UserDetailsServices(IUser userDetailsRepository)
        {
            _userDetailsRepository = userDetailsRepository;
        }

        //Display AllUserDetails
        public List<UserDetails> GetAllUserDetails()
        {
            return _userDetailsRepository.GetAllUserDetails();
        }

        //Display UserDetails using ID
        public UserDetails GetUserDetailsbyId(int UserId)
        {
            return _userDetailsRepository.GetUserDetailsbyId(UserId);
        }

        //Display UserDetails using Email
        public UserDetails GetUserDetailsbyEmail(string Email)
        {
            return _userDetailsRepository.GetUserDetailsbyEmail(Email);
        }


        //SaveDetails Function
        public string AddUserDetails(UserDetails userDetails)
        {
            return _userDetailsRepository.AddUserDetails(userDetails);
        }

        //UpdateDetails function
        public string EditUserDetails(UserDetails userDetails)
        {
            return _userDetailsRepository.EditUserDetails(userDetails);
        }

        //DeleteDetails Function
        public string DeleteUserDetails(int UserId)
        {
            return _userDetailsRepository.DeleteUserDetails(UserId);
        }
    }
}
