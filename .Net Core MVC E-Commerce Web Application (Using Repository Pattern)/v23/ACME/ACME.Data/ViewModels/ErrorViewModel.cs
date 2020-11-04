namespace ACME.Data.ViewModels
{

    // View Model used to define fields for an error message
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}