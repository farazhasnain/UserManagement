

namespace UserManagement.Service.ViewModel.Identity.AppUsers
{
    public class UserResponseViewModel
    {
        public int Id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public bool is_active { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}
