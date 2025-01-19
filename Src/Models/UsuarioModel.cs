namespace backend.Src.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Usuario { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}