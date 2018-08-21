using battleships.api.Models;
using battleships.api.Services;
using System;
using Xunit;

namespace battleships.tests
{
    public class GameBoardCalculationsTests
    {
        [Fact]
        public void When_BattleshipOfLength1_IsAtA1EastWest_ThenItShouldBeInboundsWithASinglePositionA1()
        {
            var battleship = new Battleship { Length = 1 };
            var location = new Location { Column = 'A', Row = 1, Placement = Direction.EastWest };

            var (positions, inbounds) = GameBoardCalculations.ValidateLocation(battleship, location);

            Assert.True(inbounds);
            Assert.Contains(positions, p => p.Column == 'A' && p.Row == 1);
        }

        [Fact]
        public void When_BattleshipOfLength1_IsAtJ1EastWest_ThenItShouldBeInboundsWithASinglePositionJ1()
        {
            var battleship = new Battleship { Length = 1 };
            var location = new Location { Column = 'J', Row = 1, Placement = Direction.EastWest };

            var (positions, inbounds) = GameBoardCalculations.ValidateLocation(battleship, location);

            Assert.True(inbounds);
            Assert.Contains(positions, p => p.Column == 'J' && p.Row == 1);
        }

        [Fact]
        public void When_BattleshipOfLength1_IsAtA10EastWest_ThenItShouldBeInboundsWithASinglePositionA10()
        {
            var battleship = new Battleship { Length = 1 };
            var location = new Location { Column = 'A', Row = 10, Placement = Direction.EastWest };

            var (positions, inbounds) = GameBoardCalculations.ValidateLocation(battleship, location);

            Assert.True(inbounds);
            Assert.Contains(positions, p => p.Column == 'A' && p.Row == 10);
        }

        [Fact]
        public void When_BattleshipOfLength1_IsAtJ10EastWest_ThenItShouldBeInboundsWithASinglePositionJ10()
        {
            var battleship = new Battleship { Length = 1 };
            var location = new Location { Column = 'J', Row = 10, Placement = Direction.EastWest };

            var (positions, inbounds) = GameBoardCalculations.ValidateLocation(battleship, location);

            Assert.True(inbounds);
            Assert.Contains(positions, p => p.Column == 'J' && p.Row == 10);
        }

        [Fact]
        public void When_BattleshipOfLength1_IsAtA1NorthSouth_ThenItShouldBeInboundsWithASinglePositionA1()
        {
            var battleship = new Battleship { Length = 1 };
            var location = new Location { Column = 'A', Row = 1, Placement = Direction.NorthSouth };

            var (positions, inbounds) = GameBoardCalculations.ValidateLocation(battleship, location);

            Assert.True(inbounds);
            Assert.Contains(positions, p => p.Column == 'A' && p.Row == 1);
        }

        [Fact]
        public void When_BattleshipOfLength1_IsAtJ1NorthSouth_ThenItShouldBeInboundsWithASinglePositionJ1()
        {
            var battleship = new Battleship { Length = 1 };
            var location = new Location { Column = 'J', Row = 1, Placement = Direction.NorthSouth };

            var (positions, inbounds) = GameBoardCalculations.ValidateLocation(battleship, location);

            Assert.True(inbounds);
            Assert.Contains(positions, p => p.Column == 'J' && p.Row == 1);
        }

        [Fact]
        public void When_BattleshipOfLength1_IsAtA10NorthSouth_ThenItShouldBeInboundsWithASinglePositionA10()
        {
            var battleship = new Battleship { Length = 1 };
            var location = new Location { Column = 'A', Row = 10, Placement = Direction.NorthSouth };

            var (positions, inbounds) = GameBoardCalculations.ValidateLocation(battleship, location);

            Assert.True(inbounds);
            Assert.Contains(positions, p => p.Column == 'A' && p.Row == 10);
        }

        [Fact]
        public void When_BattleshipOfLength1_IsAtJ10NorthSouth_ThenItShouldBeInboundsWithASinglePositionJ10()
        {
            var battleship = new Battleship { Length = 1 };
            var location = new Location { Column = 'J', Row = 10, Placement = Direction.NorthSouth };

            var (positions, inbounds) = GameBoardCalculations.ValidateLocation(battleship, location);

            Assert.True(inbounds);
            Assert.Contains(positions, p => p.Column == 'J' && p.Row == 10);
        }

        [Fact]
        public void When_BattleshipOfLength11_IsAtA1EastWest_ThenItShouldNotBeInbounds()
        {
            var battleship = new Battleship { Length = 11 };
            var location = new Location { Column = 'A', Row = 1, Placement = Direction.EastWest };

            var (positions, inbounds) = GameBoardCalculations.ValidateLocation(battleship, location);

            Assert.False(inbounds);
            Assert.Null(positions);
        }

