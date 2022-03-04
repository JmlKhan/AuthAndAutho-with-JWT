namespace AuthAndOuth.Model
{
    public class UserConstants
    {
        public static List<ApplicationUser> Users = new List<ApplicationUser>()
        {
            new ApplicationUser() {Username = "Jason_Admin", Email = "jason@gmail.com", Password = "1234",
            Role = "Admin", Surname = "Bryan"
            },
            new ApplicationUser() {Username = "elliod_seller", Email = "elly@gmail.com", Password = "1111",
            Role = "Seller", Surname = "Elliod"
            },


        };

    }
}
