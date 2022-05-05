using NUnit.Framework;
using System.Collections.Generic;

namespace AdvancedCalculator.Pesic.Test
{
    public class Tests
    {
        private List<Token> l;
        private ParserAST parser;
        private EvaluatorAST evaluator;
        [SetUp]
        public void Setup()
        {
            l = new List<Token>();
            parser = new ParserAST();
            evaluator = new EvaluatorAST();
        }

        [Test]
        public void TestDerivatives()
        {
            l.Add(TokensFactory.VarToken("x"));
            l.Add(TokensFactory.FuncToken(new Function("sin")));

            var root = parser.parseToAST(l);
            var op = evaluator.evaluate(root);
            Assert.AreEqual("(cos(x))×(1)", op.getDerivative().ToString());

            l.Clear();

            l.Add(TokensFactory.VarToken("x"));
            l.Add(TokensFactory.FuncToken(new Function("cos")));

            root = parser.parseToAST(l);
            op = evaluator.evaluate(root);
            Assert.AreEqual("(0.0)-((sin(x))×(1))", op.getDerivative().ToString());

            l.Clear();

            l.Add(TokensFactory.VarToken("x"));
            l.Add(TokensFactory.FuncToken(new Function("tan")));

            root = parser.parseToAST(l);
            op = evaluator.evaluate(root);

            Assert.AreEqual("(1)÷((cos(x))^(2))", op.getDerivative().ToString());
            System.Diagnostics.Debug.WriteLine(op.getDerivative().ToString());

            l.Clear();

            l.Add(TokensFactory.VarToken("x"));
            l.Add(TokensFactory.FuncToken(new Function("csc")));

            root = parser.parseToAST(l);
            op = evaluator.evaluate(root);

            Assert.AreEqual("(0)-(((cot(x))×(csc(x)))×(1))", op.getDerivative().ToString());
            System.Diagnostics.Debug.WriteLine(op.getDerivative().ToString());

            l.Clear();

            l.Add(TokensFactory.VarToken("x"));
            l.Add(TokensFactory.FuncToken(new Function("sec")));

            root = parser.parseToAST(l);
            op = evaluator.evaluate(root);

            Assert.AreEqual("((tan(x))×(sec(x)))×(1)", op.getDerivative().ToString());

            l.Clear();

            l.Add(TokensFactory.VarToken("x"));
            l.Add(TokensFactory.NumToken(2.0));
            l.Add(TokensFactory.OpToken(new Operator("^", 2, false)));

            root = parser.parseToAST(l);
            op = evaluator.evaluate(root);

            Assert.AreEqual("((x)^(2))×(((0.0)×(log(x)))+(((2)×(1))÷(x)))", op.getDerivative().ToString());

            l.Clear();

            l.Add(TokensFactory.VarToken("x"));
            l.Add(TokensFactory.FuncToken(new Function("log")));

            root = parser.parseToAST(l);
            op = evaluator.evaluate(root);

            Assert.AreEqual("(1)÷(x)", op.getDerivative().ToString());

            l.Clear();

            l.Add(TokensFactory.VarToken("x"));
            l.Add(TokensFactory.FuncToken(new Function("abs")));

            root = parser.parseToAST(l);
            op = evaluator.evaluate(root);

            Assert.AreEqual("((x)×(1))÷(abs(x))", op.getDerivative().ToString());

            l.Clear();

            l.Add(TokensFactory.VarToken("x"));
            l.Add(TokensFactory.FuncToken(new Function("acos")));

            root = parser.parseToAST(l);
            op = evaluator.evaluate(root);

            Assert.AreEqual("(0.0)-((1)÷(√((1)-((x)^(2)))))", op.getDerivative().ToString());

            l.Clear();

            l.Add(TokensFactory.VarToken("x"));
            l.Add(TokensFactory.FuncToken(new Function("asin")));

            root = parser.parseToAST(l);
            op = evaluator.evaluate(root);

            Assert.AreEqual("(1)÷(√((1)-((x)^(2))))", op.getDerivative().ToString());

            l.Clear();

            l.Add(TokensFactory.VarToken("x"));
            l.Add(TokensFactory.FuncToken(new Function("atan")));

            root = parser.parseToAST(l);
            op = evaluator.evaluate(root);

            Assert.AreEqual("(1)÷((1)+((x)^(2)))", op.getDerivative().ToString());

            l.Clear();

            l.Add(TokensFactory.VarToken("x"));
            l.Add(TokensFactory.FuncToken(new Function("exp")));

            root = parser.parseToAST(l);
            op = evaluator.evaluate(root);

            Assert.AreEqual("(e^(x))×(1)", op.getDerivative().ToString());

            l.Clear();

            l.Add(TokensFactory.VarToken("x"));

            root = parser.parseToAST(l);
            op = evaluator.evaluate(root);

            Assert.AreEqual("1", op.getDerivative().ToString());

            l.Clear();

            l.Add(TokensFactory.VarToken("x"));
            l.Add(TokensFactory.FuncToken(new Function("sqrt")));

            root = parser.parseToAST(l);
            op = evaluator.evaluate(root);

            Assert.AreEqual("(1)÷((2)×(√(x)))", op.getDerivative().ToString());

            l.Clear();

            l.Add(TokensFactory.VarToken("x"));
            l.Add(TokensFactory.NumToken(2));
            l.Add(TokensFactory.OpToken(new Operator("*", 2, true)));

            root = parser.parseToAST(l);
            op = evaluator.evaluate(root);

            Assert.AreEqual("((1)×(2))+((x)×(0.0))", op.getDerivative().ToString());

            l.Clear();

            l.Add(TokensFactory.VarToken("x"));
            l.Add(TokensFactory.NumToken(2));
            l.Add(TokensFactory.OpToken(new Operator("+", 2, true)));

            root = parser.parseToAST(l);
            op = evaluator.evaluate(root);

            Assert.AreEqual("(1)+(0.0)", op.getDerivative().ToString());

            l.Clear();

            l.Add(TokensFactory.VarToken("x"));
            l.Add(TokensFactory.NumToken(2));
            l.Add(TokensFactory.OpToken(new Operator("/", 2, true)));

            root = parser.parseToAST(l);
            op = evaluator.evaluate(root);

            Assert.AreEqual("(((1)×(2))-((x)×(0.0)))÷((2)^(2))", op.getDerivative().ToString());
        }
    }
}