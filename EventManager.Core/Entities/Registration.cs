using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Core.Entities;
public class Registration
{
    public int Id { get; set; }
    public DateTime RegistrationDate { get; set; }
    public Event Event { get; set; }
    public User User { get; set; }
}