using System.Security.Claims;
using programming_work_backend.Domain.Users.Models;

namespace programming_work_backend.Domain.Jwt
{
    public class Jwt
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }

        public static dynamic validarToken(ClaimsIdentity identity)
        {
            try
            {
                if(identity.Claims.Count() == 0)
                {
                    return new
                    {
                        success = false,
                        message = "Verificar si estás enviando un token válido",
                        result = ""
                    };
                }

                // Acceder al ID del usuario
                var id = identity.Claims.FirstOrDefault(x => x.Type == "id")?.Value;

                if (id == null)
                {
                    return new
                    {
                        success = false,
                        message = "Token inválido: ID no encontrado",
                        result = ""
                    };
                }

                User usuario = User.DBContext().FirstOrDefault(x => x.id == id);

                if (usuario == null)
                {
                    return new
                    {
                        success = false,
                        message = "Usuario no encontrado",
                        result = ""
                    };
                }

                return new
                {
                    success = true,
                    message = "Éxito",
                    result = usuario
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    success = false,
                    message = "Error: " + ex.Message,
                    result = ""
                };
            }
        }
    }
}
