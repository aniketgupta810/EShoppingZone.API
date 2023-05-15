using Microsoft.EntityFrameworkCore;
using ECommerceWeb.API.Data;
using ECommerceWeb.API.Models;
using ShoppingCart_API.Repository;


namespace ECommerceWeb.API.Repository
{
    public class UserRepo : IUser
    {
        private ECommerceApplicationContext _dbContext;


        #region UserRepo
         public UserRepo(ECommerceApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region GetAllUserDetails
     
        public List<UserDetails> GetAllUserDetails()
        {
            try
            {
                List<UserDetails> user = _dbContext.UserDetails.ToList();
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region GetuserDetails
        
        public UserDetails GetUserDetails(int UserId)
        {
            try
            {
                UserDetails user = _dbContext.UserDetails.Find(UserId);
                return user;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region SaveUserDetails
        
        public string SaveUserDetails(UserDetails userDetails)
        {
            string result = string.Empty;
            try
            {
                _dbContext.UserDetails.Add(userDetails);
                _dbContext.SaveChanges();
                result = "Saved";
            }
            catch (Exception e) { }

            finally { }
            return result;
        }
        #endregion

         #region UpdateUserDetails
       
        public string UpdateUserDetails(UserDetails userDetails)
        {
            try
            {
                _dbContext.Entry(userDetails).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return "Updated";
        }
        #endregion

         #region DeleteUserDetails
      

        public string DeleteUserDetails(int UserId)
        {
            string msg = "";
            UserDetails deleteUser = _dbContext.UserDetails.Find(UserId);
            try
            {
                if (deleteUser != null)
                {
                    _dbContext.UserDetails.Remove(deleteUser);
                    _dbContext.SaveChanges();
                    msg = "Deleted";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return msg;
        }
        #endregion
        #region GetUserByEmail
        
       
        public UserDetails GetUserbyEmail(string EmailId)
        {
            UserDetails user = null;
            try
            {
                user = _dbContext.UserDetails.FirstOrDefault(q => q.EmailId == EmailId);

            }
            catch (Exception)
            {
                throw;
            }
            return user;
        }
        #endregion







    }
}
