namespace Ivan_Pegov_KT_31_22.Filters.StudentFilters
{
    public class StudentGroupFilter
    {
        public string GroupName { get; set; } = null!;
    }
    public class DisciplineFilter
    {
        public int? TeacherId { get; set; }
        public int? MinLoadHours { get; set; }
        public int? MaxLoadHours { get; set; }
    }
}