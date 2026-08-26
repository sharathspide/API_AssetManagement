using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.BusinessLayer;
using WebAPI.Model;
using WebAPI.Service;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetManagementController : ControllerBase
    {
        private readonly IAssetManagementService _assetService;
        public AssetManagementController(IAssetManagementService AssetsService)
        {
            _assetService = AssetsService;
        }
        /// <summary>
        /// Get all assets
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Asset_Model>>> GetAllAssets()
        {
            try
            {
                return await _assetService.GetAllAssetsAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data from the database: {ex.Message}");
            }
        }

        /// <summary>
        /// Get asset by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Asset_Model>> GetAssetByIdAsync(int id)
        {
            try
            {
                var asset = await _assetService.GetAssetByIdAsync(id);
                if (asset == null)
                {
                    return NotFound($"No such Asset found. Please try finding another Asset or contact admin");
                }
                return asset;
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data from the database: {ex.Message}");
            }
        }
    }
}
