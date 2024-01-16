using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using SamsWarehouseWebApp.Models.Data;
using SamsWarehouseWebApp.Models.DBContext;
using SamsWarehouseWebApp.Models.DTO;
using SamsWarehouseWebApp.Repository;
using SamsWarehouseWebApp.Services;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SamsWarehouseWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ItemDBContext _dbcontext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly AuthRepository _authRepository;
        private readonly SanitiserService _sanitiserService;



        public HomeController(ItemDBContext dbcontext, IWebHostEnvironment webHostEnvironment, AuthRepository authRepository, SanitiserService sanitiserService)
        {
            _dbcontext = dbcontext;
            _webHostEnvironment = webHostEnvironment;
            _authRepository = authRepository;
            _sanitiserService = sanitiserService;

        }
        /// <summary>
        /// Index controller method used to return a home index view 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            // Automatically sets the user ID to 1 when application is in development to save logging in each time
            //if (_webHostEnvironment.IsDevelopment())
            //{
            //    if (HttpContext.Session.Get("ID") == null)
            //    {
            //        HttpContext.Session.SetString("ID", "1");
            //    }
            //}
            return View();
        }
        /// <summary>
        /// Returns privacy page view 
        /// </summary>
        /// <returns></returns>
        public IActionResult AboutUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        /// Returns error view model that displays error 
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        /// <summary>
        /// Displays login page/view 
        /// </summary>
        /// <returns></returns>
        public IActionResult Login([FromQuery] string ReturnUrl)
        {
            LoginUserDTO login = new LoginUserDTO()
            {
                RedirectURL = String.IsNullOrEmpty(ReturnUrl) ? "/Item/Index" : ReturnUrl
            };

            return View(login);
        }

        /// <summary>
        /// Login controller method that checks user login details (username (Email) and password for authentication
        /// </summary>
        /// <param name="loginDetails"></param>
        /// <returns></returns>
        /// 

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDTO credentials)
        {
            var user = _authRepository.Authenticate(credentials);

            if (user == null)
            {
                return View();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, user.UserId.ToString()),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("Id",user.UserId.ToString())
            };

            //if (user.Role != null)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            //}

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                IsPersistent = true,
                RedirectUri = credentials.RedirectURL
            };

            await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties
            );

            return Redirect(credentials.RedirectURL);

        }

        /// <summary>
        /// Displays register page for account creation 
        /// </summary>
        /// <returns></returns>
        public IActionResult Register()
        {
            return View();
        }
        /// <summary>
        /// Register controller method used to register a user's details/create an appuser 
        /// </summary>
        /// <param name="registerDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Register(RegisterUserDTO registerDetails)
        {
            try
            {
                AppUser newUser = new AppUser()
                {
                    // Ensures property is an email
                    Email = registerDetails.Email,
                    // Uses BCrypt to hash password 
                    PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(registerDetails.Password),
                    Role = registerDetails.Role = "StandardUser"
                };
                // New user added to database
                _dbcontext.Users.Add(newUser);
                _dbcontext.SaveChanges();

                return RedirectToAction("Login");
            }
            catch (Exception e)
            {
                return View();
            }

        }
        /// <summary>
        /// Home controller that logs a user out and displays home index page 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Logout()
        {
            // Clears user session and 'logs out' user 
            await HttpContext.SignOutAsync();
            // Returns user to home index page
            return RedirectToAction("Login", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