        [Fact]
        public void When_BattleshipOfLength2_IsAtJ1EastWest_ThenItShouldNotBeInbounds()
        {
            var battleship = new Battleship { Length = 2 };
            var location = new Location { Column = 'J', Row = 1, Placement = Direction.EastWest };

            var (positions, inbounds) = GameBoardCalculations.ValidateLocation(battleship, location);

            Assert.False(inbounds);
            Assert.Null(positions);
        }

        [Fact]
        public void When_BattleshipOfLength11_IsAtA10EastWest_ThenItShouldNotBeInbounds()
        {
            var battleship = new Battleship { Length = 11 };
            var location = new Location { Column = 'A', Row = 10, Placement = Direction.EastWest };

            var (positions, inbounds) = GameBoardCalculations.ValidateLocation(battleship, location);

            Assert.False(inbounds);
            Assert.Null(positions);
        }

        [Fact]
        public void When_BattleshipOfLength2_IsAtJ10EastWest_ThenItShouldNotBeInbounds()
        {
            var battleship = new Battleship { Length = 2 };
            var location = new Location { Column = 'J', Row = 10, Placement = Direction.EastWest };

            var (positions, inbounds) = GameBoardCalculations.ValidateLocation(battleship, location);

            Assert.False(inbounds);
            Assert.Null(positions);
        }

        [Fact]
        public void When_BattleshipOfLength11_IsAtA1NorthSouth_ThenItShouldNotBeInbounds()
        {
            var battleship = new Battleship { Length = 11 };
            var location = new Location { Column = 'A', Row = 1, Placement = Direction.NorthSouth };

            var (positions, inbounds) = GameBoardCalculations.ValidateLocation(battleship, location);

            Assert.False(inbounds);
            Assert.Null(positions);
        }

        [Fact]
        public void When_BattleshipOfLength11_IsAtJ1NorthSouth_ThenItShouldNotBeInbounds()
        {
            var battleship = new Battleship { Length = 11 };
            var location = new Location { Column = 'J', Row = 1, Placement = Direction.NorthSouth };

            var (positions, inbounds) = GameBoardCalculations.ValidateLocation(battleship, location);

            Assert.False(inbounds);
            Assert.Null(positions);
        }

        [Fact]
        public void When_BattleshipOfLength2_IsAtA10NorthSouth_ThenItShouldNotBeInbounds()
        {
            var battleship = new Battleship { Length = 2 };
            var location = new Location { Column = 'A', Row = 10, Placement = Direction.NorthSouth };

            var (positions, inbounds) = GameBoardCalculations.ValidateLocation(battleship, location);

            Assert.False(inbounds);
            Assert.Null(positions);
        }

        [Fact]
        public void When_BattleshipOfLength2_IsAtJ10NorthSouth_ThenItShouldNotBeInbounds()
        {
            var battleship = new Battleship { Length = 2 };
            var location = new Location { Column = 'J', Row = 10, Placement = Direction.NorthSouth };

            var (positions, inbounds) = GameBoardCalculations.ValidateLocation(battleship, location);

            Assert.False(inbounds);
            Assert.Null(positions);
        }

        [Fact]
        public void When_BattleshipOfLength10_IsAtA1NorthSouth_ThenItShouldBeInboundsWithASinglePositionA1()
        {
            var battleship = new Battleship { Length = 10 };
            var location = new Location { Column = 'A', Row = 1, Placement = Direction.NorthSouth };

            var (positions, inbounds) = GameBoardCalculations.ValidateLocation(battleship, location);

            Assert.True(inbounds);
            Assert.Contains(positions, p => p.Column == 'A' && p.Row == 1);
        }

        [Fact]
        public void When_BattleshipOfLength10_IsAtJ1NorthSouth_ThenItShouldBeInboundsWithASinglePositionJ1()
        {
            var battleship = new Battleship { Length = 10 };
            var location = new Location { Column = 'J', Row = 1, Placement = Direction.NorthSouth };

            var (positions, inbounds) = GameBoardCalculations.ValidateLocation(battleship, location);

            Assert.True(inbounds);
            Assert.Contains(positions, p => p.Column == 'J' && p.Row == 1);
        }

        [Fact]
        public void When_BattleshipOfLength10_IsAtA1EastWest_ThenItShouldBeInboundsWithASinglePositionA1()
        {
            var battleship = new Battleship { Length = 10 };
            var location = new Location { Column = 'A', Row = 1, Placement = Direction.EastWest };

            var (positions, inbounds) = GameBoardCalculations.ValidateLocation(battleship, location);

            Assert.True(inbounds);
            Assert.Contains(positions, p => p.Column == 'A' && p.Row == 1);
        }

        [Fact]
        public void When_BattleshipOfLength10_IsAtA10EastWest_ThenItShouldBeInboundsWithASinglePositionA10()
        {
            var battleship = new Battleship { Length = 10 };
            var location = new Location { Column = 'A', Row = 10, Placement = Direction.EastWest };

            var (positions, inbounds) = GameBoardCalculations.ValidateLocation(battleship, location);

            Assert.True(inbounds);
            Assert.Contains(positions, p => p.Column == 'A' && p.Row == 10);
        }

    }
}
