using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatBusinessObject.DTO;
using TheCoffeeCatBusinessObject.ViewModels;
using TheCoffeeCatService.IServices;
using TheCoffeeCatService.Services;

namespace TheCoffeeCatStore.Controllers.MenusController
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IMenuServices _menuServices;
        private readonly IMapper _mapper;

        public MenusController(IMenuServices menuServices, IMapper mapper)
        {
            _menuServices = menuServices;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllMenu()
        {
            try
            {
                if (_menuServices.GetAllMenu() == null)
                {
                    return NotFound();
                }
                var menus = _menuServices.GetAllMenu();
                var response = _mapper.Map<List<MenuVM>>(menus);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetMenuByID(Guid id)
        {
            var menu = _menuServices.GetMenuByID(id);

            var responese = _mapper.Map<MenuVM>(menu);

            return Ok(responese);
        }

        [HttpGet("byshopid/{shopId}")]
        public IActionResult GetMenuByShopID(Guid id)
        {
            var menu = _menuServices.GetMenuByShopID(id);

            var responese = menu.Select(menu => _mapper.Map<MenuVM>(menu)).ToList();

            return Ok(responese);
        }

        [HttpPost]
        public IActionResult AddNewMenu(MenuDTO menu)
        {
            try
            {
                var _menu = _mapper.Map<Menu>(menu);
                _menuServices.AddNewMenu(_menu);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateMenu(MenuDTO menu, Guid id)
        {
            try
            {
                if (menu.MenuID != id)
                {
                    return NotFound();
                }
                var _menu = _mapper.Map<Menu>(menu);
                _menuServices.UpdateMenu(_menu);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMenu(Guid id)
        {
            if (_menuServices.GetAllMenu() == null)
            {
                return NotFound();
            }
            var menu = _menuServices.GetMenuByID(id);
            if (menu == null)
            {
                return NotFound();
            }

            _menuServices.ChangeStatusMenu(menu);


            return Ok("Delete Successfully");
        }


    }
}
