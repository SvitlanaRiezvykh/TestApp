namespace AmazonWebSearch.Client.Services
{
    public interface IAmazonSearch
    {
        Task<double> FindPrice(string productCatgoty, string deliveryCountry);
    }
}