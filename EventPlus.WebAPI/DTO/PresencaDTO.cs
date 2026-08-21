namespace EventPlus.WebAPI.DTO
{
    public class PresencaDTO
    {
        public bool Situacao { get; set; }
        public Guid? IdUsuario { get; set; } = null!;
        public Guid? IdEvento { get; set; } = null!;
    }
}
