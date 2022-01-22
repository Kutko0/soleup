namespace Soleup.API.DTOs
{
    public class ResponseWithObject
    {
        public string Message { get; set; }
        public object Item { get; set; }
        public string JwtToken { get; set; }
    }
}