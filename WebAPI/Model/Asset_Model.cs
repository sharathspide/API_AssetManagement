namespace WebAPI.Model
{
    public class Asset_Model
    {
        public int AssetId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public object? EmployeeId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public User? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public User? UpdatedBy { get; set; }
        public bool isDamaged { get; set; }
        public bool isRepaired { get; set; }
        public bool isAssigned { get; set; }
    }
    public class User 
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }

    }
}
