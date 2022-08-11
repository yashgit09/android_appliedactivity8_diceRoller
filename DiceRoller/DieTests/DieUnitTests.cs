using DiceRoller.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace DieTests
{
    [TestClass]
    public class DieUnitTests
    {
        private Die def = new Die();
        [TestMethod]
        public void DieNotNull()
        {
            
            def.Should().NotBeNull();
        }

        [TestMethod]
        public void DieHasAllDefaultValues()
        {
            /*
             * Default values should be:
             * name:        d6
             * numsides     6
             * currentSides ?
             */
            def.Name.Should().Be("d6");
            def.NumSides.Should().Be(6);
            def.CurrentSide.Should().BeInRange(1, 6);
        }

        [TestMethod]
        [DataRow(3, "d3")]
        [DataRow(3, "d3")]
        [DataRow(4, "d4")]
        [DataRow(8, "d8")]
        [DataRow(10, "d10")]
        [DataRow(12, "d12")]
        [DataRow(20, "d20")]
        public void DieHasCustomSides(int sides, string name)
        {
            Die d = new Die(sides);
            d.Name.Should().Be(name);
            d.NumSides.Should().Be(sides);
            d.CurrentSide.Should().BeInRange(1, sides);
        }

        [TestMethod]
        [DataRow("d3", 3)]
        [DataRow("d3", 3)]
        [DataRow("d4", 4)]
        [DataRow("d8", 8)]
        [DataRow("d10", 10)]
        [DataRow("d12", 12)]
        [DataRow("d20", 20)]
        public void DieHasCustomName( string name, int sides)
        {
            Die d = new Die(name,sides);
            d.Name.Should().Be(name);
            d.NumSides.Should().Be(sides);
            d.CurrentSide.Should().BeInRange(1, sides);

        }

        [TestMethod]
        [DataRow(3,2)]
        [DataRow(3,2)]
        [DataRow(4,2)]
        [DataRow(8,2)]
        [DataRow(10,2)]
        [DataRow(12,2)]
        [DataRow(20,2)]
        public void SetSideUpChangesSide(int sides, int newSide)
        {
            Die d = new Die(sides);
            d.SetSide(newSide);
            d.CurrentSide.Should().Be(newSide);
        }

        [TestMethod]
        [DataRow(3, 2)]
        [DataRow(3, 2)]
        [DataRow(4, 2)]
        [DataRow(8, 2)]
        [DataRow(10, 2)]
        [DataRow(12, 2)]
        [DataRow(20, 2)]
        public void SetSideUpSetsValidSide(int sides, int newSide)
        {
            Die d = new Die(sides);
            d.SetSide(newSide);
            d.CurrentSide.Should().BeInRange(1, sides);
        }

        [TestMethod]
        [DataRow(3)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(8)]
        [DataRow(10)]
        [DataRow(12)]
        [DataRow(20)]
        public void NumSidesShouldNotBeNegative(int sides)
        {
            Die d = new Die(sides);
            d.NumSides.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public void RollSetsSideCorrectly()
        {
            
            for(int i = 0; i < 100; i++)
            {
                def.Roll();
                def.CurrentSide.Should().BeInRange(1, 6);

            }

        }

        [TestMethod]
        [DataRow(3)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(8)]
        [DataRow(10)]
        [DataRow(12)]
        [DataRow(20)]
        public void RollSetsSideCorrectlyForCustomSides(int sides)
        {
            Die d = new Die(sides);
            for (int i = 0; i < 100; i++)
            {
                d.Roll();
                d.CurrentSide.Should().BeInRange(1, sides);

            }

        }
    }
}
