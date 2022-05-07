using System;
using System.Collections.Generic;

namespace AdvancedCalculator.Pesic
{
    /// <summary>
    /// Node implementation of an AST.
    /// </summary>
    class AbstractSyntaxnode
    {
        private Token token;
        private AbstractSyntaxnode left;
        private AbstractSyntaxnode right;

        public AbstractSyntaxnode(Token t)
        {
            this.token = t;
            this.left = null;
            this.right = null;
        }

        public AbstractSyntaxnode(Token t, AbstractSyntaxnode right)
        {
            this.token = t;
            this.right = right;
            this.left = null;
        }

        public AbstractSyntaxnode(Token t, AbstractSyntaxnode left, AbstractSyntaxnode right)
        {
            this.token = t;
            this.right = right;
            this.left = left;
        }

        public Token Token => token;

        public AbstractSyntaxnode Left => left;

        public AbstractSyntaxnode Right => right;

    }
}
