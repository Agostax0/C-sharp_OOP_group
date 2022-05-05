using System;

namespace AdvancedCalculator.Pesic
{
	/// <summary>
	/// Type of tokens available.
	/// </summary>
    enum TokenType
    {
		NUMBER,
		OPENPAR,
		CLOSEPAR,
		ERROR,
		FUNCTION,
		OPERATOR,
        VARIABLE,
		CONSTANT
	}
}
