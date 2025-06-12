
namespace Mission.Entities.Models
{
    public class UserResponseModel
    {
        public int Id { get; set; } 
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }
        public string UserType { get; set; }
        public string? Availability { get; set; }
        public string? WhyIVolunteer { get; set; }
        public int? CityId { get; set; }
        public int? CountryId { get; set; }
        public string? Department { get; set; }
        public string? EmployeeId { get; set; }
        public string? LinkedInUrl { get; set; }
        public string? Manager { get; set; }
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? MySkills { get; set; }
        public string? MyProfile { get; set; }
        public string? UserImage { get; set; }
        public bool? Status { get; set; }
        public string? Title { get; set; }
    }
}
