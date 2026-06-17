using AutoMapper;
using MicrosoftEntraIDAPI.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MicrosoftEntraIDAPI.Services
{
    public class AuthService:IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly JwtService _jwtService;
        private  readonly IMapper _mapper;

        public AuthService( IAuthRepository repo ,
                            IMapper mapper,
                            JwtService service)
        {
            _authRepository = repo;
            _mapper = mapper;
            _jwtService = service;
        }
        
        public async Task<AuthResponseDto> Register(RegisterDto dto)
        {
            var existingUser = await _authRepository.GetByEmailAsync(dto.Email);
            if (existingUser != null)
            {
                throw new Exception("Email already exists");
            }
            var user = _mapper.Map<User>(dto);
            user.PasswordHash=BCrypt.Net.BCrypt.HashPassword(dto.Password);

            await _authRepository.AddUserAsync(user);
            await _authRepository.SaveChangesAsync();
            var token = _jwtService.GenerateToken(user);

            return new AuthResponseDto
            {
                Token = token,
                Message = "User registered successfully"
            };

        }
        public async Task<AuthResponseDto> Login(LoginDto dto)
        {
            var user = await _authRepository.GetByEmailAsync(dto.Email);
            if (user != null)
            {
                throw new Exception("invalid Credentials");
            }
            bool valid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);
            if (!valid)
                throw new Exception("Invalid Credentials");

            var token=_jwtService.GenerateToken(user);
            return new AuthResponseDto
            {
                Token = token,
                Message = "Login Successful"
            };
        }



    }
}
