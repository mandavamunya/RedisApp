namespace RedisApp.DistributedCache.Domain.Entities
{
    public class User
    {
        public User()
        {
        }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}
