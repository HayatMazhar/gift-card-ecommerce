namespace Bamboo.Application.Features.Account.ViewModel
{
    public class Pofile
    {
        public int Id { get; set; }
        public string Currency { get; set; }
        public double Balance { get; set; }
        public bool IsActive { get; set; }
    }

    public class Account
    {
        public Pofile[] Accounts { get; set; }
    }
}
