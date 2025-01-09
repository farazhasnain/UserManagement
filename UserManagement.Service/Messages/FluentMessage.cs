
namespace UserManagement.Service.Messages
{
    public  static class FluentMessage
    {

        public static string Required(string property_name) => $"{property_name} is required";
        public static string EmailFormat() => $"Email is not correct format";



    }
}
