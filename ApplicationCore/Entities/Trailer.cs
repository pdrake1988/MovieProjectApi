﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

public class Trailer
{
    public int Id { get; set; }

    public int MovieId { get; set; }

    public Movie Movie { get; set; }

    [Column(TypeName = "varchar(2084)")]
    public string TrailerUrl { get; set; }

    [Column(TypeName = "varchar(2084)")]
    public string Name { get; set; }
}
