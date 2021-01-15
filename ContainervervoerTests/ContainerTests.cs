using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Containervervoer;
using Logic;

namespace ContainervervoerTests
{
    [TestClass]
    public class ContainerTests
    {
        [TestMethod]
        public void Container_InstantiateContainerAndCheckIfPropertiesAreEqual_True()
        {
            //Arrange
            int weight = 30;
            bool valuable = true;
            bool coolable = true;

            //Act
            Container container = new Container(weight, valuable, coolable);

            //Assert
            Assert.AreEqual(weight, container.Weight);
            Assert.AreEqual(valuable, container.Valuable);
            Assert.AreEqual(coolable, container.Coolable);
        }
    }
}
