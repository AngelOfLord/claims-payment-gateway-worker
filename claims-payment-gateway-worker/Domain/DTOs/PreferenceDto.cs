namespace claims_payment_gateway_worker.Repository.DataProviders.Abstractions
{
    public class PreferenceDto
    {
        public int Id { get; set; }
        public int ClaimNumber { get; set; }
        public required IEnumerable<AccountDto> Accounts { get; set; }
    }
}