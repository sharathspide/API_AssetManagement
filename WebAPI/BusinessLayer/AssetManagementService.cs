using WebAPI.Model;
using WebAPI.Service;

namespace WebAPI.BusinessLayer
{
    public class AssetManagementService : IAssetManagementService
    {
        /// <summary>
        /// Mock data for assets
        /// </summary>
        public static List<Asset_Model> assets = new List<Asset_Model>{
                new Asset_Model { AssetId = 1, Name = "Laptop", Description = "Dell XPS 13", CompanyId = 1,EmployeeId = 101, CreatedDate = DateTime.Now,UpdatedBy = new Employee { EmployeeId = 101, Name = "John Doe" }, isDamaged = true,isRepaired = false, isAssigned = true },
                new Asset_Model { AssetId = 2, Name = "Monitor", Description = "LG UltraWide", CompanyId = 1, EmployeeId = 102, CreatedDate = DateTime.Now, UpdatedBy = new Employee { EmployeeId = 102, Name = "Jane Smith" }, isDamaged= false, isRepaired = true, isAssigned = true },
                new Asset_Model { AssetId = 3, Name = "Monitor", Description = "LG UltraWide", CompanyId = 2, EmployeeId = 103, CreatedDate = DateTime.Now, UpdatedBy = new Employee { EmployeeId = 103, Name = "Peter Parker" }, isDamaged= false, isRepaired = true, isAssigned = true },
                new Asset_Model { AssetId = 4, Name = "Mouse", Description = "Zebronics", CompanyId = 1, EmployeeId = 102, CreatedDate = DateTime.Now, UpdatedBy = new Employee { EmployeeId = 102, Name = "Jane Smith" }, isDamaged= false, isRepaired = true, isAssigned = true }
            };


        public Task<Asset_Model> AddAssetAsync(Asset_Model asset)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete by finding the asset by asset_ID
        /// </summary>
        /// <param name="asset_id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAssetAsync(int asset_id)
        {
            try
            {
                var asset = await GetAssetByIdAsync(asset_id);
                if (asset == null)
                {
                    return await Task.FromResult(false);
                }
                assets.Remove(asset);
                Console.WriteLine(assets);
                return await Task.FromResult(true);
                
            }
            catch(Exception e)
            {
                Console.WriteLine($"Something happend while finding and deleting the asset. Exception: {e.Message}");
                throw;
            }
        }

        /// <summary>
        /// Retrieves all assets asynchronously.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Asset_Model>> GetAllAssetsAsync()
        {
            try
            {
                if(assets == null || assets.Count == 0)
                {
                    throw new Exception("No assets found.");
                }
                return await Task.FromResult(assets);

            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework here)
                Console.WriteLine($"An error occurred while retrieving assets: {ex.Message}");
                throw; // Rethrow the exception to be handled by the caller
            }
        }

        /// <summary>
        /// Retrieves an asset by its ID asynchronously.
        /// </summary>
        /// <param name="asset_id"></param>
        /// <returns></returns>
        public async Task<Asset_Model?> GetAssetByIdAsync(int asset_id)
        {
            try
            {
                var asset = assets.FirstOrDefault(asset => asset.AssetId == asset_id);
                return await Task.FromResult(asset);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An Error has occured: {ex.Message}");
                throw;
            }
        }

        public Task<bool> UpdateAssetAsync(int asset_id, Asset_Model asset)
        {
            throw new NotImplementedException();
        }
    }
}
