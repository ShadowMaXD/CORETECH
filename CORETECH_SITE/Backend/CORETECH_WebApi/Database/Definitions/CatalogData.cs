using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Definitions
{
    /// <summary>
	/// Продукты каталога
	/// </summary>
    [Table("CatalogDatas")]
    [Comment("Продукты каталога")]
    public class CatalogData
    {

        /// <summary>
        /// Код
        /// </summary>
        [Key]
        [Comment("Код")]
        public int ID { get; set; }


        /// <summary>
        /// Имя продукта
        /// </summary>
        [Comment("Имя продукта")]
        public string Name { get; set; } = null!;


        /// <summary>
        /// IsHit
        /// </summary>
        [Comment("IsHit")]
        public bool IsHit { get; set; }


        /// <summary>
        /// Картинка base64
        /// </summary>
        [Comment("Имя продукта")]
        public string Image { get; set; } = null!;


        /// <summary>
        /// FPS На главной
        /// </summary>
        [Comment("FPS На главной")]
        public string FpsNumber { get; set; } = null!;


        /// <summary>
        /// FPS прогресс
        /// </summary>
        [Comment("FPS прогресс")]
        public string FpsBarWidth { get; set; } = null!;


        /// <summary>
        /// FPS модальное окно
        /// </summary>
        [NotMapped]
        [Comment("FPS модальное окно")]
        public Dictionary<string, string>? FpsModal { get; set; }

        /// <summary>
        /// Поле для хранения сериализованных данных FPS модальное окно
        /// </summary>
        [Comment("Сериализованное FPS модальное окно")]
        public string? FpsModalSerialized { get; set; }

        /// <summary>
        /// Процессор
        /// </summary>
        [Comment("Процессор")]
        public string Cpu { get; set; } = null!;


        /// <summary>
        /// Графическая карта
        /// </summary>
        [Comment("Графическая карта")]
        public string Gpu { get; set; } = null!;


        /// <summary>
        /// Оперативка
        /// </summary>
        [Comment("Оперативка")]
        public string Ram { get; set; } = null!;


        /// <summary>
        /// Статус
        /// </summary>
        [Comment("Статус")]
        public string StatusClass { get; set; } = null!;


        /// <summary>
        /// Текст статуса
        /// </summary>
        [Comment("Текст статуса")]
        public string StatusText { get; set; } = null!;


        /// <summary>
        /// Стоимость
        /// </summary>
        [Comment("Стоимость")]
        public string Price { get; set; } = null!;


        /// <summary>
        /// FPS модальное окно
        /// </summary>
        [NotMapped]
        [Comment("модальное окно")]
        public Dictionary<string, string>? SpecsModal { get; set; }


        /// <summary>
        /// Поле для хранения сериализованных данных FPS модальное окно
        /// </summary>
        [Comment("Сериализованное модальное окно")]
        public string? SpecsModalSerialized { get; set; }


        /// <summary>
        /// Флаг удаленности
        /// </summary>
        [Comment("Флаг удалено")]
        public bool Flag_Del { get; set; }
    }
}
