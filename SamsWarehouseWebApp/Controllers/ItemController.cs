using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SamsWarehouseWebApp.Models.Data;
using SamsWarehouseWebApp.Models.DBContext;
using SamsWarehouseWebApp.Models.DTO;
using SamsWarehouseWebApp.Services;
using System.Data;
using System.Linq;

namespace SamsWarehouseWebApp.Controllers
{
    public class ItemController : Controller
    {
        private readonly ItemDBContext _itemConext;
        private readonly SanitiserService _sanitiserService;

        public ItemController(ItemDBContext itemConext, SanitiserService sanitiserService)
        {
            _itemConext = itemConext;
            _sanitiserService = sanitiserService;
        }
        /// <summary>
        /// Returns an index view of items page
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View(_itemConext.Items.AsEnumerable());
        }
        /// <summary>
        /// HTTP GET request that retrieves and displays items in a partial view (item table)
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> ItemTablePartial(string query = "")
        {
            string SanQuery = _sanitiserService.Sanitiser.Sanitize(query);
            // Query string is filtered
            if (!string.IsNullOrEmpty(SanQuery))
            {
                // Item data is filtered based on item name and unit using string query
                var filteredItemData = _itemConext.Items.Where(c => c.ItemName.Contains(query) || c.Unit.Contains(query)).AsEnumerable();
                // Partial chunk of html is retrieved to display the filtered item in the item table
                return PartialView("_ItemTable", filteredItemData);
            }
            
            Thread.Sleep(2000);
            var itemData = _itemConext.Items.AsEnumerable();

            // Item data displayed in the item table 
            return PartialView("_ItemTable", itemData);
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create()
        {
            Thread.Sleep(2000);
            return PartialView("_CreateItem");
        }

        // POST: ItemController/
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ItemCreateDTO itemCreate)
        {
            try
            {
                var test = HttpContext.Request;
                Thread.Sleep(2000);
                // simple error handling
                if (ModelState.IsValid)
                {

                    Item item = new Item
                    {
                        ItemId = itemCreate.ItemId,
                        ItemName = itemCreate.ItemName,
                        Unit = itemCreate.Unit,
                        UnitPrice = itemCreate.UnitPrice
                    };

                    _itemConext.Items.Add(item);
                    await _itemConext.SaveChangesAsync();
                    return Created("/Item/Create", item);
                }
                else
                {
                    return BadRequest("There was an issue processing the provided model");
                }
            }
            catch
            {
                return Problem("There was an issue processing your request");
            }
        }

        /// <summary>
        /// HTTP GET method that retrieves item data by id. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: ItemController/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            //Thread.Sleep(2000);
            if (id == 0)
            {
                return RedirectToAction(nameof(Index));
            }

            var item = _itemConext.Items.FirstOrDefault(c => c.ItemId == id);

            return item != null ? PartialView("_Edit",item) : RedirectToAction(nameof(Index));
        }
        /// <summary>
        /// HTTP PUT method for editing an item 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        // PUT: ItemController/Edit/5
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<ActionResult> Edit([FromQuery] int id, [FromBody] Item item)
        {
            //if (id != item.ItemId)
            //{
            //    return NotFound();
            //}
            item.ItemId = id;
            if (ModelState.IsValid)
            {
                _itemConext.Items.Update(item);
                await _itemConext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }
        /// <summary>
        /// HTTP POST method that is used to delete items from a list. Retrieves item by id from the database using the _dbitemContext.
        /// If the item is retrieved, delete it from the list and save changes. Redirect to item index page. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: ItemController/Delete/5
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            try
            {
                var item = _itemConext.Items.FirstOrDefault(c => c.ItemId == id);
                if (item != null)
                {
                    _itemConext.Items.Remove(item);
                    await _itemConext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
