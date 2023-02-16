
namespace Bookstore.Models
{
    // this class isn't exactly a view model, so it doesn't have the ViewModel suffix.
    // It's used in the Layout and AdminLayout views to mark a nav link as active.
    // It's in this folder because, like a traditional view model, it's used in a view.

    public static class Nav
    {
        public static string Active(string value, string current) => 
            (value == current) ? "active" : "";
        public static string Active(int value, int current) =>
            (value == current) ? "active" : "";
    }
}
