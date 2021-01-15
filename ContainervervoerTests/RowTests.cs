using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Containervervoer;
using Logic;

namespace ContainervervoerTests
{
    [TestClass]
    public class RowTests
    {
        [TestMethod]
        public void Row_InstantiateRowAndCheckIfPropertiesAreEqual_True()
        {
            //Arrange
            int width = 2;
            int side = 0;
            int maxHeight = 4;

            //Act
            Row row = new Row(width, side, maxHeight);

            //Assert
            Assert.AreEqual((int)row.Side, side);
            Assert.AreEqual(row.Width, width);
            Assert.AreEqual(row.MaxHeight, maxHeight);
        }

        [TestMethod]
        public void TryToAddContainer_AddOneContainerToRowAndcheckIfTheyAreTheSame_True()
        {
            //Arrange
            int weight = 30;
            bool valuable = false;
            bool coolable = false;

            Row row = new Row(2, 0, 4);
            Container container = new Container(weight, valuable, coolable);


            //Act
            row.TryToAddContainer(container);

            //Assert
            Assert.AreSame(row.stackListReadable[0].ContainerListReadable[0], container);
        }

        [TestMethod]
        public void TryToAddContainer_CreateReservedSpot_True()
        {
            //Arrange
            int weight = 30;
            Row row = new Row(6, 0, 4);
            Container containerValuable = new Container(weight, true, false);
            bool expectedResult = true;


            //Act
            row.TryToAddContainer(containerValuable);
            row.TryToAddContainer(containerValuable);


            //Assert
            Assert.AreEqual(row.stackListReadable[2].Reserved, expectedResult);
        }

        [TestMethod]
        public void TryToAddContainer_TooManyContainersExpectFalseReturn_True()
        {
            //Arrange
            int weight = 30;
            Row row = new Row(2, 0, 4);
            Container container = new Container(weight, false, false);
            int amountOfContainers = 9;
            bool expectedResult = false;
            bool result = true;

            //Act
            for (int i = 0; i < amountOfContainers; i++)
            {
                result = row.TryToAddContainer(container);
            }

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        /*
 
         */
    }
}
