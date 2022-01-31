using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Poc.Distributed.Application.Infra.Repository.ReadOnly.Entities
{
    public class UserReadOnly
    {
        [BsonId()]
        public ObjectId Id { get; set; }

        [BsonElement("userId")]
        public int UserId { get; set; }

        [BsonElement("nome")]
        public string Nome { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        public static implicit operator UserReadOnly(Business.Domain.Entities.User user)
        {
            if (user is null)
                return null;

            return new UserReadOnly()
            {
                Email = user.Email,
                Nome = user.Nome,
                UserId = user.UserId
            };
        }
    }
}
