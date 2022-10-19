using ECommerceAPI.Data;
using ECommerceAPI.Models;

namespace ECommerceAPI.Repository
{
    public class UserRepository: IUser
    {
        private ECommerceDbContext _eCommerceDbContext;


        //UserRepository Constructor
        public UserRepository(ECommerceDbContext eCommerceDbContext)
        {
            _eCommerceDbContext = eCommerceDbContext;
        }   

        //Display AllUserDetails
        public List<UserDetails> GetAllUserDetails()
        {
            //try catch blocks need to be added! for exception handling
            List<UserDetails> UserList = _eCommerceDbContext.UserDetails.ToList();
            return UserList;
        }

        //Display UserDetails using ID
        public UserDetails GetUserDetailsbyId(int UserId)
        {
            //try catch blocks need to be added for exception handling!
            UserDetails UserList = _eCommerceDbContext.UserDetails.Find(UserId);
            return UserList;
        }

        //Disply UserDetails using Email also used for Login Function
        public UserDetails GetUserDetailsbyEmail(string Email)
        {
            //try catch blocks need to be added for exception handling!
            UserDetails user = null;
            user = _eCommerceDbContext.UserDetails.FirstOrDefault(e => e.Email == Email) ;
            return user;
        }

        //SaveDetails Function
        public string AddUserDetails(UserDetails userDetails)
        {
            //try catch blocks need to be added for exception handling!
            _eCommerceDbContext.UserDetails.Add(userDetails);
            _eCommerceDbContext.SaveChanges();
            return "SAVED!";
        }

        //UpdateDetails function
        public string EditUserDetails(UserDetails userDetails)
        {
            //try catch blocks need to be added for exception handling!
            _eCommerceDbContext.Entry(userDetails).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _eCommerceDbContext.SaveChanges();
            return "UPDATED!";
        }

        //DeleteDetails Function
        public string DeleteUserDetails(int UserId)
        {
            //try catch blocks need to be added for exception handling!
            string message = "";
            UserDetails DeleteUser = _eCommerceDbContext.UserDetails.Find(UserId);
            if(DeleteUser != null)
            {
                _eCommerceDbContext.UserDetails.Remove(DeleteUser);
                _eCommerceDbContext.SaveChanges();
                message = "DELETED!";
                return message;
            }
            return "Details Not Found";
        }
    }
}
