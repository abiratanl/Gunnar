using System.Net.Mime;
using Gunnar.Contexts.SharedContext.Entities;
using Gunnar.Contexts.SharedContext.Enums;

namespace BookContext.Entities;

public class Book : Entity
{
    #region Constructors

    public Book()
    {
    }

    #endregion
    
    #region Public Properties
    
    public string? Abstract { get; private set; } = string.Empty;
    public string Author { get; private set; } = string.Empty;
    public EBookCategory BookCategory { get; private set; }
    public EBookStatus EBookStatus { get; private set; }
    public string Editor { get; set; }
    public string? ISBN { get; private set; } = String.Empty;
    public int PageNumber { get; private set; }
    public string Title { get; private set; } = string.Empty;
    

    #endregion

    #region Methods

    

    #endregion
}