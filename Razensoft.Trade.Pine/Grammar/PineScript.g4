grammar PineScript;

COND : '?' ;
COND_ELSE : ':' ;
OR : 'or' ;
AND : 'and' ;
NOT : 'not' ;
EQ : '==' ;
NEQ : '!=' ;
GT : '>' ;
GE : '>=' ;
LT : '<' ;
LE : '<=' ;
PLUS : '+' ;
MINUS : '-' ;
MUL : '*' ;
DIV : '/' ;
MOD : '%' ;
COMMA : ',' ;
ARROW : '=>' ;
LPAR : '(' ;
RPAR : ')' ;
LSQBR : '[' ;
RSQBR : ']' ;
DEFINE : '=' ;
IF_COND : 'if' ;
IF_COND_ELSE : 'else' ;
BEGIN : '|BEGIN|' ;
END : '|END|' ;
ASSIGN : ':=' ;
FOR_STMT : 'for' ;
FOR_STMT_TO : 'to' ;
FOR_STMT_BY : 'by' ;
BREAK : 'break' ;
CONTINUE : 'continue' ;
LBEG : '|B|' ;
LEND : '|E|' ;
PLEND : '|PE|' ;
INT_LITERAL : ( '0' .. '9' )+ ;
FLOAT_LITERAL : ( '.' DIGITS ( EXP )? | DIGITS ( '.' ( DIGITS ( EXP )? )? | EXP ) );
STR_LITERAL : ( '"' ( ESC | ~ ( '\\' | '\n' | '"' ) )* '"' | '\'' ( ESC | ~ ( '\\' | '\n' | '\'' ) )* '\'' );
BOOL_LITERAL : ( 'true' | 'false' );
COLOR_LITERAL : ( '#' HEX_DIGIT HEX_DIGIT HEX_DIGIT HEX_DIGIT HEX_DIGIT HEX_DIGIT | '#' HEX_DIGIT HEX_DIGIT HEX_DIGIT HEX_DIGIT HEX_DIGIT HEX_DIGIT HEX_DIGIT HEX_DIGIT );
ID : ( ID_LETTER ) ( ( '.' )? ( ID_BODY '.' )* ID_BODY )? ;
ID_EX : ( ID_LETTER_EX ) ( ( '.' )? ( ID_BODY_EX '.' )* ID_BODY_EX )? ;
INDENT : '|INDENT|' ;
LINE_CONTINUATION : '|C|' ;
EMPTY_LINE_V1 : '|EMPTY_V1|' ;
EMPTY_LINE : '|EMPTY|' ;
WHITESPACE : [\r\n\t ] -> skip;
fragment ID_BODY : ( ID_LETTER | DIGIT )+ ;
fragment ID_BODY_EX : ( ID_LETTER_EX | DIGIT )+ ;
fragment ID_LETTER : ( 'a' .. 'z' | 'A' .. 'Z' | '_' ) ;
fragment ID_LETTER_EX : ( 'a' .. 'z' | 'A' .. 'Z' | '_' | '#' ) ;
fragment DIGIT : ( '0' .. '9' ) ;
fragment ESC : '\\' . ;
fragment DIGITS : ( '0' .. '9' )+ ;
fragment HEX_DIGIT : ( '0' .. '9' | 'a' .. 'f' | 'A' .. 'F' ) ;
fragment EXP : ( 'e' | 'E' ) ( '+' | '-' )? DIGITS ;
Tokens : ( COND | COND_ELSE | OR | AND | NOT | EQ | NEQ | GT | GE | LT | LE | PLUS | MINUS | MUL | DIV | MOD | COMMA | ARROW | LPAR | RPAR | LSQBR | RSQBR | DEFINE | IF_COND | IF_COND_ELSE | BEGIN | END | ASSIGN | FOR_STMT | FOR_STMT_TO | FOR_STMT_BY | BREAK | CONTINUE | LBEG | LEND | PLEND | INT_LITERAL | FLOAT_LITERAL | STR_LITERAL | BOOL_LITERAL | COLOR_LITERAL | ID | ID_EX | INDENT | LINE_CONTINUATION | EMPTY_LINE_V1 | EMPTY_LINE | WHITESPACE );

script : statement+;
block: BEGIN statement+ END;

statement :
    variableDeclaration
    | variableAssignment
    | functionDeclaration
    | functionCall
    | conditional
    | loop;

variableDeclaration: ID '=' variableValue;
variableAssignment: ID ':=' variableValue;
variableValue: expression | conditional | loop;

functionDeclaration: ID '(' functionParameters ')' '=>' functionBody;
functionParameters: (ID (',' ID)*)?;
functionBody: block | expression;

functionCall: ID '(' functionArguments ')';
functionArguments:
    (expression (',' expression)* (',' variableDeclaration)*)?
    | (variableDeclaration (',' variableDeclaration)*)?;

conditional: IF_COND expression block (IF_COND_ELSE conditional | IF_COND_ELSE block)?;

loop: FOR_STMT variableDeclaration FOR_STMT_TO expression (FOR_STMT_BY INT_LITERAL)? loopBody;
loopBody: BEGIN (statement | BREAK | CONTINUE)+ END;

expression
    : '-' expression #UnaryMinusExpression
    | 'not' expression #NotExpression
    | expression op=('*' | '/' | '%') expression #BinaryOperationExpression
    | expression op=('+' | '-') expression #BinaryOperationExpression
    | expression op=('>=' | '<=' | '>' | '<') expression #BinaryOperationExpression
    | expression op=('==' | '!=') expression #BinaryOperationExpression
    | expression op='and' expression #BinaryOperationExpression
    | expression op='or' expression #BinaryOperationExpression
    | expression '?' expression ':' expression #TernaryExpression
    | INT_LITERAL #IntExpression
    | FLOAT_LITERAL #FloatExpression
    | BOOL_LITERAL #BoolExpression
    | STR_LITERAL #StringExpression
    | COLOR_LITERAL #ColorExpression
    | functionCall #FunctionCallExpression
    | (seriesAccess | ID) #IdentifierExpression
    | '(' expression ')' #GroupExpression
    ;
    
seriesAccess: ID LSQBR expression RSQBR;

// TODO: Look at ANTLR grammars and make this one fine
