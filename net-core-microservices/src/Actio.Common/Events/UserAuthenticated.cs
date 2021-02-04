namespace Actio.Common.Events
{
    public class UserAuthenticated:IEvent
    {
        public string Email { get; }

        protected UserAuthenticated()
        {
            // No implementation
        }

        public UserAuthenticated(string email)
        {
            Email = email;
        }

    }
}
