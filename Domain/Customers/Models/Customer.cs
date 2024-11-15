using System.ComponentModel.DataAnnotations;

namespace programming_work_backend.Domain.Customers.Models;

public class Customer
{
    [Key]
    public int Id { get; set; } = 0;
    [Required, EmailAddress]
    public string Mail { get; set; } = string.Empty;
    public int Age { get; set; } 
    public string Name { get; set; } = string.Empty;
    [Required]
    public bool IsActive { get; set; } = true;

}
