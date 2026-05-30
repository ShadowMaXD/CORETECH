using Asp.Versioning;
using Business;
using Business.Definitions;
using Common.Consts;
using CORETECH_WebApi.Helpers;
using CORETECH_WebApi.Models.V1;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Runtime.Intrinsics.Arm;

namespace CORETECH_WebApi.Controllers.V1
{
    /// <summary>
    /// Тестовый контроллер
    /// </summary>
    [Tags("CatalogDatas")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/CatalogDatas/[action]")]
    [ApiController]
    public class CatalogDatasController(_BL_Context _bl) : ControllerBase
    {

        /// <summary>
        /// Возвращает список продуктов с информацией о них для заполнения
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<CCatalogData>))]
        public JsonResult GetListProducts()
        {
            List<CCatalogData>? list_result = _bl.CatalogDatas.GetList();

            if(list_result == null || list_result.Count == 0) 
            {
                return Helper_Result.GetJsonResult(Status: Consts.Status_Err, Code: -200, Data: null);
            }

            return Helper_Result.GetJsonResult(Status: Consts.Status_OK, Code: 200, Data: list_result);
        }



        /// <summary>
        /// Возвращает список продуктов с информацией о них для заполнения
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(int))]
        public JsonResult AddProduct(CCatalogData? data)
        {
            if(data == null)
            {
                return Helper_Result.GetJsonResult(Status: Consts.Status_Err, Code: -200, Data: null);

            }

            int result = _bl.CatalogDatas.Add(
                Name: data.Name,
                IsHit: data.IsHit,
                Image: data.Image,
                FpsNumber: data.FpsNumber,
                FpsBarWidth: data.FpsBarWidth,
                FpsModal: data.FpsModal,
                Cpu: data.Cpu,
                Gpu: data.Gpu,
                Ram: data.Ram,
                StatusClass: data.StatusClass,
                StatusText: data.StatusText,
                Price: data.Price,
                SpecsModal: data.SpecsModal
                );

            if(result < 0)
            {
                return Helper_Result.GetJsonResult(Status: Consts.Status_Err, Code: -200, Data: null);

            }

            return Helper_Result.GetJsonResult(Status: Consts.Status_OK, Code: 200, Data: result);
        }

    }
}
