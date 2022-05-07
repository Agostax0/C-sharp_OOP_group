using NUnit.Framework;
using System;
using System.Collections.Generic;
namespace AdvancedCalculator.Pesic.Test
{
    public class Tests2
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
        public void testNumericResult()
        {
            l.Add(TokensFactory.VarToken("x"));
            l.Add(TokensFactory.FuncToken(new Function("sin")));

            var root = parser.parseToAST(l);
            var op = evaluator.evaluate(root);
            Assert.AreEqual(0.0, op.getNumericResult(0));

            l.Clear();

            l.Add(TokensFactory.VarToken("x"));
            l.Add(TokensFactory.FuncToken(new Function("cos")));

            root = parser.parseToAST(l);
            op = evaluator.evaluate(root);
            Assert.AreEqual(1.0, op.getNumericResult(0));

            l.Clear();

            l.Add(TokensFactory.VarToken("x"));
            l.Add(TokensFactory.FuncToken(new Function("tan")));

            root = parser.parseToAST(l);
            op = evaluator.evaluate(root);

            Assert.AreEqual(0, op.getNumericResult(0.0));

            l.Clear();

            l.Add(TokensFactory.VarToken("x"));
            l.Add(TokensFactory.FuncToken(new Function("csc")));

            root = parser.parseToAST(l);
            op = evaluator.evaluate(root);

            Assert.AreEqual(1.0, op.getNumericResult(Math.PI/2.0));

            l.Clear();

            l.Add(TokensFactory.VarToken("x"));
            l.Add(TokensFactory.FuncToken(new Function("sec")));

            root = parser.parseToAST(l);
            op = evaluator.evaluate(root);

            Assert.AreEqual(1.0, op.getNumericResult(0.0));

            l.Clear();

            l.Add(TokensFactory.VarToken("x"));
            l.Add(TokensFactory.NumToken(2.0));
            l.Add(TokensFactory.OpToken(new Operator("^", 2, false)));

            root = parser.parseToAST(l);
            op = evaluator.evaluate(root);

            Assert.AreEqual(4.0, op.getNumericResult(2));

            l.Clear();

            l.Add(TokensFactory.VarToken("x"));
            l.Add(TokensFactory.FuncToken(new Function("log")));

            root = parser.parseToAST(l);
            op = evaluator.evaluate(root);

            Assert.AreEqual(1, op.getNumericResult(Math.E));

            l.Clear();

            l.Add(TokensFactory.VarToken("x"));
            l.Add(TokensFactory.FuncToken(new Function("abs")));

            root = parser.parseToAST(l);
            op = evaluator.evaluate(root);

            Assert.AreEqual(2.0, op.getNumericResult(-2.0));

            l.Clear();

            l.Add(TokensFactory.VarToken("x"));
            l.Add(TokensFactory.FuncToken(new Function("acos")));

            root = parser.parseToAST(l);
            op = evaluator.evaluate(root);

            Assert.AreEqual(Math.PI/2, op.getNumericResult(0.0));

            l.Clear();

            l.Add(TokensFactory.VarToken("x"));
            l.Add(TokensFactory.FuncToken(new Function("asin")));

            root = parser.parseToAST(l);
            op = evaluator.evaluate(root);

            Assert.AreEqual(0.0, op.getNumericResult(0.0));

            l.Clear();

            l.Add(TokensFactory.VarToken("x"));
            l.Add(TokensFactory.FuncToken(new Function("atan")));

            root = parser.parseToAST(l);
            op = evaluator.evaluate(root);

            Assert.AreEqual(0.0, op.getNumericResult(0.0));

            l.Clear();

            l.Add(TokensFactory.VarToken("x"));
            l.Add(TokensFactory.FuncToken(new Function("exp")));

            root = parser.parseToAST(l);
            op = evaluator.evaluate(root);

            Assert.AreEqual(Math.E, op.getNumericResult(1));

            l.Clear();

            l.Add(TokensFactory.VarToken("x"));

            root = parser.parseToAST(l);
            op = evaluator.evaluate(root);

            Assert.AreEqual(1.0, op.getNumericResult(1.0));

            l.Clear();

            l.Add(TokensFactory.VarToken("x"));
            l.Add(TokensFactory.FuncToken(new Function("sqrt")));

            root = parser.parseToAST(l);
            op = evaluator.evaluate(root);

            Assert.AreEqual(2.0, op.getNumericResult(4.0));

            l.Clear();

            l.Add(TokensFactory.VarToken("x"));
            l.Add(TokensFactory.NumToken(2));
            l.Add(TokensFactory.OpToken(new Operator("*", 2, true)));

            root = parser.parseToAST(l);
            op = evaluator.evaluate(root);

            Assert.AreEqual(4.0, op.getNumericResult(2.0));

            l.Clear();

            l.Add(TokensFactory.VarToken("x"));
            l.Add(TokensFactory.NumToken(2));
            l.Add(TokensFactory.OpToken(new Operator("+", 2, true)));

            root = parser.parseToAST(l);
            op = evaluator.evaluate(root);

            Assert.AreEqual(4.0, op.getNumericResult(2.0));

            l.Clear();

            l.Add(TokensFactory.VarToken("x"));
            l.Add(TokensFactory.NumToken(2));
            l.Add(TokensFactory.OpToken(new Operator("/", 2, true)));

            root = parser.parseToAST(l);
            op = evaluator.evaluate(root);

            Assert.AreEqual(1.0, op.getNumericResult(2));
        }
    }
}
