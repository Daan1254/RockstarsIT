using Microsoft.Build.Framework;

namespace RockstarsIT.Models;

public class MinimalSquadViewModel
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
}