using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

/// <summary>
/// Модель изменения роли
/// </summary>
public class ChangeRoleViewModel
{
    /// <summary>
    /// ID юзера, чья роль будет изменена
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// почта юзера
    /// </summary>
    public string UserEmail { get; set; }

    /// <summary>
    /// все роли
    /// </summary>
    public List<IdentityRole> AllRoles { get; set; }

    /// <summary>
    /// пользовательские роли
    /// </summary>
    public IList<string> UserRoles { get; set; }

    /// <summary>
    /// Изменение роли пользователя
    /// </summary>
    public ChangeRoleViewModel()
    {
        AllRoles = new List<IdentityRole>();
        UserRoles = new List<string>();
    }
}
