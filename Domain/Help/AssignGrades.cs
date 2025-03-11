namespace Education_Center_Domain.Help
{
    public class AssignGrades
    {
        public string StudentEmail { get; set; }
        public string SubjectName { get; set; }
        public int BranchId { get; set; }
        public int GradtypeId { get; set; }
        public decimal Grade { get; set; }
        public string Comment { get; set; }
    }
}

