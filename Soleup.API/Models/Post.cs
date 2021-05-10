namespace Soleup.API.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TypeOfPost Type { get; set; }
    }

    public enum TypeOfPost { TRADE, SELL, OPEN_TO_OFFERS}
}