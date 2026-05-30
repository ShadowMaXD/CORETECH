using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

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
        [JsonPropertyName("id")]
        public int ID { get; set; }


        /// <summary>
        /// Имя продукта
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;


        /// <summary>
        /// IsHit
        /// </summary>
        [JsonPropertyName("isHit")]
        public bool IsHit { get; set; }


        /// <summary>
        /// Картинка base64
        /// </summary>
        [JsonPropertyName("image")]
        public string Image { get; set; } = null!;


        /// <summary>
        /// FPS На главной
        /// </summary>
        [JsonPropertyName("fpsNumber")]
        public string FpsNumber { get; set; } = null!;


        /// <summary>
        /// FPS прогресс
        /// </summary>
        [JsonPropertyName("fpsBarWidth")]
        public string FpsBarWidth { get; set; } = null!;


        /// <summary>
        /// FPS модальное окно
        /// </summary>
        [JsonPropertyName("fpsModal")]
        public Dictionary<string, string>? FpsModal { get; set; }


        /// <summary>
        /// Процессор
        /// </summary>
        [JsonPropertyName("cpu")]
        public string Cpu { get; set; } = null!;


        /// <summary>
        /// Графическая карта
        /// </summary>
        [JsonPropertyName("gpu")]
        public string Gpu { get; set; } = null!;


        /// <summary>
        /// Оперативка
        /// </summary>
        [JsonPropertyName("ram")]
        public string Ram { get; set; } = null!;


        /// <summary>
        /// Статус
        /// </summary>
        [JsonPropertyName("statusClass")]
        public string StatusClass { get; set; } = null!;


        /// <summary>
        /// Текст статуса
        /// </summary>
        [JsonPropertyName("statusText")]
        public string StatusText { get; set; } = null!;


        /// <summary>
        /// Стоимость
        /// </summary>
        [JsonPropertyName("price")]
        public string Price { get; set; } = null!;


        /// <summary>
        /// FPS модальное окно
        /// </summary>
        [JsonPropertyName("specsModal")]
        public Dictionary<string, string>? SpecsModal { get; set; }


        /// <summary>
        /// Флаг удаленности
        /// </summary>
        [JsonPropertyName("flag_Del")]
        public bool Flag_Del { get; set; }
    }

}
