using Business.Definitions;
using Database.Definitions;
using Database.Opers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Business
{
    /// <summary>
    /// Класс работы с каталогом
    /// </summary>
    public class CatalogDatas
    {

        /// <summary>
        /// Класс работы с каталогом
        /// </summary>
        private readonly CatalogData_oper _dl_CatalogData = new();


        /// <summary>
        /// Добавление
        /// </summary>
        /// <returns></returns>
        public int Add(string Name, bool IsHit, string Image, string FpsNumber, string FpsBarWidth, Dictionary<string, string>? FpsModal,
                        string Cpu, string Gpu, string Ram, string StatusClass, string StatusText, string Price, Dictionary<string, string>? SpecsModal)
        {

            string FpsModalSerialized = FpsModal != null && FpsModal.Any() ? JsonSerializer.Serialize(FpsModal) : "{}";



            string SpecsModalSerialized = SpecsModal != null && SpecsModal.Any() ? JsonSerializer.Serialize(SpecsModal) : "{}";



            return _dl_CatalogData.Add(Name: Name, IsHit: IsHit, Image: Image, FpsNumber: FpsNumber, FpsBarWidth: FpsBarWidth, FpsModalSerialized: FpsModalSerialized,
                        Cpu: Cpu, Gpu: Gpu, Ram: Ram, StatusClass: StatusClass, StatusText: StatusText, Price: Price, SpecsModalSerialized: SpecsModalSerialized);
        }


        /// <summary>
        /// Редактирование
        /// </summary>
        /// <returns></returns>
        public int Edit(int ID, string Name, bool IsHit, string Image, string FpsNumber, string FpsBarWidth, Dictionary<string, string>? FpsModal,
                        string Cpu, string Gpu, string Ram, string StatusClass, string StatusText, string Price, Dictionary<string, string>? SpecsModal)
        {

            string FpsModalSerialized = FpsModal != null && FpsModal.Any() ? JsonSerializer.Serialize(FpsModal) : "{}";



            string SpecsModalSerialized = SpecsModal != null && SpecsModal.Any() ? JsonSerializer.Serialize(SpecsModal) : "{}";



            return _dl_CatalogData.Edit(ID: ID, Name: Name, IsHit: IsHit, Image: Image, FpsNumber: FpsNumber, FpsBarWidth: FpsBarWidth, FpsModalSerialized: FpsModalSerialized,
                        Cpu: Cpu, Gpu: Gpu, Ram: Ram, StatusClass: StatusClass, StatusText: StatusText, Price: Price, SpecsModalSerialized: SpecsModalSerialized);
        }


        /// <summary>
        /// Получение списка
        /// </summary>
        /// <returns></returns>
        public List<CCatalogData> GetList()
        {
            List<CCatalogData> result = new();

            List<CatalogData> list_Products = _dl_CatalogData.GetQuery().ToList();

            foreach (CatalogData product in list_Products) 
            {
                result.Add(new CCatalogData()
                {
                    ID = product.ID,
                    Name = product.Name,
                    IsHit = product.IsHit,
                    Image = product.Image,
                    FpsNumber = product.FpsNumber,
                    FpsBarWidth = product.FpsBarWidth,
                    FpsModal = product.FpsModalSerialized != null ? JsonSerializer.Deserialize<Dictionary<string, string>>(product.FpsModalSerialized) : [],
                    Cpu = product.Cpu,
                    Gpu = product.Gpu,
                    Ram = product.Ram,
                    StatusClass = product.StatusClass,
                    StatusText = product.StatusText,
                    Price = product.Price,
                    SpecsModal = product.SpecsModalSerialized != null ? JsonSerializer.Deserialize<Dictionary<string, string>>(product.SpecsModalSerialized) : [],

                });
            }

            return result;
        }
    }
}
