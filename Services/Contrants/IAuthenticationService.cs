using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contrants
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserRegistrationDto userForRegistrationDto);
        Task<bool> ValidateUser(UserAuthenticationDto userForAuthDto);
        Task<TokenDto> CreateToken(bool populateExp);
        Task<TokenDto> RefreshToken(TokenDto tokenDto);
        Task<bool> Verify(string token);

    }
}
