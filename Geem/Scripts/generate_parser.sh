#! /bin/bash
java -jar ./ThirdParty/antlr-4.10.1-complete.jar -Dlanguage=CSharp -no-visitor -no-listener -Xexact-output-dir -o ./SyntaxAnalyzer/ -package Geem.SyntaxAnalyzer ./Grammar/Geem.g4
