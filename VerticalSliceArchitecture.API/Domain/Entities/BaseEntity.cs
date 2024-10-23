﻿using System.ComponentModel.DataAnnotations.Schema;

namespace VerticalSliceArchitecture.API.Domain.Entities
{
    public abstract class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = default!;
    }
}
