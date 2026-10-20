using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    internal interface IAuthorDAO
    {
        // Opret et nyt forfatter
        Task<int> CreateAsync(Author entity, string password);

        // Slet et blogindlæg ud fra dets ID
        Task<bool> DeleteAsync(int id);

        // Hent alle blogindlæg i systemet
        Task<IEnumerable<Author>> GetAllAsync();

        // Hent et specifikt blogindlæg ud fra forfatterens email
        Task<Author> GetByEmailAsync(string email);

        // Hent et specifikt blogindlæg ud fra dets ID
        Task<Author> GetByIdAsync(int id);

        // Log ind
        Task<int> LoginAsync(String email, string password);

        // Opdater indholdet eller titlen på et blogindlæg
        Task<bool> UpdateAsync(Author entity);

        // Opdater forfatterens adgangskode
        Task<bool> UpdatePasswordAsync(string email, string oldPassword, string newPassword);
    }
}
