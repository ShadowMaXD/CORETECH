using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Business
{
    /// <summary>
    /// Сборный класс для данных
    /// </summary>
    public class _BL_Context
    {

        /// <summary>
        /// Бронирование
        /// </summary>
        public CatalogDatas CatalogDatas { get; } = new();


        /// <summary>
        /// Получение пути к библиотеке
        /// </summary>
        public static string GetAssemblyPath
        {
            get
            {
                return $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            }
        }
    }
}
