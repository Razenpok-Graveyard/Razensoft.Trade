grammar PineScript;

/// Parser

script
    : statementList
    ;

block
    : Begin statementList End
    ;

statement
    : block
    | variableDeclarationStatement
    | variableAssignmentStatement
    | functionDeclarationStatement
    | functionCallStatement
    | conditional
    | loop
    | return
    | break
    ;

statementList
    : statement+
    ;

variableDeclarationStatement
    : Identifier '=' variableValue
    ;

variableAssignmentStatement
    : Identifier ':=' variableValue
    ;

variableValue
    : expression
    | conditional
    | loop
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
    : positionalFunctionArgument (',' positionalFunctionArgument)* (',' namedFunctionArgument)*
    | namedFunctionArgument (',' namedFunctionArgument)*
    ;

positionalFunctionArgument
    : expression
    ;

namedFunctionArgument
    : Identifier '=' expression
    ;

conditional
    : If condition=expression then=block (Else else=conditionalElseBody)?
    ;

conditionalElseBody
    : conditional
    | block
    ;

loop
    : 'for' loopCounter 'to' end=expression ('by' step=expression)? BEGIN loopBody END
    ;

loopCounter
    : Identifier '=' expression
    ;

loopBody
    : (statement | BREAK | CONTINUE)+
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
    : INT_LITERAL       # IntLiteral
    | FLOAT_LITERAL     # FloatLiteral
    | BOOL_LITERAL      # BoolLiteral
    | STR_LITERAL       # StringLiteral
    | COLOR_LITERAL     # ColorLiteral
    | 'na'              # NALiteral;
    
seriesAccess
    : Identifier LSQBR expression RSQBR
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

IntegerLiteral:                 IntegerPart;

FloatLiteral:                   IntegerPart '.' FractionPart ExponentPart?
            |                   '.' FractionPart ExponentPart?
            |                   IntegerPart ExponentPart;

BooleanLiteral:                 'true'
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
    | [0-9]
    ;

fragment IdentifierLetter
    : [a-zA-Z_]
    ;
