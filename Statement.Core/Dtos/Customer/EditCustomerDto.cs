namespace Statement.Core.Dtos.Customer
{
    public class EditCustomerDto : BaseCustomerDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }
    }
}
