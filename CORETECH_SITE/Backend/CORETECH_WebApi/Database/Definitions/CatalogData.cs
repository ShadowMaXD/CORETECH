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
        [Key]
        [Comment("Имя продукта")]
        public string Name { get; set; } = null!;


        /// <summary>
        /// IsHit
        /// </summary>
        [Key]
        [Comment("IsHit")]
        public bool IsHit { get; set; }


        /// <summary>
        /// Картинка base64
        /// </summary>
        [Key]
        [Comment("Имя продукта")]
        public string Image { get; set; } = null!;


        /// <summary>
        /// FPS На главной
        /// </summary>
        [Key]
        [Comment("FPS На главной")]
        public string FpsNumber { get; set; } = null!;


        /// <summary>
        /// FPS прогресс
        /// </summary>
        [Key]
        [Comment("FPS прогресс")]
        public string FpsBarWidth { get; set; } = null!;



    }
}
