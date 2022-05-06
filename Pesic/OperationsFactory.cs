
using System;

namespace AdvancedCalculator.Pesic
{
    /// <summary>
    /// All the implemented Operations for getting their derivative or numerical result
    /// </summary>
    public class OperationsFactory
    {
        private OperationsFactory() { }

        public static Operation sin(Operation op) => new Sin(op);
        public static Operation cos(Operation op) => new Cos(op);
        public static Operation tan(Operation op) => new Tan(op);
        public static Operation cot(Operation op) => new Cot(op);
        public static Operation csc(Operation op) => new Csc(op);
        public static Operation sec(Operation op) => new Sec(op);
        public static Operation negate(Operation op) => new Negate(op);
        public static Operation addition(Operation left, Operation right) => new Addition(left, right);
        public static Operation subtraction(Operation left, Operation right) => new Subtraction(left, right);
        public static Operation product(Operation left, Operation right) => new Product(left, right);
        public static Operation division(Operation left, Operation right) => new Division(left, right);
        public static Operation pow(Operation left, Operation right) => new Pow(left, right);
        public static Operation constant(string c) => new Constant(c);
        public static Operation log(Operation op) => new Log(op);
        public static Operation abs(Operation op) => new Abs(op);
        public static Operation acos(Operation op) => new Acos(op);
        public static Operation asin(Operation op) => new Asin(op);
        public static Operation atan(Operation op) => new Atan(op);
        public static Operation exp(Operation op) => new Exp(op);
        public static Operation simpleVar() => new SimpleVar();
        public static Operation sqrt(Operation op) => new Sqrt(op);
        private class Sin : Operation {
            private Operation op;
            public Sin(Operation op) {
                this.op = op;            
            }
            public double getNumericResult(double val)
            {
                return Math.Sin(op.getNumericResult(val));            
            }

            public Operation getDerivative()
            { 
                return OperationsFactory.product(OperationsFactory.cos(op), op.getDerivative());
            }

            public override string ToString()
            {
                return "sin(" + op.ToString() + ")";
            }
        }


        private class Cos : Operation
        {
            private Operation op;
            public Cos(Operation op)
            {
                this.op = op;
            }
            public double getNumericResult(double val)
            {
                return Math.Cos(op.getNumericResult(val));
            }

            public Operation getDerivative()
            {
                return subtraction(constant("0.0"), product(sin(op), op.getDerivative()));
            }

            public override string ToString()
            {
                return "cos(" + op.ToString() + ")";
            }
        }

        private class Cot : Operation
        {
            private Operation op;
            public Cot(Operation op)
            {
                this.op = op;
            }
            public double getNumericResult(double val)
            {
                return Math.Cos(op.getNumericResult(val)) / Math.Sin(op.getNumericResult(val));
            }

            public Operation getDerivative()
            {
                return product(subtraction(constant("0"), division(constant("1"), pow(sin(op), constant("2")))),
                        op.getDerivative());
            }

            public override string ToString()
            {
                return "cot(" + op.ToString() + ")";
            }
        }

        private class Csc : Operation
        {
            private Operation op;
            public Csc(Operation op)
            {
                this.op = op;
            }
            public double getNumericResult(double val)
            {
                return 1.0 / Math.Sin(op.getNumericResult(val));
            }

            public Operation getDerivative()
            {
                return subtraction(constant("0"), product(product(cot(op), csc(op)), op.getDerivative()));
            }

            public override string ToString()
            {
                return "csc(" + op.ToString() + ")";
            }
        }

        private class Sec : Operation
        {
            private Operation op;
            public Sec(Operation op)
            {
                this.op = op;
            }
            public double getNumericResult(double val)
            {
                return 1.0 / Math.Cos(op.getNumericResult(val));
            }


            public Operation getDerivative()
            {
                return product(product(tan(op), sec(op)), op.getDerivative());
            }

            public override String ToString()
            {
                return "sec(" + op.ToString() + ")";
            }
        }

        private class Negate : Operation
        {
            private Operation op;
            public Negate(Operation op)
            {
                this.op = op;
            }
            public Double getNumericResult(Double val)
            {
                return -op.getNumericResult(val);
            }

            public Operation getDerivative()
            {
                return subtraction(constant("0.0"), op.getDerivative());
            }

            public override String ToString()
            {
                return "-" + op.ToString();
            }
        }

        private class Addition : Operation
        {
            private Operation left;
            private Operation right;
            public Addition(Operation left, Operation right)
            {
                this.left = left;
                this.right = right;
            }
            public Double getNumericResult(Double val)
            {
                return left.getNumericResult(val) + right.getNumericResult(val);
            }

            public Operation getDerivative()
            {
                return OperationsFactory.addition(left.getDerivative(), right.getDerivative());
            }

            public override String ToString()
            {
                return "(" + left.ToString() + ")+(" + right.ToString() + ")";
            }
        }

        private class Subtraction : Operation
        {
            private Operation left;
            private Operation right;
            public Subtraction(Operation left, Operation right)
            {
                this.left = left;
                this.right = right;
            }
            public Double getNumericResult(Double val)
            {
                return left.getNumericResult(val) - right.getNumericResult(val);
            }


            public Operation getDerivative()
            {
                return OperationsFactory.subtraction(left.getDerivative(), right.getDerivative());
            }

            public override String ToString()
            {
                return "(" + left.ToString() + ")-(" + right.ToString() + ")";
            }
        }

        private class Product : Operation
        {
            private Operation left;
            private Operation right;
            public Product(Operation left, Operation right)
            {
                this.left = left;
                this.right = right;
            }
            public Double getNumericResult(Double val)
            {
                return left.getNumericResult(val) * right.getNumericResult(val);
            }

