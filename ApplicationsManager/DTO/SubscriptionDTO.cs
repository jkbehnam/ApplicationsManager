namespace ApplicationsManager.DTO
{
    public class SubscriptionDTO
    {
        public long Id { get; set; }
        public Guid? CustomerId { get; set; }
        public string? AppEName { get; set; }
        public string? AppName { get; set; }
        public long? PlanId { get; set; }
        public string? PlanName { get; set; }

        public string? DeviceId { get; set; }
        public long StartTime { get; set; }
        public long EndTime { get; set; }
        public Boolean? IsActive { get; set; }
    }
}
