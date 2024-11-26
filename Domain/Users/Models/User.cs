namespace programming_work_backend.Domain.Users.Models;

using System;
using programming_work_backend.Domain.Users.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    public string id { get; set; }
    public string user { get; set; } = string.Empty;
    public string password { get; set; } = string.Empty;
    public string rol { get; set; } = string.Empty;

    public static List<User> DBContext()
    {
        var list = new List<User>
            {
                new User
                {
                    id = "1",
                    user = "Mateo",
                    password = "123",
                    rol = "empleado"
                },
                new User
                {
                    id = "2",
                    user = "Marcos",
                    password = "123",
                    rol = "empleado"
                },
                new User
                {
                    id = "3",
                    user = "Lucas",
                    password = "123",
                    rol = "asesor"
                },
                new User
                {
                    id = "4",
                    user = "Juan",
                    password = "123",
                    rol = "administrador"
                }
            };

        return list;
    }
}



