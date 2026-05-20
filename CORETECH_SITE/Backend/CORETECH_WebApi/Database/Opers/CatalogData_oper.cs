using Database.Definitions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Database.Opers
{
    /// <summary>
    /// Класс работы с базой данных каталога товаров
    /// </summary>
    public class CatalogData_oper
    {

        /// <summary>
        /// Контекст базы данных
        /// </summary>
        private readonly _DBContext _db = new();


        /// <summary>
        /// Конструктор
        /// </summary>
        public CatalogData_oper()
        {

        }


        /// <summary>
        /// Получение запроса
        /// </summary>
        /// <param name="Flag_Del_val"></param>
        /// <returns></returns>
        public IQueryable<CatalogData> GetQuery(bool? Flag_Del_val = false)
        {
            IQueryable<CatalogData> query = from p in _db.CatalogDatas select p;

            if (Flag_Del_val.HasValue)
            {
                query = from p in query where p.Flag_Del == Flag_Del_val select p;
            }

            return query;
        }


        /// <summary>
        /// Получение по ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public CatalogData? Get(int ID, bool? Flag_Del_val = false)
        {
            CatalogData? elem = (from p in GetQuery(Flag_Del_val: Flag_Del_val) where p.ID == ID select p).FirstOrDefault();
            return elem;
        }

        

        /// <summary>
        /// Добавление
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public int Add(string Name, bool IsHit, string Image, string FpsNumber, string FpsBarWidth, string? FpsModalSerialized, 
                        string Cpu, string Gpu, string Ram, string StatusClass, string StatusText, string Price, string? SpecsModalSerialized)
        {

            CatalogData elem = new()
            {
                Name = Name,
                IsHit = IsHit,
                Image = Image,
                FpsNumber = FpsNumber,
                FpsBarWidth = FpsBarWidth,
                FpsModalSerialized = FpsModalSerialized,
                Cpu = Cpu,
                Gpu = Gpu,
                Ram = Ram,
                StatusClass = StatusClass,
                StatusText = StatusText,
                Price = Price,
                SpecsModalSerialized = SpecsModalSerialized
            };

            _db.CatalogDatas.Add(elem);
            try
            {
                _db.SaveChanges();

                return elem.ID;
            }
            catch (Exception)
            {
                return -202;
            }
        }

        /// <summary>
        /// Изменение
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Value_New"></param>
        /// <param name="Name_New"></param>
        /// <returns></returns>
        public int Edit(int ID, string Name, bool IsHit, string Image, string FpsNumber, string FpsBarWidth, string? FpsModalSerialized,
                        string Cpu, string Gpu, string Ram, string StatusClass, string StatusText, string Price, string? SpecsModalSerialized)
        {

            CatalogData? elem = Get(ID: ID);

            if (elem == null)
            {
                return -200;
            }

            elem.Name = Name;
            elem.IsHit = IsHit;
            elem.Image = Image;
            elem.FpsNumber = FpsNumber;
            elem.FpsBarWidth = FpsBarWidth;
            elem.FpsModalSerialized = FpsModalSerialized;
            elem.Cpu = Cpu;
            elem.Gpu = Gpu;
            elem.Ram = Ram;
            elem.StatusClass = StatusClass;
            elem.StatusText = StatusText;
            elem.Price = Price;
            elem.SpecsModalSerialized = SpecsModalSerialized;

            try
            {
                _db.SaveChanges();
                return elem.ID;
            }
            catch (Exception)
            {
                return -203;
            }
        }
    }
}
