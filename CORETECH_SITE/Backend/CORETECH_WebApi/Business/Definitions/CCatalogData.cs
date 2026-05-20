using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Business.Definitions
{
 
        /// <summary>
        /// Продукты каталога
        /// </summary>
        public class CCatalogData
        {

            /// <summary>
            /// Код
            /// </summary>
            public int ID { get; set; }


            /// <summary>
            /// Имя продукта
            /// </summary>
            public string Name { get; set; } = null!;


            /// <summary>
            /// IsHit
            /// </summary>
            public bool IsHit { get; set; }


            /// <summary>
            /// Картинка base64
            /// </summary>
            public string Image { get; set; } = null!;


            /// <summary>
            /// FPS На главной
            /// </summary>
            public string FpsNumber { get; set; } = null!;


            /// <summary>
            /// FPS прогресс
            /// </summary>
            public string FpsBarWidth { get; set; } = null!;


            /// <summary>
            /// FPS модальное окно
            /// </summary>
            public Dictionary<string, string>? FpsModal { get; set; }


            /// <summary>
            /// Процессор
            /// </summary>
            public string Cpu { get; set; } = null!;


            /// <summary>
            /// Графическая карта
            /// </summary>
            public string Gpu { get; set; } = null!;


            /// <summary>
            /// Оперативка
            /// </summary>
            public string Ram { get; set; } = null!;


            /// <summary>
            /// Статус
            /// </summary>
            public string StatusClass { get; set; } = null!;


            /// <summary>
            /// Текст статуса
            /// </summary>
            public string StatusText { get; set; } = null!;


            /// <summary>
            /// Стоимость
            /// </summary>
            public string Price { get; set; } = null!;


            /// <summary>
            /// FPS модальное окно
            /// </summary>
            public Dictionary<string, string>? SpecsModal { get; set; }


            /// <summary>
            /// Флаг удаленности
            /// </summary>
            public bool Flag_Del { get; set; }
        }
}
