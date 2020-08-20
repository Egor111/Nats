namespace BasicFunctionality.Dto
{
    /// <summary>
    /// Dto пришедшего объекта в сообщении.
    /// </summary>
    public class NatsDto
    {
        /// <summary>
        /// Порядковый номер
        /// </summary>
        public int Numbet { get; set; }

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
