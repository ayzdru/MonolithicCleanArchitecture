using Microsoft.AspNetCore.Identity;
using System;

namespace CleanArchitecture.Core.Entities;

public class UserToken : IdentityUserToken<Guid>
{
}