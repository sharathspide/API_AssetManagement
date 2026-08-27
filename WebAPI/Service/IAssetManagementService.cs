using WebAPI.Model;

namespace WebAPI.Service
{
    public interface IAssetManagementService
    {
        /// <summary>
        /// Instance of Get all the assets Asynchronously
        /// </summary>
        /// <returns></returns>
        Task<List<Asset_Model>> GetAllAssetsAsync();

        /// <summary>
        /// Instance of getting an asset based on the Asset ID
        /// </summary>
        /// <param name="asset_id"></param>
        /// <returns></returns>
        Task<Asset_Model?> GetAssetByIdAsync(int asset_id);
        Task<Asset_Model> CreateAssetAsync(Asset_Model asset);
        Task<bool> UpdateAssetAsync(int asset_id,Asset_Model asset);
        Task<bool> DeleteAssetAsync(int asset_id);
    }
}
