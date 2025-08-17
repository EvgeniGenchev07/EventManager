using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Core.Entities;
public class Speaker
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Biography { get; set; }
    public string Email { get; set; }
    public ICollection<Event> Events { get; set; }
}