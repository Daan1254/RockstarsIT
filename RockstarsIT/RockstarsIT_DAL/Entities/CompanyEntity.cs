﻿namespace RockstarsIT_DAL.Entities;

public  class CompanyEntity
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<SquadEntity> Squads { get; set; }
}
