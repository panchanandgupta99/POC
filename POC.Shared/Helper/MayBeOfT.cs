using System;
using System.Collections;
using System.Collections.Generic;

namespace POC.Shared
{
    public sealed class MayBe<T> : IEnumerable<T>
    {
        #region Readonly variables

        private readonly IEnumerable<T> values;

        #endregion

        #region Constructor
        public MayBe()
        {
            values = new T[0];
        }

        public MayBe(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value), "Parameter should not be null.");

            values = new T[] { value };
        }

        #endregion

        #region Public Method

        public IEnumerator<T> GetEnumerator()
        {
            return values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
