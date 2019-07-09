namespace SS.Marcelo.DevTest.Domain.Alterations.Entities
{
	public class Customer
	{
		public Customer(string id, string name, string email)
		{
			this.Id = id;
			this.Name = name;
			this.Email = email;
		}

		public string Id { get; private set; }
		public string Name { get; private set; }
		public string Email { get; private set; }
	}
}
