﻿

using Microsoft.AspNetCore.Identity;

namespace Data.Model
{
    /// <summary>
    /// les utilisateurs de l'appli : formateurs, stagiaires etc
    /// </summary>
    public class User : IdentityUser<int>
    {
    }
}