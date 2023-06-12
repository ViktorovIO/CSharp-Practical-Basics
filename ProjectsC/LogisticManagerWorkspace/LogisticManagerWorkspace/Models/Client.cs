namespace LogisticManagerWorkspace.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public Client()
        {
            this.Id = Id;
            this.Name = Name;
            this.Phone = Phone;
            this.Email = Email;
            this.City = City;
            this.Address = Address;
        }
    }
}
