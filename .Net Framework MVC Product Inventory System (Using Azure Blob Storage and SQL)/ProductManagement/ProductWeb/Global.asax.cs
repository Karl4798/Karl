using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Queue;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ProductWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            InitializeAzureStorage();

        }

        private void InitializeAzureStorage()
        {

            var storageAccount = CloudStorageAccount.Parse(System.Configuration.ConfigurationManager.ConnectionStrings["AzureStorage"].ToString());

            Trace.TraceInformation("Generating the productimages container.");

            var blobClient = storageAccount.CreateCloudBlobClient();

            var imagesBlobContainer = blobClient.GetContainerReference("productimages");

            if (imagesBlobContainer.CreateIfNotExists())
            {

                imagesBlobContainer.SetPermissions(

                    new BlobContainerPermissions
                    {
                        PublicAccess = BlobContainerPublicAccessType.Blob
                    });

            }

        }

    }
}
