using Microsoft.AspNetCore.Mvc;

namespace SamsWarehouseWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : Controller
    {
        [HttpPost("SetTheme")]
        public async Task<IActionResult> SetTheme([FromBody] ThemeSetting themeSwitch)
        {
            HttpContext.Session.SetString("theme", themeSwitch.Theme);
            return Ok();
        }

        public class ThemeSetting
        {
            public string Theme { get; set; }
        }
    }
}
