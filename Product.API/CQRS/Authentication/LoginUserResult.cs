namespace Product.API.CQRS.Authentication
{
    public class LoginUserResult
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public bool IsExist { get; set; }
    }
}
