using Xunit.Abstractions;

namespace Translator.Test;

public class TranslatorTest
{
    private ITestOutputHelper output;
    private Translator translator = new();

    public TranslatorTest(ITestOutputHelper output)
    {
        this.output = output;
        translator.Register("hello", "hola");
        translator.Register("world", "mundo");
    }

    [Fact]
    public void TranslateSingleWord()
    {
        var result = translator.Translate("hello");
        Assert.Equal("hola", result);
        output.WriteLine(result);
    }

    [Fact]
    public void TranslateLowerCaseSentence()
    {
        var result = translator.Translate("hello world");
        Assert.Equal("hola mundo", result);
        output.WriteLine(result);
    }

    [Fact]
    public void TranslateTitleCaseSentence()
    {
        var result = translator.Translate("Hello World");
        Assert.Equal("Hola Mundo", result);
        output.WriteLine(result);
    }

    [Fact]
    public void TranslateSentenceWithPunctuation()
    {
        var result = translator.Translate("Hello, world!");
        Assert.Equal("Hola, mundo!", result);
        output.WriteLine(result);
    }
}
