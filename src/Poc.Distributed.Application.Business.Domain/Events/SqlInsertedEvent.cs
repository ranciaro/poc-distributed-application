namespace Poc.Distributed.Application.Business.Domain.Events
{
    public class SqlInsertedEvent
    {
        public int UserId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
