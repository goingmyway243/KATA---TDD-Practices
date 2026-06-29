namespace BowlingGame;

public class Game
{
  private int[] _rolls = new int[21];
  private int _currentRoll = 0;

  public void Roll(int pins)
  {
    _rolls[_currentRoll] = pins;
    _currentRoll++;
  }

  public int Score()
  {
    var score = 0;
    var frameIndex = 0;
    for (var frame = 0; frame < 10; frame++)
    {
      if (IsStrike(frameIndex))
      {
        score += 10 + CalculateBonus(frameIndex, 2);
        frameIndex++;
        continue;
      }
      if (IsSpare(frameIndex))
      {
        score += 10 + CalculateBonus(frameIndex + 1, 1);
      }
      else
      {
        score += SumOfBallsInFrame(frameIndex);
      }

      frameIndex += 2;
    }

    return score;
  }

  private bool IsStrike(int frameIndex)
  {
    return _rolls[frameIndex] == 10;
  }

  private bool IsSpare(int frameIndex)
  {
    return _rolls[frameIndex] + _rolls[frameIndex + 1] == 10;
  }

  private int SumOfBallsInFrame(int frameIndex)
  {
    return _rolls[frameIndex] + _rolls[frameIndex + 1];
  }

  private int CalculateBonus(int frameIndex, int bonusRolls)
  {
    var bonus = 0;
    for (var i = 1; i <= bonusRolls; i++)
    {
      bonus += _rolls[frameIndex + i];
    }
    return bonus;
  }
}