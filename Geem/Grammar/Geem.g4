grammar Geem;

program: (
		globalVariableDeclaration
		| functionDeclaration
		| operationDeclaration
	)*;

operationDeclaration:
	datatype ')' (parameter ('،' parameter)*)? '(' '}' statement* '{' ;

globalVariableDeclaration:
	datatype Identifer '=' expression '؛';

functionDeclaration:
	datatype Identifer ')' (parameter ('،' parameter)*)? '(' '}' (
		statement
	)* '{' ;

expression:
	expression '٪' expression							# modulsExpr
	| expression '÷' expression							# divideExpr
	| expression '×' expression							# multiplyExpr
	| expression '-' expression							# subtractExpr
	| expression '+' expression							# addExpr
	| expression '<<' expression						# shiftLeftExpr
	| expression '>>' expression						# shiftRightExpr
	| expression '>>>' expression						# shiftRightArithmeticExpr
	| expression '<' expression							# greaterThanExpr
	| expression '>=' expression						# lessThanOrEqualExpr
	| expression '>' expression							# lessThanExpr
	| expression '<=' expression						# greaterThanOrEqualExpr
	| expression '==' expression						# equalExpr
	| expression '!=' expression						# notEqualExpr
	| expression '&' expression							# bandExpr
	| expression '^' expression							# bxorExpr
	| expression '|' expression							# borExpr
	| expression '&&' expression						# landExpr
	| expression '||' expression						# lorExpr
	| Identifer ')' (expression ('،' expression)*)? '('	# procedureCallExpr
	| '-' expression									# negationExpr
	| '!' expression									# lnotExpr
	| '~' expression									# bnotExpr
	| Identifer											# variableReadExpr
	| Number											# numberExpr;

parameter: datatype Identifer;

statement:
	Identifer ')' (expression ('،' expression)*)? '('	# procedureCallStatement
	| Identifer '=' expression							# variableAssignmentStatement
	| Identifer Identifer '=' expression				# variableDeclarationStatement
	| 'إذا' ')' expression '(' '}' statement* '{' (
		'أوإذا' ')' expression '(' '}' statement* '{'
	)* ('أو' '}' statement* '{')?					# ifStatement
	| 'طالما' ')' expression '(' '}' statement* '{'	# whileStatement
	| 'تخطى' '؛'									# breakStatement
	| 'تجاوز' '؛'									# continueStatement
	| 'الناتج' expression '؛'						# resultStatement
	| 'رجوع' '؛'									# returnStatement;

datatype: Identifer | datatype '&' | datatype '*';

Identifer:
	[a-z\u0621-\u064a_][a-z\u0621-\u064a_\u0660-\u06690-9]*;

Number: [\u0660-\u0669]+;
Space: (' ' | '\t' | '\n' )+ -> skip;

