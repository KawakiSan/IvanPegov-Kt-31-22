namespace Ivan_Pegov_KT_31_22.Models
{
    public class Discipline
    {
        public int DisciplineId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int LoadHours { get; set; }
        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<TeacherDiscipline> TeacherDisciplines { get; set; } = new List<TeacherDiscipline>();
    }
}
