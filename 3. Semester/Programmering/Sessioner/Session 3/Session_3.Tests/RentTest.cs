using NUnit.Framework;

namespace Exercise_1_B.Tests
{
    public class RentTest
    {
        [Test]
        public void HorseRent_ShouldMakeHorseUnavailable()
        {
            // Arrange
            Horse horse = new Horse("Spirit", "Mustang");

            // Act
            horse.Rent();

            // Assert
            Assert.That(horse.IsAvailable, Is.False);
        }

        [Test]
        public void CarRent_ShouldMakeCarUnavailable()
        {
            // Arrange
            Car car = new Car("Volvo", 200);

            // Act
            car.Rent();

            // Assert
            Assert.That(car.IsAvailable, Is.False);
        }

        [Test]
        public void CarDrivingOverServiceInterval_ShouldNeedService()
        {
            // Arrange
            Car car = new Car("Volvo", 200);

            // Act
            car.Drive(10001);

            // Assert
            Assert.That(car.NeedsService, Is.True);
            Assert.That(car.IsAvailable, Is.False);
        }

        [Test]
        public void CarResetNeedForService_ShouldNotNeedService()
        {
            // Arrange
            Car car = new Car("Volvo", 200);
            car.Drive(10001);

            // Act
            car.ResetNeedForService();

            // Assert
            Assert.That(car.NeedsService, Is.False);
        }
    }
}