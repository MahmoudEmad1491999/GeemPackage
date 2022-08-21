[assembly: CLSCompliant(false)]

namespace Geem;
using System;
using System.Diagnostics;
using Geem.SyntaxAnalyzer;
using Geem.Utilities;

using Antlr4.Runtime;

public class Program
{
    public static void Main(String[] args)
    {
        ICharStream charStream = CharStreams.fromPath(args[0]);
        GeemLexer geemLexer = new(charStream);
        CommonTokenStream commonTokenStream = new CommonTokenStream(geemLexer);
        GeemParser geemParser = new(commonTokenStream);
        var program = geemParser.program();
        string dot_graph = GraphGeneratorTraverser.GenerateGraph(program);
        Console.WriteLine(dot_graph);
        using(var dot_graph_file = File.CreateText("_temp.dot"))
        {
            dot_graph_file.Write(dot_graph);
        }
        

        using(var process = Process.Start("dot", "-Tsvg _temp.dot > _temp.svg")) {
        }
   }

}
