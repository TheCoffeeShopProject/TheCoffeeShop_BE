using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatBusinessObject.DTO;
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

        [HttpGet("{id}")]
        public IActionResult GetTableByID(Guid id)
        {
            var table = _tableServices.GetTableByID(id);

            var responese = _mapper.Map<TableVM>(table);

            return Ok(responese);
        }

        [HttpPost]
        public IActionResult AddNewTable(TableCreateDTO table)
        {
            try
            {
                var _table = _mapper.Map<Table>(table);
                _tableServices.AddNewTable(_table);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTable([FromForm] TableUpdateDTO table, Guid id)
        {
            try
            {
                //if (table.TableID != id)
                //{
                //    return NotFound();
                //}
                //var _table = _mapper.Map<Table>(table);
                //_tableServices.UpdateTable(_table);

                //return Ok();

                var tables = _tableServices.GetTableByID(id);
                if (table.Status != null)
                {
                    tables.Status = table.Status;
                }
                if (table.Type != null)
                {
                    tables.Type = table.Type;
                }
                if (table.CoffeeID != null)
                {
                    tables.CoffeeID = (Guid)table.CoffeeID;
                }

                _tableServices.UpdateTable(tables);

                return Ok("Update Successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
