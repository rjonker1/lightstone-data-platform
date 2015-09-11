using System;

namespace LiveAuto.Web.Dtos
{
    public class ChangePasswordDto
    {
        public Guid Token { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }

        public ChangePasswordDto()
        {
            Message = "";
        }

        public ChangePasswordDto(Guid token, string password)
        {
            Token = token;
            Password = password;
            Message = "";
        }
    }
}