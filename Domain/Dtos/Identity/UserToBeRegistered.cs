using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Identity
{
    public class UserToBeRegistered
    {

        public string Email { get; set; }

    
        public string Password { get; set; }

    
        public string ConfirmPassword { get; set; }


        public string FirstName { get; set; }


        public string LastName { get; set; }

        public int Number { get; set; }
    }
}
