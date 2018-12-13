
namespace BanqueXA.Services
{
    public class ServiceManager
    {
        public static IBanqueAsyncService DataStore = BanqueInMemService.Instance;
    }
}