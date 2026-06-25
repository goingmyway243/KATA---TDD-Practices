namespace Greeting;


public class GreetingTest
{
  [Fact]
  public void Greet_ShouldReturnGreetingMessage_WhenNameIsProvided()
  {
    // Arrange
    string name = "Light";

    // Act
    string result = GreetingKata.Greet(name);

    // Assert
    Assert.Equal($"Hello, {name}.", result);
  }

  [Fact]
  public void Greet_ShouldReturnGreetingMessage_WhenNameIsNull()
  {
    // Act
    var result = GreetingKata.Greet(null);

    // Assert
    Assert.Equal("Hello, my friend.", result);
  }

  [Fact]
  public void Greet_ShouldReturnShoutGreetingMessage_WhenNameIsUppercase()
  {
    // Arrange
    var name = "LIGHT";

    // Act
    var result = GreetingKata.Greet(name);

    // Assert
    Assert.Equal($"HELLO, {name}!", result);
  }

  [Fact]
  public void Greet_ShouldReturnGreetingMessage_WhenNameIsArray()
  {
    // Arrange
    var names = new string[] { "Light", "Thunder", "Rover" };

    // Act
    var result = GreetingKata.Greet(names);

    // Assert
    Assert.Equal("Hello, Light, Thunder and Rover.", result);
  }

  [Fact]
  public void Greet_ShouldReturnMixingGreetingMessage_WhenNameIsArrayWithUppercase()
  {
    // Arrange
    var names = new string[] { "Light", "THUNDER", "Rover" };

    // Act
    var result = GreetingKata.Greet(names);

    // Assert
    Assert.Equal("Hello, Light and Rover. AND HELLO, THUNDER!", result);
  }

  [Fact]
  public void Greet_ShouldReturnGreetingMessage_WhenNameIsArrayWithEntrysWithComma()
  {
    // Arrange
    var names = new string[] { "Light", "Thunder, Rover" };

    // Act
    var result = GreetingKata.Greet(names);

    // Assert
    Assert.Equal("Hello, Light, Thunder and Rover.", result);
  }

  [Fact]
  public void
  Greet_ShouldReturnGreetingMessage_WhenNameIsArrayWithEntrysWithIntentionalEscapedComma()
  {
    // Arrange
    var names = new string[] { "Light", "\"Thunder, Rover\"" };

    // Act
    var result = GreetingKata.Greet(names);

    // Assert
    Assert.Equal("Hello, Light and Thunder, Rover.", result);
  }

  [Fact]
  public void 
  Greet_ShouldReturnGreetingMessage_WhenNameIsArrayWithNullEntry()
  {
    // Arrange
    var names = new string?[] { "Light", null, "Rover" };

    // Act
    var result = GreetingKata.Greet(names);

    // Assert
    Assert.Equal("Hello, Light and Rover.", result);
  }
}