using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetManagementController : ControllerBase
    {
        public static List<Asset_Model> assets = new List<Asset_Model>{
                new Asset_Model { AssetId = 1, Name = "Laptop", Description = "Dell XPS 13", EmployeeId = 101, CreatedDate = DateTime.Now,UpdatedBy = new User { EmployeeId = 101, Name = "John Doe" }, isDamaged = true,isRepaired = false, isAssigned = true },
                new Asset_Model { AssetId = 2, Name = "Monitor", Description = "LG UltraWide", EmployeeId = 102, CreatedDate = DateTime.Now, UpdatedBy = new User { EmployeeId = 102, Name = "Jane Smith" }, isDamaged= false, isRepaired = true, isAssigned = false }
            };

        /// <summary>
        /// Get all assets
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Asset_Model>>> GetAllAssets() => await Task.FromResult(Ok(assets));
    }
}
