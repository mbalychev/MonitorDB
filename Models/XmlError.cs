namespace MonitorDB.Models
{
    /// <summary>
    /// описание ошибки
    /// </summary>
    public class XmlError
    {
        /// <summary>
        /// id файла
        /// </summary>
        /// <value></value>
        public long FileId { get; set; }
        /// <summary>
        /// код ошибки в БД
        /// </summary>
        /// <value></value>
        public long CodeError { get; set; }

        /// <summary>
        /// код сервиса 
        /// </summary>
        /// <value></value>
        public long Code { get; set; }

        /// <summary>
        /// описание ошибки
        /// </summary>
        /// <value></value>
        public string Error { get; set; } = string.Empty;

        /// <summary>
        /// описание сервиса
        /// </summary>
        /// <value></value>
        public string Application { get; set; } = string.Empty;

        /// <summary>
        /// дата создания в БД
        /// </summary>
        /// <value></value>
        public DateTime Date { get; set; }

        /// <summary>
        /// комментарий
        /// </summary>
        /// <value></value>
        public string Comment { get; set; }

    }
}