namespace EventPlus.WebAPI.Utils
{
    /// <summary>
    /// Utilitário estático responsável pelas operações de criptografia e hashing de senhas na API
    /// </summary>
    public static class Criptografia
    {
        // método estático
        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }
    }
}
