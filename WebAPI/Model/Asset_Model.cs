namespace WebAPI.Model
{
    /// <summary>
    /// Model representing the Assets data structure
    /// </summary>
    public class Asset_Model
    {
        public int AssetId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public object? EmployeeId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Employee? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Employee? UpdatedBy { get; set; }
        public bool isDamaged { get; set; }
        public bool isRepaired { get; set; }
        public bool isAssigned { get; set; }
    }

    /// <summary>
    /// Employee model structure
    /// </summary>
    public class Employee 
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }

    }
}
