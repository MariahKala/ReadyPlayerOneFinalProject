using ReadyPlayerOne;
using ReadyPlayerOne.Models;
using ReadyPlayerOne.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Microsoft.EntityFrameworkCore;

namespace ReadyPlayerOneTest
{
    public class UnitTest1
    {
        [Fact]
        public void TestCatalogue()
        {
            // Arrange
            // Create mock player data
            var playersData = new List<Player>
            {
                                new Player
                {
                    PlayerID = 2,
                    PlayerName = "Rhiordan Tannick",
                    Class = "Warrior",
                    Health = "3"        ,
                    Strength = "3",
                    Intelligence = "3",
                    Stamina = "3",
                    Stealth = "3",
                    Luck = "3",
                    AlignmentID = "3",
                    PlayerImageID = "18"
                },
                new Player
                {
                    PlayerID = 3,
                    PlayerName = "Bevil Starling",
                    Class = "Rogue",
                    Health = "3",
                    Strength = "3",
                    Intelligence = "3",
                    Stamina = "3",
                    Stealth = "3",
                    Luck = "3",
                    AlignmentID = "3",
                    PlayerImageID = "25"

                }
            };

            // Create a mock DbSet<Player> using Moq
            var mockDbSet = new Mock<DbSet<Player>>();

            // Configure the mock DbSet to return the player data when queried
            mockDbSet.As<IQueryable<Player>>().Setup(m => m.Provider).Returns(playersData.AsQueryable().Provider);
            mockDbSet.As<IQueryable<Player>>().Setup(m => m.Expression).Returns(playersData.AsQueryable().Expression);
            mockDbSet.As<IQueryable<Player>>().Setup(m => m.ElementType).Returns(playersData.AsQueryable().ElementType);
            mockDbSet.As<IQueryable<Player>>().Setup(m => m.GetEnumerator()).Returns(playersData.GetEnumerator());

            // Create a mock DbContext using Moq
            var mockDbContext = new Mock<PlayerContext>();

            // Configure the mock DbContext to return the mock DbSet<Player>
            mockDbContext.Setup(m => m.Players).Returns(mockDbSet.Object);

            // Create an instance of the controller class being tested, injecting the mock DbContext
            var controller = new PlayerController(mockDbContext.Object);

            // Act
            // Call the action method being tested
            var result = controller.Catalogue();

            // Assert
            // Assert that the result is not null
            Assert.NotNull(result);

            Assert.IsType<ViewResult>(result);

            var viewResult = (ViewResult)result;
            var model = (List<Player>)viewResult.Model;
            Assert.Equal(playersData.Count, model.Count);
        }
    }
}