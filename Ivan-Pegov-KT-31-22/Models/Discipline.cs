namespace Ivan_Pegov_KT_31_22.Models
{
    public class Discipline
    {
        public int DisciplineId { get; set; } // Первичный ключ
        public string Name { get; set; } = string.Empty; // Название дисциплины
        public int LoadHours { get; set; } // Нагрузка часов за семестр
        public bool IsDeleted { get; set; } = false; // Флаг мягкого удаления

        public virtual ICollection<TeacherDiscipline> TeacherDisciplines { get; set; } = new List<TeacherDiscipline>();
    }
}
