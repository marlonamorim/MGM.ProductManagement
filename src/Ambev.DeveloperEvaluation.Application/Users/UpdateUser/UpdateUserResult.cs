namespace Ambev.DeveloperEvaluation.Application.Users.UpdateUser;

/// <summary>
/// Represents the response returned after successfully updating a user.
/// </summary>
/// <remarks>
/// This response contains the assertion if user updating
/// </remarks>
public class UpdateUserResult
{
    /// <summary>
    /// Gets or sets if user updating.
    /// </summary>
    /// <value>A bool that assertion if user updated.</value>
    public bool Updated { get; set; }

    /// <summary>
    /// Initializes a new instance of UpdateUserResult
    /// </summary>
    /// <param name="updated">A bool that assertion if user updated</param>
    public UpdateUserResult(bool updated)
    {
        Updated = updated;
    }
}
