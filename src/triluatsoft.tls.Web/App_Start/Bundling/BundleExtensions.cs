using System.Web.Optimization;

namespace triluatsoft.tls.Web.Bundling
{
    public static class BundleExtensions
    {
        public static Bundle ForceOrdered(this Bundle bundle)
        {
            bundle.Orderer = new AsIsBundleOrderer();
            return bundle;
        }
    }
}