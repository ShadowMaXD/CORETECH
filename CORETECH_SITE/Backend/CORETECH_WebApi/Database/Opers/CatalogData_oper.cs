using Database.Definitions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;
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
        public int Add(decimal Value, string? Name)
        {

            CatalogData elem = new()
            {
                
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
        public int Edit(int ID, decimal Value_New, string? Name_New)
        {
            string loginfo = $"ID='{ID}' Value_New='{Value_New}' Name_New='{Name_New}'";

            CatalogData? elem = Get(ID: ID);

            if (elem == null)
            {
                return -200;
            }

            elem.Name = Name_New;

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
