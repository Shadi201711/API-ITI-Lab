namespace Day2.DTO
{
    public class departmentDTO
    {
        public int Dept_Id { get; set; }
        public string Dept_Name { get; set; }
        public string Dept_Location { get; set; }
        public int? Dept_Manager { get; set; }

        public string Dept_Desc { get; set; }
        public int StudentCount { get; set; }
    }
}
