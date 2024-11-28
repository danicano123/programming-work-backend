namespace programming_work_backend.Domain.Users.Models;

using System;
using System.ComponentModel.DataAnnotations;

public class User
{    
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Rol { get; set; } = string.Empty;

    public static List<User> DBContext()
    {
        var list = new List<User>
            {
                new() {
                    Id = 1,
                    Name = "Mateo",
                    Password = "123",
                    Rol = "empleado"
                },
                new() {
                    Id = 2,
                    Name = "Marcos",
                    Password = "123",
                    Rol = "empleado"
                },
                new() {
                    Id = 3,
                    Name = "Lucas",
                    Password = "123",
                    Rol = "asesor"
                },
                new() {
                    Id = 4,
                    Name = "Juan",
                    Password = "123",
                    Rol = "administrador"
                }
            };

        return list;
    }
}



