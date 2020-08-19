namespace BasicFunctionality.Dto
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Подкль полученных данных из базы.
    /// </summary>
    public class NatsModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Порядковый номер
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Хэш предыдущего состояни всей "базы".
        /// </summary>
        public int HashCode { get; set; }
    }
}