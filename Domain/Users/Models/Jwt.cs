using System.Security.Claims;

namespace programming_work_backend.Domain.Users.Models
{
    public class JwtConfig
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }

        public static dynamic ValidarToken(ClaimsIdentity identity)
        {
            try
            {
                // Validar si el identity no es válido o no contiene claims
                if (identity == null || !identity.Claims.Any())
                {
                    return new
                    {
                        success = false,
                        message = "El token proporcionado no contiene información válida.",
                        result = ""
                    };
                }

                // Obtener el ID del usuario desde los claims
                var idClaim = identity.Claims.FirstOrDefault(x => x.Type == "id")?.Value;

                if (string.IsNullOrEmpty(idClaim))
                {
                    return new
                    {
                        success = false,
                        message = "Token inválido: no se encontró el ID del usuario.",
                        result = ""
                    };
                }

                // Intentar convertir el ID a entero
                if (!int.TryParse(idClaim, out int userId))
                {
                    return new
                    {
                        success = false,
                        message = "Token inválido: el ID del usuario no es un número válido.",
                        result = ""
                    };
                }

                // Buscar usuario en el contexto simulado
                User usuario = ObtenerUsuarioPorId(userId);

                if (usuario == null)
                {
                    return new
                    {
                        success = false,
                        message = "Usuario no encontrado en el sistema.",
                        result = ""
                    };
                }

                // Devolver respuesta exitosa
                return new
                {
                    success = true,
                    message = "Token validado correctamente.",
                    result = usuario
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    success = false,
                    message = $"Ocurrió un error al validar el token: {ex.Message}",
                    result = ""
                };
            }
        }

        private static User ObtenerUsuarioPorId(int id)
        {
            // Simular búsqueda en la base de datos
            return User.DBContext().SingleOrDefault(x => x.Id == id);
        }
    }
}
