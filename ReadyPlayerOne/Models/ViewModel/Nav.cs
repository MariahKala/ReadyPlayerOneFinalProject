namespace ReadyPlayerOne.Models
{

    //Used in Layout to mark a navigation link as active. This was used in the Bookstore app in the book.
    public static class Nav
    {
        public static string Active(string value, string current) => (value == current) ? "active" : "";

        public static string Active(int value, int current) => (value == current) ? "active" : "";
    }
}
