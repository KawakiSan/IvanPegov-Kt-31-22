namespace Ivan_Pegov_KT_31_22.Helpers
{
    public class ColumnType
    {
        public const string Date = "timestamp"; // Для даты основания кафедры
        public const string Guid = "uuid"; // Если понадобится для идентификаторов (необязательно)
        public const string String = "varchar"; // Для текстовых полей (названия, имена, фамилии и т.д.)
        public const string Text = "text"; // Для больших текстов (если будет нужно)
        public const string Bool = "bool"; // Для мягкого удаления (IsDeleted)
        public const string Int = "int"; // Для числовых полей: Id, количество преподавателей и т.д.
        public const string Long = "bigint"; // Если вдруг будут большие числа (необязательно)
        public const string Decimal = "money"; // Если будут деньги (например, оклад заведующего — но пока не нужно)
        public const string Double = "numeric(9,2)"; // Для дробных значений (пока не нужно)
    }
}
