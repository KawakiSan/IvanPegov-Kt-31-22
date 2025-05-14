namespace Ivan_Pegov_KT_31_22.Models
{
    public class Department
    {
        public int DepartmentId { get; set; } // Первичный ключ
        public string Name { get; set; } = string.Empty; // Название кафедры.  Инициализация с пустой строкой
        public DateTime FoundationDate { get; set; } // Дата основания кафедры
        public int? HeadId { get; set; } // Внешний ключ на заведующего.  Изменил на nullable.
        public Teacher? Head { get; set; } // Навигационное свойство - заведующий кафедрой. Изменил на nullable.
        public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>(); // Все преподаватели кафедры. virtual для правильной навигации.  Инициализация с List.
        public bool IsDeleted { get; set; } = false; // Флаг мягкого удаления.  Инициализация на false, чтобы избежать неожиданного поведения.

    }
}