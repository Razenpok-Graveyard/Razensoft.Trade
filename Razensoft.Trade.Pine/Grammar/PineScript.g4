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

variableDeclaration: ID DEFINE ( expression | conditional | ternary | loop );
variableAssignment: ID ASSIGN ( expression | conditional | ternary | loop);

functionDeclaration: ID LPAR functionParameters RPAR ARROW (block | expression | ternary);
functionParameters: ( ID (COMMA ID)* )?;

functionCall: ID LPAR functionArguments RPAR;
functionArguments:
    ((expression | ternary) (COMMA (expression | ternary))* (COMMA variableDeclaration)*)?
    | (variableDeclaration (COMMA variableDeclaration)*)?;

conditional: IF_COND expression block (IF_COND_ELSE conditional | IF_COND_ELSE block)?;

loop: FOR_STMT variableDeclaration FOR_STMT_TO expression ( FOR_STMT_BY INT_LITERAL )? loopBody;
loopBody: BEGIN (statement | BREAK | CONTINUE)+ END;

ternary: expression COND expression COND_ELSE ( LPAR ternary RPAR | ternary | expression );

expression: ( MINUS? ( INT_LITERAL | FLOAT_LITERAL ) | BOOL_LITERAL | STR_LITERAL | COLOR_LITERAL ) #LiteralExpression
    | (NOT|MINUS)? functionCall #CallExpression
    | (NOT|MINUS)? ( seriesAccess | ID ) #IdentifierExpression
    | LPAR ( ternary | expression ) RPAR #GroupExpression
    | expression (OR | AND | EQ | NEQ | GT | GE | LT | LE | PLUS | MINUS | MUL | DIV | MOD) expression #BinaryOperationExpression
    ;

