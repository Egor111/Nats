namespace BasicFunctionality.DataBase
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("RecipientNats")]
    public class RecipientNats : BaseEntity
    {
        /// <summary>
        /// Порядковый номер
        /// </summary>
        [Display(Name = "Порядковый номер")]
        public virtual int Numbet { get; set; }

        // <summary>
        /// Время получения.
        /// </summary>
        [Display(Name = "Время получения")]
        public virtual DateTime RecipientTime { get; set; }

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
