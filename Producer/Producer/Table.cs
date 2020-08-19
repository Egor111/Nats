namespace Producer
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Table
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Время отправки.
        /// </summary>
        public DateTime SendTime { get; set; }

        /// <summary>
        /// Текст
        /// </summary>
        public string Text { get; set; }
    }
}
