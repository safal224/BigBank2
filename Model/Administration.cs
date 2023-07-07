using System.ComponentModel.DataAnnotations;

namespace APIForProject.Model
{

    public class Administration
    {
        [Key]
        public int AdminId { get; set; }
        public string ?DoctorName { get; set; }

        public int DocID { get; set; }

        public string Status { get; set; }


    }
}
