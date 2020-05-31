using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayerProject.API.Controllers;
using NLayerProject.API.DTOs;
using NLayerProject.Core.Service;
using NLayerProject.Service.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.API.Filters
{
    public class NotFoundFilter<TEntity> : IAsyncActionFilter where TEntity : class
    {

        private readonly IService<TEntity> _service;

        public NotFoundFilter(IService<TEntity> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var id = (int)context.ActionArguments.Values.FirstOrDefault();

            var entry = await _service.GetByIdAsync(id);

            if (entry != null)

            {

                await next();

            }

            else

            {

                ErrorDto errorDto = new ErrorDto();

                errorDto.Status = 400;

                errorDto.Errors.Add($"id'si {id} olan ürün veritabanında bulunamadı");

                context.Result = new NotFoundObjectResult(errorDto);
            }


    

      

}
        //  private readonly IService<TEntity> asda;



        //public NotFoundFilter()
        //{

        //}

        //public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        //{



        //    // var thisController = ((ProductController)context.Controller);

        //    // var a = context.HttpContext.RequestServices.GetServic

        //    int id = (int)context.ActionArguments.Values.FirstOrDefault();

        //    var controller = context.Controller;

        //    var product = await _productService.GetByIdAsync(id);

        //    if (product != null)
        //    {
        //        await next();
        //    }
        //    else
        //    {
        //        ErrorDto errorDto = new ErrorDto();

        //        errorDto.Status = 404;

        //        errorDto.Errors.Add($"id'si {id} olan ürün veritabanında bulunamadı");

        //        context.Result = new NotFoundObjectResult(errorDto);
        //    }
        //}

    }
}