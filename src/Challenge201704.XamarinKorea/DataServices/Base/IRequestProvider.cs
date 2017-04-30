using System.Threading.Tasks;

namespace Challenge201704.XamarinKorea.DataServices.Base
{
    public interface IRequestProvider
    {
        Task<TResult> GetAsync<TResult>(string uri);
    }
}
