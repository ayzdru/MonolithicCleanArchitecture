using System;

namespace CleanArchitecture.Core.Interfaces;

public interface ICurrentUserService
{
    Guid? UserId { get; }
}
