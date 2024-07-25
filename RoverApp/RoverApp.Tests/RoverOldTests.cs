using FluentAssertions;

namespace RoverApp.Tests;

public class RoverOldTests
{
    [Fact]
    public void RoverOld_Should_HaveDefaultValue_When_IsInitializedCorrectly()
    {
        // Arrange
        var rover = new RoverOld(0, 0, 'N');

        // Act
        var position = rover.GetPosition();

        // Assert
        position.Should().Be("Rover Position: 0, 0, N");
    }

    [Fact]
    public void RoverOld_Should_TurnLeft_When_CorrectMovemenetIsSentCorrectly()
    {
        // Arrange
        var rover = new RoverOld(0, 0, 'N');

        // Act
        rover.Move("L");
        var position = rover.GetPosition();

        // Assert
        position.Should().Be("Rover Position: 0, 0, W");
    }

    [Fact]
    public void RoverOld_Should_TurnRight_When_CorrectMovemenetIsSentCorrectly()
    {
        // Arrange
        var rover = new RoverOld(0, 0, 'N');

        // Act
        rover.Move("R");
        var position = rover.GetPosition();

        // Assert
        position.Should().Be("Rover Position: 0, 0, E");
    }

    [Fact]
    public void RoverOld_Should_MoveForward_When_CorrectMovemenetIsSentCorrectly()
    {
        // Arrange
        var rover = new RoverOld(0, 0, 'N');

        // Act
        rover.Move("M");
        var position = rover.GetPosition();

        // Assert
        position.Should().Be("Rover Position: 0, 1, N");
    }

    [Fact]
    public void RoverOld_Should_HandleMultipleMovementCorrectly_When_MultipleMoveCommandsAreSent()
    {
        // Arrange
        var rover = new RoverOld(0, 0, 'N');

        // Act
        rover.Move("MMRMMRMRRM");
        var position = rover.GetPosition();

        // Assert
        position.Should().Be("Rover Position: 2, 2, N");
    }

    [Fact]
    public void RoverOld_Should_HandleMultipleMovementCorrectly_When_MultipleMoveCommandsAreSentAndThePossitionIsDifferent()
    {
        // Arrange
        var rover = new RoverOld(1, 2, 'N');

        // Act
        rover.Move("LMLMLMLMM");
        var position = rover.GetPosition();

        // Assert
        position.Should().Be("Rover Position: 1, 3, N");
    }
}