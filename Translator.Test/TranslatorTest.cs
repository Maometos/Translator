namespace Translator.Test;

public class TranslatorTest
{
    [Fact]
    public void TestTranslation()
    {
        var translator = new Translator();

        translator.AddWord("hello", "hola");
        translator.AddWord("world", "mundo");

        var input = "Hello, world!";
        var output = translator.Translate(input);

        Assert.Equal("Hola, mundo!", output);
    }
}
