namespace Ivan_Pegov_KT_31_22.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; } // Первичный ключ
        public string FirstName { get; set; } // Имя преподавателя
        public string LastName { get; set; } // Фамилия преподавателя
        public string MiddleName { get; set; } // Отчество преподавателя
        public int DepartmentId { get; set; } // Внешний ключ на кафедру
        public Department Department { get; set; } // Навигационное свойство на кафедру
        public bool IsDeleted { get; set; } // Флаг мягкого удаления
    }
}
