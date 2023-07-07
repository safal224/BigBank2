using System.ComponentModel.DataAnnotations;

namespace APIForProject.Model
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        public string ? FirstName { get; set; }
        public string ? LastName { get; set; }
        public int? Age { get; set; }
        public string ? Title { get; set; }
        public string? Gender { get; set; }

        public string? Address { get; set; }

        public int PinCode { get; set; }
        public string? PhoneNumber { get; set;}

        public string ? Specialization { get; set; }



    }
}
