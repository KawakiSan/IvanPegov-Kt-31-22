namespace Ivan_Pegov_KT_31_22.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; } // Первичный ключ
        public string FirstName { get; set; } = string.Empty; // Имя преподавателя
        public string LastName { get; set; } = string.Empty; // Фамилия преподавателя
        public string MiddleName { get; set; } = string.Empty; // Отчество преподавателя
        public int DepartmentId { get; set; } // Внешний ключ на кафедру
        public Department Department { get; set; } = null!; // Навигационное свойство на кафедру
        public bool IsDeleted { get; set; } = false; // Флаг мягкого удаления

        public virtual ICollection<TeacherDiscipline> TeacherDisciplines { get; set; } = new List<TeacherDiscipline>();
    }
}