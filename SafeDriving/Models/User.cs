namespace SafeDriving.Models
{
    public class User
    {
        public int Id { get; set; }
        public string User_status { get; set; }
        public string Status { get; set; }
        public string Course { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Avatar { get; set; }
        public string Birthday { get; set; }
        public string Sex { get; set; }
        public string Code { get; set; }
        public string Faculty { get; set; }
        public string Group { get; set; }
        public string Specialty { get; set; }
        public string Specialization { get; set; }
        public string DegreeLength { get; set; }
        public string EducationForm { get; set; }
        public string Finance { get; set; }
        public string DegreeLevel { get; set; }
        public string EnterYear { get; set; }
        public List<string> Orders { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<string> Accounts { get; set; }
        public bool HasAlerts { get; set; }
        public string Lastaccess { get; set; }
    }
}
