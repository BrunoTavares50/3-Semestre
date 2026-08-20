namespace EventPlus.WebAPI.DTO
{
    public class EventoDTO
    {
        public string NomeEvento { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataEvento { get; set; } = DateTime.Now;
        public string ImagemUrl { get; set; } = string.Empty;

        public Guid? IdInstituicao { get; set; }

        public Guid? IdTipoEvento { get; set; }
    }
}
