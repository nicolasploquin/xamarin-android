
namespace Eni.Banque.Android.Services
{
    public class ServiceManager
    {

#if DEBUG
        public static IBanqueAsyncService DataStore = BanqueInMemService.Instance;
#else
        public static IBanqueAsyncService DataStore = BanqueRestService.Instance;
#endif

    }
}