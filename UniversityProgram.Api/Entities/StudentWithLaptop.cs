namespace UniversityProgram.Api.Entities
{
    public class StudentWithLaptop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int StudentId { get; set; }
        public int LaptopId { get; set; }
        public Student student { get; set; }  
        public Laptop laptop { get; set;}
    }
}
