using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheCoffeeCatBusinessObject;
using TheCoffeeCatBusinessObject.BusinessObject;
using TheCoffeeCatBusinessObject.DTO;
using TheCoffeeCatBusinessObject.DTO.Request;
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
        public IActionResult AddNewMenu(MenuCreateDTO menu)
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

        [HttpPut("{id}")]
        public IActionResult UpdateMenu([FromForm] MenuUpdateDTO menu, Guid id)
        {
            try
            {
                var menus = _menuServices.GetMenuByID(id);
                if (menu.Status != null)
                {
                    menus.Status = (bool)menu.Status;
                }
                if (menu.CoffeeID != null)
                {
                    menus.CoffeeID = (Guid)menu.CoffeeID;
                }
                if (menu.DrinkID != null)
                {
                    menus.DrinkID = (Guid)menu.DrinkID;
                }
                if (menu.CatProductID != null)
                {
                    menus.CatProductID = (Guid)menu.CatProductID;
                }


                _menuServices.UpdateMenu(menus);

                return Ok("Update Successfully");
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
