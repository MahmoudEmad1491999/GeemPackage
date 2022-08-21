using Xunit;
namespace GeemTest;
using Antlr4.Runtime;
using Geem.SyntaxAnalyzer;
using System;
public class UnitTest1
{
    [Fact]
    public void simpleVariableDeclaration()
    {
        ICharStream charStream = CharStreams.fromPath("/home/mahmoud/Projects/csharp/GeemTest/TestSourceFiles/simpleVariableDeclaration.geem");
        GeemLexer lexer = new(charStream);
        CommonTokenStream commonTokenStream = new(lexer);
        GeemParser parser = new(commonTokenStream);
        Assert.Equal(-1 , 1);
        foreach(var token in commonTokenStream.GetTokens())
        {
            Console.WriteLine($"Ln: {token.Line}, Col: {token.Column}, Text: {token.Text}");
        }

    }
}
