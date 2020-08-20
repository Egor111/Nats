namespace BasicFunctionality.Model
{
    using System;

    /// <summary>
    /// Модель полученного сообщения.
    /// </summary>
    public class SendModel
    {
        /// <summary>
        /// Порядковый номер
        /// </summary>
        public int Number { get; set; }

        // <summary>
        /// Время отправки.
        /// </summary>
        public DateTime SendTime { get; set; }

        /// <summary>
        /// Текст
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Хэш предыдущего состояни всей "базы".
        /// </summary>
        public int HashCode { get; set; }
    }
}
