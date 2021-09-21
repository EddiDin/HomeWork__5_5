using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork__5_5_1
{
    /// <summary>
    /// Пользовательское исключение для описания ошибок билдера работников.
    /// </summary>
    [Serializable]
    class MatrixException : Exception
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="message">Пользовательское сообщение об ошибке</param>
        public MatrixException(string message) : base(message) { }
    }
}
