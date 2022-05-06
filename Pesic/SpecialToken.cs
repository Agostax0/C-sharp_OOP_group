using System;

namespace AdvancedCalculator.Pesic
{
    /// <summary>
    /// Some tokens needs to return some specific argument e.g.(number tokens needs to return their value).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface SpecialToken<T> : Token
    {
        T getObjectToken();
    }
}
