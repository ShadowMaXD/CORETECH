using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Definitions
{
    /// <summary>
	/// Права на использование продуктов, которые выдаются ключам приложения
	/// </summary>
    [Table("Catalog")]
    [Comment("Права на использование продуктов, которые выдаются ключам приложения")]
    public class CatalogData
    {
    }
}
