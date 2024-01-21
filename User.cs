namespace UsersApp
{
    class User
    {
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public User() { }
        public User(string login, string password, string email)
        {
            Login = login;
            Password = password;
            Email = email;
        }

        //public override string ToString() => "Логин: "+ Login + " Email: "+ Email;


    }
}
