﻿namespace SS.Marcelo.DevTest.Domain.Alterations.Entities
{
	public class Customer
	{
		public Customer(string name, string email)
		{
			this.Name = name;
			this.Email = email;
		}

		public string Name { get; private set; }
		public string Email { get; private set; }
	}
}
