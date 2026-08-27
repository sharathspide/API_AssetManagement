using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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

        /// <summary>
        /// constructor for the controller
        /// </summary>
        /// <param name="AssetsService"></param>
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
                    return NotFound($"No Assets were found. Please try finding another Asset or contact admin");
                }
                return asset;
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data from the database: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAssetAsync(int id)
        {
            try
            {
                var isDeleted = await _assetService.DeleteAssetAsync(id);
                if (!isDeleted)
                {
                    return NotFound($"No Such asset Found to be Deleted!");
                }
                return Ok($"Asset found was deteted successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occured: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error occured while finding and deleting the asset.");
            }
        }
    }
}
