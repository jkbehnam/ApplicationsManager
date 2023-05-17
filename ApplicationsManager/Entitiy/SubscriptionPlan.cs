namespace ApplicationsManager.Entitiy
{
    public class SubscriptionPlan
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? MaxUsers { get; set; }
        public int? Days { get; set; }

        public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();

    }
}
