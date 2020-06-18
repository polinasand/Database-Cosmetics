using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using DatabaseCosmetics;
using DatabaseCosmetics.Models;
using DatabaseCosmetics.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace DatabaseCosmetics.Tests
{
    public class CollectionsControllerTests
    {
        private readonly DatabaseCosmeticsContext context;
        [Fact]
        public void ResultGetCollections()
        {
            var mockDB = new Mock<DatabaseCosmeticsContext>();
            mockDB.Setup(repo => repo.ListAsync())
                .ReturnsAsync(GetTestSessions());
            var controller = new HomeController(mockRepo.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<StormSessionViewModel>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }


        [Fact]
        public void ResultNotNull()
        {
            // Arrange
            CollectionsController controller = new CollectionsController(context);
            // Act
            IActionResult result = controller.GetCollections() as IActionResult;
            // Assert
            Assert.NotNull(result);
        }

    }
}

