using AutoMapper;
using HospitalAPI.Security.Models;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HospitalAPI.Security
{
    public class AuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IAllergensRepository _allergensRepository;
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;

        public AuthService(
            SignInManager<User> signInManager,
            RoleManager<IdentityRole<int>> roleManager,
            UserManager<User> userManager,
            IConfiguration configuration,
            IAllergensRepository allergensRepository,
            IPatientService patientService,
            IMapper mapper)
        {
            _userManager = userManager;
            _configuration = configuration;
            _allergensRepository = allergensRepository;
            _patientService = patientService;
            _mapper = mapper;
        }

        public async Task<String> LoginInternAsync(LoginRequest loginRequest)
        {
            var user = await _userManager.FindByNameAsync(loginRequest.Username);
            if (user == null)
                return null;
            var rolename = await _userManager.GetRolesAsync(user);
            if (rolename.First() == "Patient")
                return null;
            var res = await _userManager.CheckPasswordAsync(user, loginRequest.Password);
            if (!res)
                return null;
            return BuildToken(await GetUserDTO(user));
        }

        public async Task<string> LoginPublicAsync(LoginRequest loginRequest)
        {
            var user = await _userManager.FindByNameAsync(loginRequest.Username);
            if (user == null)
                return null;
            var rolename = await _userManager.GetRolesAsync(user);
            if (rolename.First() == "Manager" || rolename.First() == "Doctor")
                return null;
            var res = await _userManager.CheckPasswordAsync(user, loginRequest.Password);
            if (!res)
                return null;
            return BuildToken(await GetUserDTO(user));
        }

        public async Task<string> RegisterAsync(RegisterRequest registerRequest)
        {
            var registerUser = new User()
            {
                UserName = registerRequest.Username,
                Email = registerRequest.Email,
            };

            var result = await _userManager.CreateAsync(registerUser, registerRequest.Password);
            if (!result.Succeeded)
                return null;
            await _userManager.AddToRoleAsync(registerUser, "Patient");
            if (registerRequest.RegisterUser != null)
            {
                var p = _mapper.Map<Patient>(registerRequest.RegisterUser);
                p.SelectedDoctorId = 1;
                p.UserId = registerUser.Id;
                var patientAllergens = _allergensRepository
                    .GetAllergensByDtoId(p.Allergens.Select(a => a.Id).ToList());
                _patientService.CreateAndAddAllergens(p, patientAllergens);
            }

            return "Ok";
        }

        private async Task<UserDTO> GetUserDTO(User user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            return new UserDTO()
            {
                Id = user.Id,
                Username = user.UserName,
                Role = userRoles[0],
            };
        }

        private string BuildToken(UserDTO user)
        {
            var issuer = _configuration["Jwt:ValidIssuer"];
            var secret = Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Username", user.Username),
                    new Claim("UserId", user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role),

                }),

                Issuer = issuer,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
