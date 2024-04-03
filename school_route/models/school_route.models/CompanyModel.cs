namespace school_route.models
{
    public class CompanyModel
    {
        public CompanyModel() { }

        public int Id { get; set; }

        public string  Name { get; set; }

        public string NickName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Password { get; set; }

        public bool Active { get; set; }

    }
}
