using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Core.Model;

[PrimaryKey("Id")]
public class User
{
    [MaxLength(50)]
    public string Id { get; set; }
    [Required]
    [MaxLength(20)]
    [MinLength(5)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(20)]
    [MinLength(5)]
    public string LastName { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public DateTime BirthOfDate { get; set; }
}