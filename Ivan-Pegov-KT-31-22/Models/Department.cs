namespace Ivan_Pegov_KT_31_22.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime FoundationDate { get; set; }
        public int? HeadId { get; set; }
        public Teacher? Head { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
        public bool IsDeleted { get; set; } = false;

    }
}