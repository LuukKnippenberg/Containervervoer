using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Containervervoer;
using Logic;

namespace ContainervervoerTests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void Stack_InstantiateStackAndCheckIfPropertiesAreEqual_True()
        {
            //Arrange
            int position = 2;
            int maxHeight = 4;
            bool isFront = true;
            bool isBack = false;

            //Act
            Stack stack = new Stack(position, maxHeight, isFront, isBack);

            //Assert
            Assert.AreEqual(position, stack.Position);
            Assert.AreEqual(maxHeight, stack.MaxHeight);
            Assert.AreEqual(isFront, stack.IsFront);
            Assert.AreEqual(isBack, stack.IsBack);
        }

        [TestMethod]
        public void TryToAddContainerToStack_TooManycontainersExpectFalseReturn_True()
        {
            //Arrange
            int position = 0;
            int maxHeight = 4;
            bool isFront = true;
            bool isBack = false;
            Stack stack = new Stack(position, maxHeight, isFront, isBack);
            Container container = new Container(30, false, false);
            int amountOfContainers = 5;
            bool result = true;

            //Act
            for (int i = 0; i < amountOfContainers; i++)
            {
                result = stack.TryToAddContainerToStack(container);
            }

            //Assert
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void TryToAddContainerToStack_AddtoAReservedStackExpectFalse_True()
        {
            //Arrange
            int position = 0;
            int maxHeight = 4;
            bool isFront = true;
            bool isBack = false;
            Stack stack = new Stack(position, maxHeight, isFront, isBack);
            stack.SetReserved();
            Container container = new Container(30, false, false);
            bool result;

            //Act
            result = stack.TryToAddContainerToStack(container);


            //Assert
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void TryToAddContainerToStack_AddCoolableNotToFront_True()
        {
            //Arrange
            int position = 2;
            Stack stack = new Stack(position, 4, false, false);
            Container container = new Container(30, false, true);
            bool result;

            //Act
            result = stack.TryToAddContainerToStack(container);


            //Assert
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void TryToAddContainerToStack_AddFourCoolableContainersToStackExpectContainersTheSame_True()
        {
            //Arrange
            int position = 0;
            Stack stack = new Stack(position, 4, true, false);
            Container container = new Container(30, false, true);
            Container containerTwo = new Container(15, false, true);

            //Act
            stack.TryToAddContainerToStack(container);
            stack.TryToAddContainerToStack(containerTwo);
            stack.TryToAddContainerToStack(container);
            stack.TryToAddContainerToStack(container);

            //Assert
            Assert.AreSame(container, stack.ContainerListReadable[0]);
            Assert.AreSame(container, stack.ContainerListReadable[1]);
            Assert.AreSame(containerTwo, stack.ContainerListReadable[2]);
            Assert.AreSame(container, stack.ContainerListReadable[3]);
        }

        [TestMethod]
        public void TryToAddContainerToStack_AddTwoValuableContainersToStackExpectFalseReturn_True()
        {
            //Arrange
            int position = 0;
            Stack stack = new Stack(position, 4, true, false);
            Container container = new Container(30, true, false);
            Container containerTwo = new Container(15, true, false);
            bool result;

            //Act
            stack.TryToAddContainerToStack(container);
            result = stack.TryToAddContainerToStack(container);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryToAddContainerToStack_AddTooMuchWeightExpectFalseReturn_True()
        {
            //Arrange
            int position = 0;
            Stack stack = new Stack(position, 10, true, false);
            Container container = new Container(30, true, false);
            bool result;

            //Act
            stack.TryToAddContainerToStack(container);
            stack.TryToAddContainerToStack(container);
            stack.TryToAddContainerToStack(container);
            stack.TryToAddContainerToStack(container);
            stack.TryToAddContainerToStack(container);
            stack.TryToAddContainerToStack(container);
            stack.TryToAddContainerToStack(container);
            stack.TryToAddContainerToStack(container);
            stack.TryToAddContainerToStack(container);
            result = stack.TryToAddContainerToStack(container);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
