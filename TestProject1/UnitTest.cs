using Ivan_Pegov_KT_31_22.Models;

namespace Ivan_Pegov_KT_31_22.Tests
{
    public class UnitTest
    {
        [Fact]
        public void IsValidCathedralName_True()
        {
            var test1 = new Department { Name = "Кафедра компьютерных технологий" };
            var test2 = new Department { Name = "Кафедра информатики и вычислительной техники" };
            var test3 = new Department { Name = "Кафедра права и юриспруденции" };
            var test4 = new Department { Name = "Кафедра акушерства и гинекологии" };

            bool res1 = System.Text.RegularExpressions.Regex.IsMatch(test1.Name, @"^[А-Яа-я\s]+$");
            bool res2 = System.Text.RegularExpressions.Regex.IsMatch(test2.Name, @"^[А-Яа-я\s]+$");
            bool res3 = System.Text.RegularExpressions.Regex.IsMatch(test3.Name, @"^[А-Яа-я\s]+$");
            bool res4 = System.Text.RegularExpressions.Regex.IsMatch(test4.Name, @"^[А-Яа-я\s]+$");

            Assert.True(res1);
            Assert.True(res2);
            Assert.True(res3);
            Assert.True(res4);
        }

        [Fact]
        public void IsValidCathedralName_False()
        {
            var test1 = new Department { Name = "Кафедра компьютерных технологий 2" };
            var test2 = new Department { Name = "123Кафедра информатики и вычислительной техники" };
            var test3 = new Department { Name = "Кафедра1права2и3юриспруденции" };
            var test4 = new Department { Name = "4Кафедра акушерства и гинекологии4" };

            bool res1 = System.Text.RegularExpressions.Regex.IsMatch(test1.Name, @"^[А-Яа-я\s]+$");
            bool res2 = System.Text.RegularExpressions.Regex.IsMatch(test2.Name, @"^[А-Яа-я\s]+$");
            bool res3 = System.Text.RegularExpressions.Regex.IsMatch(test3.Name, @"^[А-Яа-я\s]+$");
            bool res4 = System.Text.RegularExpressions.Regex.IsMatch(test4.Name, @"^[А-Яа-я\s]+$");

            Assert.False(res1);
            Assert.False(res2);
            Assert.False(res3);
            Assert.False(res4);
        }
    }
}