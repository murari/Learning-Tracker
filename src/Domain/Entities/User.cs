namespace LearningTracker.IntegrationTests.Infrastructure.DataAccess
{
    public class User {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual int Role { get; set; }
    }
}