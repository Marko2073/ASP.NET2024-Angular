﻿namespace AspProjekat2024.API.Core
{
    public interface ITokenStorage
    {
        bool Exists(Guid tokenId);
        void Add(Guid tokenId);
        void Remove(Guid tokenId);
    }
}
