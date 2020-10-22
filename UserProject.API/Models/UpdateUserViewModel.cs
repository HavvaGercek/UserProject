using System.ComponentModel.DataAnnotations;

namespace UserProject.API.Models
{
    public class UpdateUserViewModel 
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Companyname { get; set; }
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string CatchPhrase { get; set; }
        public string BS { get; set; }
    }
}
