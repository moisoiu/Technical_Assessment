using FluentAssertions;

namespace RoverApp.Tests;

public sealed class RoverTests
{
    [Fact]
    public void Rover_Should_HaveDefaultValue_When_IsInitializedCorrectly()
    {
        // Arrange
        var rover = new Rover(0, 0, DirectionEnum.North);

        // Act
        var position = rover.GetPosition();

        // Assert
        position.Should().Be("Rover Position: 0, 0, North");
    }

    [Fact]
    public void Rover_Should_TurnLeft_When_CorrectMovemenetIsSentCorrectly()
    {
        // Arrange
        var rover = new Rover(0, 0, DirectionEnum.North);

        // Act
        rover.Move(MovementEnum.Left);
        var position = rover.GetPosition();

        // Assert
        position.Should().Be("Rover Position: 0, 0, West");
    }

    [Fact]
    public void Rover_Should_TurnRight_When_CorrectMovemenetIsSentCorrectly()
    {
        // Arrange
        var rover = new Rover(0, 0, DirectionEnum.North);

        // Act
        rover.Move(MovementEnum.Right);
        var position = rover.GetPosition();

        // Assert
        position.Should().Be("Rover Position: 0, 0, East");
    }

    [Fact]
    public void Rover_Should_MoveForward_When_CorrectMovemenetIsSentCorrectly()
    {
        // Arrange
        var rover = new Rover(0, 0, DirectionEnum.North);

        // Act
        rover.Move(MovementEnum.Forward);
        var position = rover.GetPosition();

        // Assert
        position.Should().Be("Rover Position: 0, 1, North");
    }

    [Fact]
    public void Rover_Should_HandleMultipleMovementCorrectly_When_MultipleMoveCommandsAreSent()
    {
        // Arrange
        var rover = new Rover(0, 0, DirectionEnum.North);

        // Act
        rover.Move(MovementEnum.Forward, MovementEnum.Right, MovementEnum.Forward, MovementEnum.Right, MovementEnum.Forward, MovementEnum.Right, MovementEnum.Forward);
        var position = rover.GetPosition();

        // Assert
        position.Should().Be("Rover Position: 0, 0, West");
    }

    [Fact]
    public void Rover_Should_HandleMultipleMovementCorrectly_When_MultipleMoveCommandsAreSentAndThePossitionIsDifferent()
    {
        // Arrange
        var rover = new Rover(1, 2, DirectionEnum.North);

        // Act
        rover.Move(MovementEnum.Left, MovementEnum.Left, MovementEnum.Forward, MovementEnum.Left, MovementEnum.Forward, MovementEnum.Left, MovementEnum.Forward, MovementEnum.Forward);
        var position = rover.GetPosition();

        // Assert
        position.Should().Be("Rover Position: 2, 3, North");
    }

    [Fact]
    public void Rover_Should_MoveBackward_When_FacingNorth()
    {
        // Arrange
        var rover = new Rover(0, 0, DirectionEnum.North);

        // Act
        rover.Move(MovementEnum.Backward);

        // Assert
        rover.X.Should().Be(0);
        rover.Y.Should().Be(-1);
        rover.Direction.Should().Be(DirectionEnum.North);
    }

    [Fact]
    public void Rover_Should_MoveBackward_When_FacingEast()
    {
        // Arrange
        var rover = new Rover(0, 0, DirectionEnum.East);

        // Act
        rover.Move(MovementEnum.Backward);

        // Assert
        rover.X.Should().Be(-1);
        rover.Y.Should().Be(0);
        rover.Direction.Should().Be(DirectionEnum.East);
    }

    [Fact]
    public void Rover_Should_MoveBackward_When_FacingSouth()
    {
        // Arrange
        var rover = new Rover(0, 0, DirectionEnum.South);

        // Act
        rover.Move(MovementEnum.Backward);

        // Assert
        rover.X.Should().Be(0);
        rover.Y.Should().Be(1);
        rover.Direction.Should().Be(DirectionEnum.South);
    }

    [Fact]
    public void Rover_Should_MoveBackward_When_FacingWest()
    {
        // Arrange
        var rover = new Rover(0, 0, DirectionEnum.West);

        // Act
        rover.Move(MovementEnum.Backward);

        // Assert
        rover.X.Should().Be(1);
        rover.Y.Should().Be(0);
        rover.Direction.Should().Be(DirectionEnum.West);
    }

    [Fact]
    public void Rover_Should_StayInPlace_When_MovingForwardAndBackward()
    {
        // Arrange
        var rover = new Rover(0, 0, DirectionEnum.North);

        // Act
        rover.Move(MovementEnum.Forward, MovementEnum.Backward);

        // Assert
        rover.X.Should().Be(0);
        rover.Y.Should().Be(0);
        rover.Direction.Should().Be(DirectionEnum.North);
    }
}
