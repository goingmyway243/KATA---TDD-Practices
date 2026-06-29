namespace BowlingGame;

public class Frame
{
  public int? FirstRoll;
  public int? SecondRoll;
  public int BonusScore = 0;
  public int Score { get => (FirstRoll ?? 0) + (SecondRoll ?? 0) + BonusScore;}

  public bool IsStrike { get => FirstRoll == 10; }

  public bool IsSpare { get => (FirstRoll ?? 0) + (SecondRoll ?? 0) == 10 && !IsStrike; }
}