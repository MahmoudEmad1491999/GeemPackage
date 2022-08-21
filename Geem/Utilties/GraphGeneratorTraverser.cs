namespace Geem.Utilities;
using System.Text;
using System.Collections.Generic;
using Antlr4.Runtime.Tree;

public class GraphGeneratorTraverser
{
    private GraphGeneratorTraverser() { }
    public static Dictionary<string, int> node_index_map = new Dictionary<string, int>() {
        {"ProgramContext", 0},
        {"GlobalVariableDeclarationContext", 0},
        {"FunctionDeclarationContext", 0},
        {"OperationDeclarationContext", 0},
        {"DatatypeContext", 0},
        {"ParameterContext", 0},
        {"VariableDeclaratationStatementContext", 0},
        {"VaraibleAssignmentStatementContext", 0},
        {"IfStatementContext", 0},
        {"WhileStatementContext", 0},
        {"BreakStatementContext", 0},
        {"ContinueStatmentContext", 0},
        {"ReturnStatementContext", 0},
        {"ResultStatementContext", 0},
        {"ProcedureCallStatementContext", 0},
        {"NumberExprContext", 0},
        {"VariableReadExprContext", 0},
        {"BnotExprContext", 0},
        {"LnotExprContext", 0},
        {"NegationExprContext", 0},
        {"ProcedureCallExprContext", 0},
        {"LorExprContext", 0},
        {"LandExprContext", 0},
        {"BorExprContext", 0},
        {"BxorExprContext", 0},
        {"NotEqualExprContext", 0},
        {"EqualExprContext", 0},
        {"GreaterThanOrEqualExprContext", 0},
        {"GreaterThanExprContext", 0},
        {"LessThanOrEqualExprContext", 0},
        {"LessThanExprContext", 0},
        {"ShiftLeftExprContext", 0},
        {"ShiftRigthExprContext", 0},
        {"ShiftRightArithmeticExprContext", 0},
        {"AddExprContext", 0},
        {"SubtractExprContext", 0},
        {"MultiplyExprContext", 0},
        {"DivideExprContext", 0},
        {"ModulsExprContext", 0},
        {"TerminalNodeImpl", 0}
        };

    public static string GenerateGraph(IParseTree node)
    {
        StringBuilder result = new StringBuilder("digraph test {");
        result.Append(_GenerateGraph(node, 0));
        result.AppendLine("}");
        return result.ToString();
    }
    private static string _GenerateGraph(IParseTree node, int node_index)
    {
        StringBuilder result = new StringBuilder();
        if (node != null)
        {
            string node_type_name = node.GetType().Name;

            result.AppendLine($"{node_type_name}_{node_index} [label=\"{node_type_name}\"];");
            string child_node_type_name = null;
            IParseTree child_node = null;
            for (int index = 0; index < node.ChildCount; index++)
            {
                child_node = node.GetChild(index);
                child_node_type_name = child_node.GetType().Name;

                if (child_node is TerminalNodeImpl)
                {
                    int child_node_index = node_index_map[child_node_type_name]++;

                    result.AppendLine($"{child_node_type_name}_{child_node_index} [label=\"{child_node.GetText()}\"];");
                    result.AppendLine($"{node_type_name}_{node_index} -> {child_node_type_name}_{child_node_index};");
                }
                else
                {
                    int child_node_index = node_index_map[child_node_type_name]++;

                    result.AppendLine($"{child_node_type_name}_{child_node_index} [label=\"{child_node_type_name}\"];");
                    result.AppendLine($"{node_type_name}_{node_index} -> {child_node_type_name}_{child_node_index};");
                    result.Append(_GenerateGraph(node.GetChild(index), child_node_index));
                }
            }
            return result.ToString();
        }
        return "";

    }

}
