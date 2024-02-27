using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheCoffeeCatBusinessObject.ViewModels;
using TheCoffeeCatService.IServices;
using TheCoffeeCatService.Services;

namespace TheCoffeeCatStore.Controllers.TablesController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private readonly ITableServices _tableServices;
        private readonly IMapper _mapper;

        public TablesController(ITableServices tableServices, IMapper mapper)
        {
            _tableServices = tableServices;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllTable()
        {
            try
            {
                if (_tableServices.GetAllTable() == null)
                {
                    return NotFound();
                }
                var tables = _tableServices.GetAllTable();
                var response = _mapper.Map<List<TableVM>>(tables);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
