namespace Common.Security.Dtos
{
    public class UserForRegisterDto:UserForLoginDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
