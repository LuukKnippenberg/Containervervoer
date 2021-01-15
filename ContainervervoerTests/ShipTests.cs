using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Containervervoer;

namespace ContainervervoerTests
{
    [TestClass]
    public class ShipTests
    {
        [TestMethod]
        public void Ship_InstantiateShipWithLengthWidthHeight_AreEqual()
        {
            //Arrange
            int width = 2;
            int height = 4;
            int length = 2;


            //Act
            Ship ship = new Ship(length, width, height);

            //Assert
            Assert.AreEqual(width, ship.Width);
            Assert.AreEqual(length, ship.Width);
            Assert.AreEqual(height, ship.MaxHeight);

        }

        [TestMethod]
        public void AddContainerToShip_AddTwoContainersToShip_AreSame()
        {
            //Arrange
            Ship ship = new Ship(2, 2, 4);
            Container container = new Container(30, false, false);
            Container containerValuable = new Container(30, true, false);

            //Act
            ship.AddContainerToShip(container);
            ship.AddContainerToShip(containerValuable);

            //Assert
            Assert.AreSame(ship.ContainerListRead[0], container);
            Assert.AreSame(ship.ContainerListRead[1], containerValuable);

        }

        [TestMethod]
        public void AlgorithmHandler_WeightTooLowForShip_ExpectErrorStringReturn()
        {
            //Arrange
            string expectedReturn = "Load doesn't have enough weight";
            Ship ship = new Ship(2, 2, 4);
            Container container = new Container(30, false, false);

            //Act
            ship.AddContainerToShip(container);
            var result = ship.AlgorithmHandler();

            //Assert
            Assert.AreEqual(result, expectedReturn);
        }

        [TestMethod]
        public void AlgorithmHandler_TooManyContainers_ExpectErrorStringReturn()
        {
            //Arrange
            string expectedReturn = "Ship is too small";
            Ship ship = new Ship(2, 2, 4);
            Container container = new Container(30, false, false);
            int amountOfContainers = 50;

            //Act
            for (int i = 0; i < amountOfContainers; i++)
            {
                ship.AddContainerToShip(container);
            }
            var result = ship.AlgorithmHandler();

            //Assert
            Assert.AreEqual(result, expectedReturn);
        }

        [TestMethod]
        public void AlgorithmHandler_ImpossibleToDistribute_ExpectErrorStringReturn()
        {
            //Arrange
            string expectedReturn = "Unable to distribute containers";
            Ship ship = new Ship(2, 2, 4);
            Container container = new Container(30, true, true);
            int amountOfContainers = 12;

            //Act
            for (int i = 0; i < amountOfContainers; i++)
            {
                ship.AddContainerToShip(container);
            }
            var result = ship.AlgorithmHandler();

            //Assert
            Assert.AreEqual(result, expectedReturn);
        }

        [TestMethod]
        public void AlgorithmHandler_ImpossibleToDistribute_ExpectSuccessStringReturn()
        {
            //Arrange
            string expectedReturn = "Success";
            Ship ship = new Ship(2, 2, 4);
            Container container = new Container(30, false, false);
            int amountOfContainers = 12;

            //Act
            for (int i = 0; i < amountOfContainers; i++)
            {
                ship.AddContainerToShip(container);
            }
            var result = ship.AlgorithmHandler();

            //Assert
            Assert.AreEqual(result, expectedReturn);
        }

    }
}
