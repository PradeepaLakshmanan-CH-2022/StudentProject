using Microsoft.EntityFrameworkCore;

namespace StudentProject.Models
{
    public class User
    {
        private angularprojectContext _context;

        public User()
        {

            _context = new angularprojectContext();
        }

        public Task<bool> AddUser(UserRegister userDetail)
        {

            _context.UserRegisters.Add(userDetail);
            _context.SaveChanges();
            return Task.FromResult(true);
        }
        public async Task<UserRegister> Authenticate(Userlogin userlogin)
        {
            var user = await _context.UserRegisters.FirstOrDefaultAsync(_user => _user.EmailAddress == userlogin.EmailAddress
            && _user.Password == userlogin.Password);
  


            return user;
        }
    }
}
