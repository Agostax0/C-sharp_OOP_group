using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCalculator.Pesic
{
    /// <summary>
    /// Evaluates an Abstract Syntax Tree.
    /// </summary>
    class EvaluatorAST
    {
        private Operation evaluateSubTree(AbstractSyntaxnode node)
        {
            Token t = node.Token;
            switch (t.getTypeToken())
            {
                case TokenType.NUMBER:
                    return OperationsFactory.constant(((SpecialToken<Double>)t).getObjectToken().ToString());
                case TokenType.CONSTANT:
                    return evaluateConstant(node);
                case TokenType.VARIABLE:
                    return OperationsFactory.simpleVar();
                case TokenType.FUNCTION:
                    return evaluateFunction(node);
                case TokenType.OPERATOR:
                    return evaluateOperator(node);
                default:
                    throw new ArgumentException("Invalid Token Expression");
            }
        }

        private Operation evaluateConstant(AbstractSyntaxnode node)
        {
            Token token = node.Token;
            switch (token.getSymbol())
            {
                case "pi":
                    return OperationsFactory.constant(Math.PI.ToString());
                case "e":
                    return OperationsFactory.constant(Math.E.ToString());
                default:
                    throw new ArgumentException("The constant doesn't exist");
            }
        }

        private Operation evaluateFunction(AbstractSyntaxnode node)
        {
            if (node.Right == null)
            {
                throw new ArgumentException("Function needs arguments");
            }
            Operation right = evaluateSubTree(node.Right);
            SpecialToken<Function> token = (SpecialToken<Function>)node.Token;

            switch (token.getSymbol())
            {
                case "acos":
                    return OperationsFactory.acos(right);
                case "asin":
                    return OperationsFactory.asin(right);
                case "atan":
                    return OperationsFactory.atan(right);
                case "log":
                    return OperationsFactory.log(right);
                case "cos":
                    return OperationsFactory.cos(right);
                case "sin":
                    return OperationsFactory.sin(right);
                case "√":
                case "sqrt":
                    return OperationsFactory.sqrt(right);
                case "tan":
                    return OperationsFactory.tan(right);
                case "exp":
                    return OperationsFactory.exp(right);
                case "abs":
                    return OperationsFactory.abs(right);
                case "csc":
                    return OperationsFactory.csc(right);
                case "cot":
                    return OperationsFactory.cot(right);
                case "sec":
                    return OperationsFactory.sec(right);
                default:
                    throw new ArgumentException("Function error");
            }
        }

        private Operation evaluateOperator(AbstractSyntaxnode node)
        {

            if (node.Left != null && node.Right != null)
            {
                return evaluateBinaryOperator(node);
            }
            else if (node.Right != null && node.Left == null)
            {
                return evaluateUnaryOperator(node);
            }

            throw new ArgumentException("Error with operator: " + node.Token.getSymbol() + " and node.left: "
                    + node.Left + " and node.right: " + node.Right);
        }

        private Operation evaluateUnaryOperator(AbstractSyntaxnode node)
        {
            Operation right = evaluateSubTree(node.Right);
            SpecialToken<Operator> token = (SpecialToken<Operator>)node.Token;

            if ("-".Equals(token.getSymbol()))
            {
                return OperationsFactory.negate(right);
            }

            throw new ArgumentException("Unary Operator doesn't work");
        }

        private Operation evaluateBinaryOperator(AbstractSyntaxnode node)
        {
            Operation right = evaluateSubTree(node.Right);
            Operation left = evaluateSubTree(node.Left);
            SpecialToken<Operator> token = (SpecialToken<Operator>)node.Token;
            switch (token.getSymbol())
            {
                case "+":
                    return OperationsFactory.addition(left, right);
                case "-":
                    return OperationsFactory.subtraction(left, right);
                case "\u00D7":
                case "*":
                    return OperationsFactory.product(left, right);
                case "÷":
                case "/":
                    return OperationsFactory.division(left, right);
                case "^":
                    return OperationsFactory.pow(left, right);
                default:
                    throw new ArgumentException("Unary Operator doesn't work");
            }
        }

        public Operation evaluate(AbstractSyntaxnode root)
        {
            if (root == null)
            {
                throw new ArgumentException();
            }
            return evaluateSubTree(root);
        }

    }
}
