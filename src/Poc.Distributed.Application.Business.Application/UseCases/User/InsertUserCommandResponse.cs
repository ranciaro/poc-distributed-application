namespace Poc.Distributed.Application.Business.Application
{
    public class InsertUserCommandResponse
    {
        public InsertUserCommandResponse(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; set; }
    }
}
