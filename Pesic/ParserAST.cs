using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCalculator.Pesic
{
    /// <summary>
    /// The parser takes a List of Tokens in Reversed Polished Notation and parses it , to an Abstract Syntax Tree.
    /// </summary>
    class ParserAST
    {
        private Stack<AbstractSyntaxnode> stack;
        //private CCEngine engine;
        private bool isVariableAllowed = true;

        private AbstractSyntaxnode createNumberOrVariableNode(Token t)
        {
            return new AbstractSyntaxnode(t);
        }

        private AbstractSyntaxnode createUnaryOperatorOrFunctionNode(Token t, AbstractSyntaxnode left)
        {
            return new AbstractSyntaxnode(t, left);
        }

        private AbstractSyntaxnode createBinaryOperatorNode(Token t, AbstractSyntaxnode left, AbstractSyntaxnode right)
        {
            return new AbstractSyntaxnode(t, left, right);
        }

        private AbstractSyntaxnode parseBinaryOperator(Token token)
        {
            if (stack.Count < 2) 
            {
                throw new ArgumentException();
            }
            var right = stack.Pop();
            var left = stack.Pop();
            return createBinaryOperatorNode(token, left, right);
        }

        private AbstractSyntaxnode parseUnaryOperatorOrFunction(Token token)
        {
            if (stack.Count < 1) 
            {
                throw new ArgumentException();
            }
            var right = stack.Pop();
            return createUnaryOperatorOrFunctionNode(token, right);
        }

        public void setAreVariablesAllowed(bool cond)
        {
            this.isVariableAllowed = cond;
        }

        public AbstractSyntaxnode parseToAST(List<Token> expr) 
        {
            this.stack = new Stack<AbstractSyntaxnode>();
            expr.ForEach(token =>
            {
                if (token.getTypeToken().Equals(TokenType.NUMBER) || token.getTypeToken().Equals(TokenType.VARIABLE) || token.getTypeToken().Equals(TokenType.CONSTANT))
                {
                    stack.Push(createNumberOrVariableNode(token));
                }
                else if (token.getTypeToken().Equals(TokenType.OPERATOR))
                {
                    SpecialToken<Operator> opT = ((SpecialToken<Operator>)token);
                    if (((Operator)opT.getObjectToken()).NumOperands == 2)
                    {
                        var newToken = parseBinaryOperator(token);
                        stack.Push(newToken);
                    }
                    else if (((Operator)opT.getObjectToken()).NumOperands == 1)
                    {
                        var newToken = parseUnaryOperatorOrFunction(token);
                        stack.Push(newToken);
                    }
                }
                else if (token.getTypeToken() == TokenType.FUNCTION)
                {
                    var newToken = parseUnaryOperatorOrFunction(token);
                    stack.Push(newToken);
                }
            });
            if (stack.Count != 1)
            {
                throw new ArgumentException();
            }

            return stack.Pop();
        }
    }
}
