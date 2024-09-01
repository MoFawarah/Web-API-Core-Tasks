using System.ComponentModel.DataAnnotations;

namespace WebAPICoreTask1.DTOS
{
    public class LoginRequestDTO
    {
        public string? Username { get; set; }

        [DataType(DataType.Password)]


        public string? Password { get; set; }
    }
}
