namespace backend.Src.Models
{
    public class BeneficiosFuncionariosModel
    {
        public int Id { get; set; }
        public int IdFuncionario { get; set; }
        public int IdBbeneficio { get; set; }
        public string? NomeFuncionario { get; set; }
        public string? DescricaoBeneficio { get; set; }
    }
}