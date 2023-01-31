﻿using System.ComponentModel.DataAnnotations;

namespace Gunnar.Contexts.SharedContext.Enums;

public enum ERole : byte
{
    [Display(Name="Diácono")]
    Deacon = 0,
    [Display(Name="Evangelista")]
    Evangelist = 1,
    [Display(Name="Membro")]
    Member = 2,
    [Display(Name="Pastor")]
    Pastor = 3,
    [Display(Name="Presbítero")]
    Elder = 4 //Presbítero
}