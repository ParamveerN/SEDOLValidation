using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// SEDOL Validation Result interface.
/// </summary>
public interface ISedolValidationResult
{
    /// <summary>
    /// Gets the input string.
    /// </summary>
    /// <value>
    /// The input string.
    /// </value>
    public string InputString { get; set; }

    /// <summary>
    /// Gets a value indicating whether the input string is a valid SEDOL.
    /// </summary>
    /// <value>
    /// <c>true</c> if the input string is a valid SEDOL; otherwise, <c>false</c>.
    /// </value>
    public bool IsValidSedol { get; set; }

    /// <summary>
    /// Gets a value indicating whether the input string represents a user defined SEDOL.
    /// </summary>
    /// <value>
    /// <c>true</c> if the input string represents a user defined SEDOL; otherwise, <c>false</c>.
    /// </value>
    public bool IsUserDefined { get; set; }

    /// <summary>
    /// Gets the validation details such as root cause of validation failure.
    /// </summary>
    /// <value>
    /// The validation details.
    /// </value>
    public string ValidationDetails { get; set; }
}