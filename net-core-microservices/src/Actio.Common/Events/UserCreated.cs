namespace Actio.Common.Events
{
    public class UserCreated : IEvent
    {
        public string Email { get; }

        public string Name { get; }

        protected UserCreated()
        {
            // No Implementation
        }

        public UserCreated(string email, string name) => (Email, Name) = (email, name);
    }
}
