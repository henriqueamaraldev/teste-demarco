using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class Log
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("dataHora")]
        public DateTime DataHora { get; set; }

        [BsonElement("acao")]
        public string Acao { get; set; } = string.Empty;

        [BsonElement("idCliente")]
        public Guid IdCliente { get; set; }

        public Log() { }

        public Log(string acao, Guid idCliente)
        {
            DataHora = DateTime.UtcNow;
            Acao = acao;
            IdCliente = idCliente;
        }
    }
}
