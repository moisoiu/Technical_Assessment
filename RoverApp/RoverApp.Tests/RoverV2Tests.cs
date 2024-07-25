using FluentAssertions;

namespace RoverApp.Tests;

public sealed class RoverV2Tests
{
    private readonly MovementHandler _movementHandler;

    public RoverV2Tests()
    {
        _movementHandler = CreateMovementHandler();
    }

    [Fact]
    public void Rover_Should_HaveDefaultValue_When_IsInitializedCorrectly()
    {
        // Arrange
        var rover = new RoverV2(0, 0, DirectionEnum.North, _movementHandler);

        // Act
        var position = rover.GetPosition();

        // Assert
        position.Should().Be("Rover Position: 0, 0, North");
    }

    [Fact]
    public void Rover_Should_MoveForward_When_CorrectMovemenetIsSentCorrectly()
    {
        // Arrange
        var rover = new RoverV2(0, 0, DirectionEnum.North, _movementHandler);

        // Act
        rover.Move(MovementEnum.Forward);

        // Assert
        rover.GetPosition().Should().Be("Rover Position: 0, 1, North");
    }

    [Fact]
    public void Rover_Should_MoveUp_When_FacingSouthAndBackwardCommandIsIssued()
    {
        // Arrange
        var rover = new RoverV2(0, 0, DirectionEnum.South, _movementHandler);

        // Act
        rover.Move(MovementEnum.Backward);

        // Assert
        rover.GetPosition().Should().Be("Rover Position: 0, 1, South");
    }

    [Fact]
    public void Rover_Should_FaceWest_When_TurnLeftCommandIsIssuedFacingNorth()
    {
        // Arrange
        var rover = new RoverV2(0, 0, DirectionEnum.North, _movementHandler);

        // Act
        rover.Move(MovementEnum.Left);

        // Assert
        rover.GetPosition().Should().Be("Rover Position: 0, 0, West");
    }

    [Fact]
    public void Rover_Should_FaceEast_When_TurnRightCommandIsIssuedFacingNorth()
    {
        // Arrange
        var rover = new RoverV2(0, 0, DirectionEnum.North, _movementHandler);

        // Act
        rover.Move(MovementEnum.Right);

        // Assert
        rover.GetPosition().Should().Be("Rover Position: 0, 0, East");
    }

    [Fact]
    public void Rover_Should_ReachCorrectPosition_When_AfterMultipleCommands()
    {
        // Arrange
        var rover = new RoverV2(0, 0, DirectionEnum.North, _movementHandler);

        // Act
        rover.Move(MovementEnum.Right, MovementEnum.Forward, MovementEnum.Forward, MovementEnum.Left, MovementEnum.Forward);

        // Assert
        rover.GetPosition().Should().Be("Rover Position: 2, 1, North");
    }

    private MovementHandler CreateMovementHandler()
    {
        var strategies = new Dictionary<MovementEnum, IMovementStrategy>
            {
                { MovementEnum.Left, new TurnLeftStrategy() },
                { MovementEnum.Right, new TurnRightStrategy() },
                { MovementEnum.Forward, new MoveForwardStrategy() },
                { MovementEnum.Backward, new MoveBackwardStrategy() }
            };

        return new MovementHandler(strategies);
    }
}
