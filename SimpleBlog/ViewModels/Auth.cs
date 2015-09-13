using System.ComponentModel.DataAnnotations;

namespace SimpleBlog.ViewModels
{
    //Contract between the view and the controller
    public class AuthLogin
    {
        //Must add an actionResult in the controller.
        [Required]
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}