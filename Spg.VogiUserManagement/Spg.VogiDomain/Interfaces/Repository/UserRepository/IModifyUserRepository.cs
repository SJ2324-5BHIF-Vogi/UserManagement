﻿using Spg.VogiDomain.Model;

namespace Spg.VogiDomain.Interfaces.Repository.UserRepositories;

public interface IModifyUserRepository
{
    void Create(User entity);
    void Delete(int id);
    void UpdateUsername(User entity);
    void UpdatePassword(User entity);
}
