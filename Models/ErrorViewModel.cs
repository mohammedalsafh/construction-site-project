namespace CPIS_358_project.Models 
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }//this save the specific id of the request that failed so we can track it

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);//this returns true if we have a request id to show otherwise its false
    }
}
