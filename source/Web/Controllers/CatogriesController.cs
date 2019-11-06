using DotNetCore.AspNetCore;
using DotNetCore.Objects;
using DotNetCoreArchitecture.Application;
using DotNetCoreArchitecture.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Northwind.Core.Infra.Context;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
namespace DotNetCoreArchitecture.Web
{
    [ApiController]
    [RouteController(Name = "Catogries")]
    public class CatogriesController : BaseController
    {
        public CatogriesController(ICatogryApplicationService catogryApplicationService)
        {
            CatogryApplicationService = catogryApplicationService;
        }

        private ICatogryApplicationService CatogryApplicationService { get; }

        [AllowAnonymous]
        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync(CatogryModel CatogryModel)
        {
            return Result(await CatogryApplicationService.AddAsync(CatogryModel));
        }

        [AllowAnonymous]
        [HttpGet("List")]
        public async Task<string> ListAsync()
        {

            var xml = await CatogryApplicationService.ListAsync();
            /* XmlSerializer xsSubmit = new XmlSerializer(typeof(string));

             var xml_ = string.Empty;

             using (var sww = new StringWriter())
             {
                 using (XmlWriter writer = XmlWriter.Create(sww))
                 {
                     xsSubmit.Serialize(writer, xml);
                     xml_ = sww.ToString(); // Your XML
                 }
             }*/
            return xml;
        }
    }

}
