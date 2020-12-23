using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCar.Memory;
using UCar.Web.Controllers;
using Xunit;

namespace UCar.Tests
{
    public class CarTest
    {
        ICarRepository repo;
        IWebHostEnvironment app;
        [Fact]
        public void Worke_DoConfirm_ReturnsAViewResult()
        {
            // Arrange
            var mockRepo = new Mock<ICarRepository>();
            mockRepo.Setup(repo => repo.Add(new Car("Lada Vesta", "Топ за свои деньги", 1000000, new Car.CarID(5), "/img/Lada Vesta.jpg", false, false, "user@mail.ru")));
            var controller = new WorkeController(mockRepo.Object);

            // Act
            var result = controller.DoConfirmCar();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void Worke_Confirm_WorksCorrectly()
        {
            repo = new CarRepository();
            repo.Add(new Car("Test", "Test", 10, new Car.CarID(3000), "/img/Merc.jpg", false, false, "test@mail.ru"));
            // Arrange
            var controller = new WorkeController(repo);

            // Act
            var result = controller.Confirm(3000);

            // Assert
            var car = repo.GetAll().Where(c=>c.ID.IDValue==3000).ToArray()[0];
            Assert.True(car.IsConfirned);
            Assert.Equal("Автосалон", car.Owner);
            repo.Delete(car);
        }
        [Fact]
        public void Sell_BuyCar_WorksCorrectly()
        {
            repo = new CarRepository();
            repo.Add(new Car("Test", "Test", 10, new Car.CarID(3001), "/img/Merc.jpg", true, false, "Автосалон"));
            // Arrange
            var controller = new SellController(repo,app);

            // Act
            var result = controller.BuyCar(3001,"test@mail.ru");

            // Assert
            var car = repo.GetAll().Where(c=>c.ID.IDValue==3001).ToArray()[0];
            Assert.True(car.IsSold);
            Assert.Equal("test@mail.ru", car.Owner);
        }
    }
}