            public Operation getDerivative()
            {
                return addition(product(left.getDerivative(), right), product(left, right.getDerivative()));
            }

            public override String ToString()
            {
                return "(" + left.ToString() + ")×(" + right.ToString() + ")";
            }
        }

        private class Division : Operation
        {
            private Operation left;
            private Operation right;
            public Division(Operation left, Operation right)
            {
                this.left = left;
                this.right = right;
            }
            public Double getNumericResult(Double val)
            {
                return left.getNumericResult(val) / right.getNumericResult(val);
            }

            public Operation getDerivative()
            {
                return division(subtraction(product(left.getDerivative(), right), product(left, right.getDerivative())),
                        pow(right, constant("2")));
            }

            public override String ToString()
            {
                return "(" + left.ToString() + ")÷(" + right.ToString() + ")";
            }
        }

        private class Pow : Operation
        {
            private Operation left;
            private Operation right;
            public Pow(Operation left, Operation right)
            {
                this.left = left;
                this.right = right;
            }
            public Double getNumericResult(Double val)
            {
                return Math.Pow(left.getNumericResult(val), right.getNumericResult(val));
            }

            public Operation getDerivative()
            {
                var firstTerm = pow(left, right);
                var secondTerm = product(right.getDerivative(), log(left));
                var thirdTerm = division(product(right, left.getDerivative()), left);
                return product(firstTerm, addition(secondTerm, thirdTerm));
            }

            public override String ToString()
            {
                return "(" + left.ToString() + ")^(" + right.ToString() + ")";
            }
        }

        private class Constant : Operation
        {
            private string c;
            public Constant(string c)
            {
                this.c = c;
            }
            public Double getNumericResult(Double val)
            {
                return Double.Parse(c);
            }


            public Operation getDerivative()
            {
                return constant("0.0");
            }

            public override String ToString()
            {
                return c;
            }
        }

        private class Log : Operation
        {
            private Operation op;
            public Log(Operation op)
            {
                this.op = op;
            }
            public Double getNumericResult(Double val)
            {
                return Math.Log(op.getNumericResult(val));
            }

            public Operation getDerivative()
            {
                return division(op.getDerivative(), op);
            }

            public override String ToString()
            {
                return "log(" + op.ToString() + ")";
            }
        }

        private class Abs : Operation
        {
            private Operation op;
            public Abs(Operation op)
            {
                this.op = op;
            }
            public Double getNumericResult(Double val)
            {
                return Math.Abs(op.getNumericResult(val));
            }

            public Operation getDerivative()
            {
                return division(product(op, op.getDerivative()), abs(op));
            }

            public override String ToString()
            {
                return "abs(" + op.ToString() + ")";
            }
        }

        private class Acos : Operation
        {
            private Operation op;
            public Acos(Operation op)
            {
                this.op = op;
            }
            public Double getNumericResult(Double val)
            {
                return Math.Acos(op.getNumericResult(val));
            }

            public Operation getDerivative()
            {
                return subtraction(constant("0.0"),
                        division(op.getDerivative(), sqrt(subtraction(constant("1"), pow(op, constant("2"))))));
            }

            public override String ToString()
            {
                return "acos(" + op.ToString() + ")";
            }
        }

        private class Asin : Operation
        {
            private Operation op;
            public Asin(Operation op)
            {
                this.op = op;
            }
            public Double getNumericResult(Double val)
            {
                return Math.Asin(op.getNumericResult(val));
            }

            public Operation getDerivative()
            {
                return division(op.getDerivative(), sqrt(subtraction(constant("1"), pow(op, constant("2")))));
            }

            public override String ToString()
            {
                return "asin(" + op.ToString() + ")";
            }
        }

        private class Atan : Operation
        {
            private Operation op;
            public Atan(Operation op)
            {
                this.op = op;
            }
            public Double getNumericResult(Double val)
            {
                return Math.Atan(op.getNumericResult(val));
            }

            public Operation getDerivative()
            {
                return division(op.getDerivative(), addition(constant("1"), pow(op, constant("2"))));
            }

            public override String ToString()
            {
                return "atan(" + op.ToString() + ")";
            }
        }

        private class Exp : Operation
        {
            private Operation op;
            public Exp(Operation op)
            {
                this.op = op;
            }
            public Double getNumericResult(Double val)
            {
                return Math.Exp(op.getNumericResult(val));
            }

            public Operation getDerivative()
            {
                return product(exp(op), op.getDerivative());
            }

            public override String ToString()
            {
                return "e^(" + op.ToString() + ")";
            }
        }

        private class SimpleVar : Operation
        {
            
            public Double getNumericResult(Double val)
            {
                return val;
            }

            public Operation getDerivative()
            {
                return constant("1");
            }

            public override String ToString()
            {
                return "x";
            }
        }

        private class Sqrt : Operation
        {
            private Operation op;
            public Sqrt(Operation op)
            {
                this.op = op;
            }
            public Double getNumericResult(Double val)
            {
                return Math.Sqrt(op.getNumericResult(val));
            }

            public Operation getDerivative()
            {
                return division(op.getDerivative(), product(constant("2"), sqrt(op)));
            }

            public override String ToString()
            {
                return "√(" + op.ToString() + ")";
            }
        }

        private class Tan : Operation
        {
            private Operation op;
            public Tan(Operation op)
            {
                this.op = op;
            }
            public Double getNumericResult(Double val)
            {
                return Math.Tan(op.getNumericResult(val));
            }

            public Operation getDerivative()
            {
                return division(op.getDerivative(), pow(cos(op), constant("2")));
            }

            public override String ToString()
            {
                return "tan(" + op.ToString() + ")";
            }
        }
    }
}
