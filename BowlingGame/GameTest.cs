namespace BowlingGame;

public class GameTest
{
  [Fact]
  public void GutterGame()
  {
    // Arrange
    var game = new Game();

    // Act
    for (int i = 0; i < 20; i++)
    {
      game.Roll(0);
    }

    // Assert
    Assert.Equal(0, game.Score());
  }

  [Fact]
  public void AllOnes()
  {
    // Arrange
    var game = new Game();

    // Act
    for (int i = 0; i < 20; i++)
    {
      game.Roll(1);
    }

    // Assert
    Assert.Equal(20, game.Score());
  }

  [Fact]
  public void OneSpare()
  {
    // Arrange
    var game = new Game();

    // Act
    game.Roll(5);
    game.Roll(5); // Spare
    game.Roll(3);

    // Assert
    Assert.Equal(16, game.Score());
  }

  [Fact]
  public void SpareFollowedByNormalRoll()
  {
    // Arrange
    var game = new Game();

    // Act
    game.Roll(4);
    game.Roll(6); // Spare
    game.Roll(2);
    game.Roll(3);

    // Assert
    Assert.Equal(17, game.Score());
  }

  [Fact]
  public void OneStrike()
  {
    // Arrange
    var game = new Game();

    // Act
    game.Roll(10); // Strike
    game.Roll(3);
    game.Roll(4);

    // Assert
    Assert.Equal(24, game.Score());
  }

  [Fact]
  public void StrikeFollowedBySpare()
  {
    // Arrange
    var game = new Game();

    // Act
    game.Roll(10); // Strike
    game.Roll(5);
    game.Roll(5); // Spare
    game.Roll(3);

    // Assert
    Assert.Equal(36, game.Score());
  }

  [Fact]
  public void TwoConsecutiveStrikes()
  {
    // Arrange
    var game = new Game();

    // Act
    game.Roll(10); // Strike
    game.Roll(10); // Strike
    game.Roll(3);
    game.Roll(4);

    // Assert
    Assert.Equal(47, game.Score());
  }
}