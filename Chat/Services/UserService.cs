using Chat.Data;
using Chat.Models;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.Net.Mail;
using Microsoft.EntityFrameworkCore;

namespace Chat.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User? GetUser(string username, string password)
        {
            var hash = HashPassword(password);
            return _context.Users.FirstOrDefault(u => u.Username == username && u.PasswordHash == hash);
        }


        public bool Register(string username, string password, string email)
        {
            if (_context.Users.Any(u => u.Username == username))
                return false;

            var hashedPassword = HashPassword(password);

            var user = new User
            {
                Username = username,
                PasswordHash = hashedPassword,
                Email = email
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return true;
        }

        public void SendVerificationCode(string email, string code)
        {
            var smtp = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("verificacion.coda@gmail.com", "gbva nwez mdtf bgjc"),
                EnableSsl = true,
            };

            var mail = new MailMessage("verificacion.coda@gmail.com", email)
            {
                Subject = "Código de verificación",
                Body = $"Tu código de verificación es: {code}"
            };

            smtp.Send(mail);
        }

        public bool Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null) return false;

            return ValidateUser(password, user.PasswordHash);
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        private bool VerifyPassword(string inputPassword, string storedHash)
        {
            var inputHash = HashPassword(inputPassword);
            return inputHash == storedHash;
        }

        public bool ValidateUser(string username, string password)
        {
            string hash = HashPassword(password);
            return _context.Users.Any(u => u.Username == username && u.PasswordHash == hash);
        }
    }
}
