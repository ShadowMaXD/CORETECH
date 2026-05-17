namespace WIS.OemActivator.Common
{
    /// <summary>
    /// Класс для хранения конфигурации приложения
    /// </summary>
    public static class AppConfig
    {

        /// <summary>
        /// Строка соединения с БД
        /// </summary>
        public static string ConnectionString { get; set; } = null!;


        /// <summary>
        /// Разрешить вывод отладочных сообщений в результатах вывода API
        /// </summary>
        public static bool Debug_Messages { get; set; } = true;
    }
}
