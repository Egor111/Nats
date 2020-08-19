namespace BasicFunctionality.DataBase
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SendNats")]
    public class SendNats : BaseEntity
    {
        /// <summary>
        /// Порядковый номер
        /// </summary>
        [Display(Name = "Порядковый номер")]
        public virtual int Number { get; set; }

        // <summary>
        /// Время отправки.
        /// </summary>
        [Display(Name = "Время отправки")]
        public virtual DateTime SendTime { get; set; }

        /// <summary>
        /// Текст
        /// </summary>
        [Display(Name = "Текст")]
        public virtual string Text { get; set; }

        /// <summary>
        /// Хэш предыдущего состояни всей "базы".
        /// </summary>
        [Display(Name = "Хэш предыдущего состояни всей базы.")]
        public virtual int HashCode { get; set; }
    }
}
