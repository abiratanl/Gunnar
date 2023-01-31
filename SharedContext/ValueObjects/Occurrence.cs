using System.ComponentModel.DataAnnotations;
using Gunnar.Contexts.SharedContext.Enums;
using Gunnar.Contexts.SharedContext.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gunnar.Contexts.SharedContext.ValueObjects;
[Owned]
public class Occurrence : ValueObject
{
    #region Constructors

    public Occurrence()
    {
        
    }
    
    public Occurrence(DateTime occurrenceDate,
        EOccurrenceType occurrenceType, string notes) =>
        (OccurrenceDate,  OccurrenceType, Notes)  = 
        (occurrenceDate, occurrenceType, notes);
   


    #endregion
    
    #region Public Properties

    public DateTime OccurrenceDate { get;private set; }
    public EOccurrenceType OccurrenceType { get; private set; } = 0;
    public string? Notes { get; private set; }

    #endregion

    #region Methods

    
    #endregion
}