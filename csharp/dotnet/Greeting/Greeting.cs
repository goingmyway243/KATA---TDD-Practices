namespace Greeting;

public class GreetingKata
{
  private static string GreetSingle(string? name)
  {
    if (string.IsNullOrEmpty(name))
    {
      return "Hello, my friend.";
    }

    if (string.Equals(name, name.ToUpper()))
    {
      return $"HELLO, {name}!";
    }

    return $"Hello, {name}.";
  }

  private static string GreetMultiple(string[] names)
  {
    var uppercaseNames = names.Where(n => string.Equals(n, n.ToUpper())).ToArray();

    var normalNames = names.Except(uppercaseNames).ToArray();

    var greeting = "";

    if (normalNames.Length > 0)
    {
      var formattedNames = string.Join(", ", normalNames.Take(normalNames.Length - 1));
      greeting = $"Hello, {formattedNames} and {normalNames[normalNames.Length - 1]}.";
    }

    if (uppercaseNames.Length > 0)
    {
      var shoutGreeting = "";
      if (uppercaseNames.Length == 1)
      {
        shoutGreeting = GreetSingle(uppercaseNames[0]);
      }
      else
      {
        var formatedUppercaseNames = string.Join(", ", uppercaseNames.Take(uppercaseNames.Length - 1));
        shoutGreeting = $"HELLO, {formatedUppercaseNames} AND {uppercaseNames[uppercaseNames.Length - 1]}!";
      }

      if (greeting.Length > 0)
      {
        greeting += " AND ";
      }

      greeting += shoutGreeting;
    }

    return greeting;
  }

  public static string Greet(params string?[]? names)
  {
    if (names == null || names.Length == 0)
    {
      return GreetSingle(null);
    }

    var filteredNames = names.Where(n => n != null).Select(n => n!).SelectMany(n =>
    {
      if (n.StartsWith('"') && n.EndsWith('"'))
      {
        return [n.Substring(1, n.Length - 2)];
      }

      return n.Split(',');
    }).Select(n => n.Trim()).ToArray();

    if (filteredNames.Length == 1)
    {
      return GreetSingle(filteredNames[0]);
    }

    return GreetMultiple(filteredNames);
  }
}