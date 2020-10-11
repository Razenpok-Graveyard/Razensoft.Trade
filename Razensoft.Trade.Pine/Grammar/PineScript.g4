grammar PineScript;

/// Parser

script
    : statementList
    ;

block
    : Begin statementList End
    ;

statementList
    : statement+
    ;

statement
    : block
    | variableDeclarationStatement
    | variableAssignmentStatement
    | functionDeclarationStatement
    | functionCallStatement
    | ifStatement
    | forStatement
//  | returnExpression
//  | breakExpression
    ;

variableDeclarationStatement
    : Identifier '=' variableValue
    ;

variableAssignmentStatement
    : Identifier ':=' variableValue
    ;

variableValue
    : expression
    | ifStatement
    | forStatement
    ;

functionDeclarationStatement
    : Identifier '(' functionParameters? ')' '=>' functionBody
    ;

functionParameters
    : Identifier (',' Identifier)*
    ;

functionBody
    : block
    | expression
    ;

functionCallStatement
    : Identifier '(' functionArguments? ')'
    ;

functionArguments
    : positional+=expression (',' positional+=expression)* (',' named+=namedFunctionArgument)*
    | named+=namedFunctionArgument (',' named+=namedFunctionArgument)*
    ;

namedFunctionArgument
    : Identifier '=' expression
    ;

ifStatement
    : If expression block (Else ifStatementElseBody)?
    ;

ifStatementElseBody
    : ifStatement
    | block
    ;

forStatement
    : 'for' forStatementCounter 'to' end=expression ('by' step=expression)? Begin forStatementBody End
    ;

forStatementCounter
    : Identifier '=' expression
    ;

forStatementBody
    : (statement | 'break' | 'continue')+
    ;

expression
    : '-' expression                                        # UnaryMinusExpression
    | 'not' expression                                      # NotExpression
    | expression op=('*' | '/' | '%') expression            # BinaryOperationExpression
    | expression op=('+' | '-') expression                  # BinaryOperationExpression
    | expression op=('>=' | '<=' | '>' | '<') expression    # BinaryOperationExpression
    | expression op=('==' | '!=') expression                # BinaryOperationExpression
    | expression op='and' expression                        # BinaryOperationExpression
    | expression op='or' expression                         # BinaryOperationExpression
    | expression '?' expression ':' expression              # TernaryExpression
    | literal                                               # LiteralExpression
    | functionCallStatement                                 # FunctionCallExpression
    | (seriesAccess | Identifier)                           # IdentifierExpression
    | '(' expression ')'                                    # ParenthesizedExpression
    ;

literal
    : IntLiteral       # IntLiteral
    | FloatLiteral     # FloatLiteral
    | BoolLiteral      # BoolLiteral
    | StringLiteral    # StringLiteral
    | ColorLiteral     # ColorLiteral
    | NALiteral        # NALiteral;
    
seriesAccess
    : Identifier OpenBracket expression CloseBracket
    ;


/// Parser

QuestionMark:                   '?';
Colon:                          ':';
Equals:                         '==';
NotEquals:                      '!=';
GreaterThan:                    '>';
LessThan:                       '<';
GreaterThanOrEquals:            '>=';
LessThanOrEquals:               '<=';
Plus:                           '+';
Minus:                          '-';
Multiply:                       '*';
Divide:                         '/';
Modulo:                         '%';
Comma:                          ',';
Arrow:                          '=>';
OpenParen:                      '(';
CloseParen:                     ')';
OpenBracket:                    '[';
CloseBracket:                   ']';
Define:                         '=';
Assign:                         ':=';

/// Logical operators

Or:                             'or';
And:                            'and';
Not:                            'not';

/// Keywords

If:                             'if';
Else:                           'else';
For:                            'for';
To:                             'to';
By:                             'by';
Break:                          'break';
Continue:                       'continue';

/// Literals

NALiteral:                      'na';

IntLiteral:                     IntegerPart;

FloatLiteral:                   IntegerPart '.' FractionPart ExponentPart?
            |                   '.' FractionPart ExponentPart?
            |                   IntegerPart ExponentPart;

BoolLiteral:                    'true'
              |                 'false';

StringLiteral:                  '"' (~["\\\n] | EscapeCharacter)* '"'
             |                  '\'' (~['\\\n] | EscapeCharacter)* '\''
             ;

ColorLiteral:                   '#' HexDigit HexDigit HexDigit HexDigit HexDigit HexDigit (HexDigit HexDigit)?;

/// Identifier

Identifier:                     IdentifierStart IdentifierPart*;

/// Block bounds

Begin:                          '|BEGIN|';
End:                            '|END|';

Whitespace:                     [\r\n\t ] -> skip;


fragment IntegerPart
    : '0'
    | [1-9] [0-9]*
    ;

fragment FractionPart
    : [0-9]+
    ;

fragment ExponentPart
    : [eE] [+-]? [0-9]+
    ;

fragment EscapeCharacter
    : '\\' .
    ;

fragment HexDigit
    : [0-9a-fA-F]
    ;

fragment IdentifierStart
    : IdentifierLetter
    ;

fragment IdentifierPart
    : IdentifierLetter
    | [0-9.]
    ;

fragment IdentifierLetter
    : [a-zA-Z_]
    ;
