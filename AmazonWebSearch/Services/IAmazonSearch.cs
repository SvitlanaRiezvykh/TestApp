namespace AmazonWebSearch.Services
{
    public interface IAmazonSearch
    {
        Task<double> FindPrice(string productCatgoty, string deliveryCountry);
    }
}