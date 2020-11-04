using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProductCommon;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.ServiceRuntime;
using System.IO;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using System.Diagnostics;
using PagedList;
using PagedList.EntityFramework;

namespace ProductWeb.Controllers
{
    public class ProductController : Controller
    {

        // Gets the product context
        private ProductsContext db = new ProductsContext();

        // Variable to hold cloud blob container reference
        private static CloudBlobContainer blobContainer;

        public ProductController()
        {
            // Initializes the azure storage service
            InitializeAzureStorage();
        }

        // Index method
        public async Task<ActionResult> Index(string searchString, int? page)
        {

            // Gets a list of all products
            var productsList = db.Products.AsQueryable();

            // Used to search the list of products
            if (!String.IsNullOrEmpty(searchString))
            {
                // Searches list of products
                productsList = productsList.Where(s => s.Name.Contains(searchString));
            }

            // Returns the view with list of products
            return View(await productsList.OrderBy(i => i.ProductId).ToPagedListAsync(page ??  1, 5));
        }

        // Initializes storage service
        private void InitializeAzureStorage()
        {

            // Connects to the storage account
            var storageAccount = CloudStorageAccount.Parse(System.Configuration.ConfigurationManager.ConnectionStrings["AzureStorage"].ToString());

            // Creates storage account blob client
            var blobClient = storageAccount.CreateCloudBlobClient();

            blobClient.DefaultRequestOptions.RetryPolicy = new LinearRetry(TimeSpan.FromSeconds(3), 3);

            // Gets blob container reference for product images
            blobContainer = blobClient.GetContainerReference("productimages");

        }

        // Details page controller
        public async Task<ActionResult> Details(int? id)
        {

            // If the passed id is null, then display an error
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Gets information of the selected product
            Product prod = await db.Products.FindAsync(id);

            // If the product is not found, then display an error
            if (prod == null)
            {
                return HttpNotFound();
            }

            // Return the details page with product information
            return View(prod);

        }

        // Create page controller
        public ActionResult Create()
        {
            // Return the create page
            return View();
        }

        // Method for posting products to the system
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(
            [Bind(Include = "Name,Price,Description,LastUpdated")] Product prod,
            HttpPostedFileBase imageFile)
        {

            // Create a storage variable for the uploaded image
            CloudBlockBlob imageBlob = null;

            // If form validation was successfull, then create the product
            if (ModelState.IsValid)
            {

                // Uploads the image if valid
                if (imageFile != null && imageFile.ContentLength != 0)
                {

                    // Runs the BlobStorageHelper method to upload the image
                    imageBlob = await BlobStorageHelper(imageFile);

                    // Gets the image reference and stores it in the database
                    prod.ImageURL = imageBlob.Uri.ToString();
                    
                }

                // Adds the product item to the database context
                db.Products.Add(prod);

                // Saves changes to the database
                await db.SaveChangesAsync();

                // Message
                Trace.TraceInformation("Created ProductId {0} in database", prod.ProductId);

                // Redirects the user to the product index page (listing)
                return RedirectToAction("Index");
            }

            // Returns the create view if ModelState is invalid (validation was unsuccessful)
            return View(prod);

        }

        // Edit page controller
        public async Task<ActionResult> Edit(int? id)
        {

            // If passed product id is null, then display an error message
            if (id == null)
            {
                // Returns error message
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Gets information of the selected product
            Product prod = await db.Products.FindAsync(id);

            // If the product is not found, then display an error
            if (prod == null)
            {
                return HttpNotFound();
            }

            // Return the edit page with product information
            return View(prod);

        }

        // Edit page controller
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(
            [Bind(Include = "ProductId,Name,Price,Description,ImageURL")] Product prod,
            HttpPostedFileBase imageFile)
        {

            // Create a storage variable for the uploaded image
            CloudBlockBlob imageBlob = null;

            // If form validation was successfull, then edit the product
            if (ModelState.IsValid)
            {

                // Updates the image if valid
                if (imageFile != null && imageFile.ContentLength != 0)
                {

                    // Runs the DeleteProductBlobsAsync method to delete the current image
                    await DeleteProductBlobsAsync(prod);

                    // Runs the BlobStorageHelper method to upload the new image
                    imageBlob = await BlobStorageHelper(imageFile);

                    // Gets the new image reference and stores it in the database
                    prod.ImageURL = imageBlob.Uri.ToString();

                }

                // Changes the state of the database record to modified
                db.Entry(prod).State = EntityState.Modified;

                // Saves changes to the database
                await db.SaveChangesAsync();

                // Message
                Trace.TraceInformation("Updated ProductId {0} in database", prod.ProductId);

                // Returns the edit page with selected product information
                return RedirectToAction("Index");

            }

            // Redirects the user back to the edit page if ModelState is invalid (validation was unsuccessful)
            return View(prod);

        }

        // Delete page controller
        public async Task<ActionResult> Delete(int? id)
        {

            // If the passed product id is invalid, then return an error
            if (id == null)
            {

                // Returns error message
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            // Gets information of the selected product
            Product prod = await db.Products.FindAsync(id);

            // If the product is not found, then display an error
            if (prod == null)
            {

                return HttpNotFound();

            }

            // Return the delete page with product information
            return View(prod);

        }

        // Delete page controller
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {

            // Gets information of the selected product
            Product prod = await db.Products.FindAsync(id);

            // Runs the DeleteProductBlobsAsync method to delete the current image
            await DeleteProductBlobsAsync(prod);

            // Removes the product from the database context
            db.Products.Remove(prod);

            // Saves changes to the database
            await db.SaveChangesAsync();

            // Message
            Trace.TraceInformation("Deleted product {0}", prod.ProductId);

            // Redirects the user to the product index page (listing)
            return RedirectToAction("Index");

        }

        // Method to upload images to the productimages container
        private async Task<CloudBlockBlob> BlobStorageHelper(HttpPostedFileBase imageFile)
        {

            // Message
            Trace.TraceInformation("Uploading image file {0}", imageFile.FileName);

            // Sets blob name to GUID and extension information
            string blobName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);

            // Variable to store image
            CloudBlockBlob imageBlob = blobContainer.GetBlockBlobReference(blobName);

            // Uses filestream to upload image to Azure storage
            using (var fileStream = imageFile.InputStream)
            {
                // Uploads image
                await imageBlob.UploadFromStreamAsync(fileStream);
            }

            // Message
            Trace.TraceInformation("Uploaded image file to {0}", imageBlob.Uri.ToString());

            // Returns imageBlob to calling method
            return imageBlob;

        }

        // Method to delete image for passed product item
        private async Task DeleteProductBlobsAsync(Product prod)
        {

            // If the product image is valid, then delete the image
            if (!string.IsNullOrWhiteSpace(prod.ImageURL))
            {

                // Gets image reference
                Uri blobUri = new Uri(prod.ImageURL);

                // Runs a method which deletes the image
                await DeleteProductBlobAsync(blobUri);

            }

        }

        // Method to delete product image
        private static async Task DeleteProductBlobAsync(Uri blobUri)
        {

            // Try/ catch used if no image is found
            try
            {
                // Stores blob reference
                string blobName = blobUri.Segments[blobUri.Segments.Length - 1];

                // Message
                Trace.TraceInformation("Deleting image blob {0}", blobName);

                // Gets product item that will be deleted
                CloudBlockBlob blobToDelete = blobContainer.GetBlockBlobReference(blobName);

                // Deletes the image
                await blobToDelete.DeleteAsync();
            }
            catch (Exception)
            {
                // Error message
                Trace.TraceInformation("Cannot delete image file from storage.");
            }
            
        }
    }
}
