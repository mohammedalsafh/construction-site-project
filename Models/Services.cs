namespace CPIS_358_project.Models
{
    public class Services
    {
        public int ID { get; set; }
        public string Name 
        { get; set; }
        required
        
        public string Profession
        { get; set; }
        required
        public int yearsOfExperience
        { get; set; }


        public Services()
        {

        }
    }
}