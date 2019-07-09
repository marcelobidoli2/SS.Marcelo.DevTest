using SS.Marcelo.DevTest.Domain.Alterations.Enums;

namespace SS.Marcelo.DevTest.Domain.Alterations.Entities
{
	public class Payment
	{
		public Payment(Alteration alteration, Customer customer, decimal amount, EPaymentMethod paymentMethod)
		{
			this.Alteration = alteration;
			this.Customer = customer;
			this.Amount = amount;
			this.PaymentMethod = paymentMethod;
		}

		public Alteration Alteration { get; set; }
		public Customer Customer { get; set; }
		public decimal Amount { get; set; }
		public EPaymentMethod PaymentMethod { get; set; }
	}
}
