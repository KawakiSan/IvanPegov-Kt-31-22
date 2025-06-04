using Ivan_Pegov_KT_31_22.Models;
using Xunit;

namespace Ivan_Pegov_KT_31_22.Tests
{
    public class TeacherTests
    {
        [Fact]
        public void IsWorkingAge_Age25_ReturnsTrue()
        {
            // Arrange
            var teacher = new Teacher { Age = 25 };

            // Act
            var result = teacher.IsWorkingAge();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsWorkingAge_Age17_ReturnsFalse()
        {
            var teacher = new Teacher { Age = 17 };
            var result = teacher.IsWorkingAge();
            Assert.False(result);
        }

        [Fact]
        public void IsWorkingAge_Age66_ReturnsFalse()
        {
            var teacher = new Teacher { Age = 66 };
            var result = teacher.IsWorkingAge();
            Assert.False(result);
        }
    }
}