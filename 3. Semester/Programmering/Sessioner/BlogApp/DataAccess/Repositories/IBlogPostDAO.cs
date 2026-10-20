using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    internal interface IBlogPostDAO
    {
        // Opret et nyt blogindlæg
        Task<int> CreateAsync(BlogPost entity);

        // Slet et blogindlæg ud fra dets ID
        Task<bool> DeleteAsync(int id);

        // Hent de 10 nyeste blogindlæg
        Task<IEnumerable<BlogPost>> Get10LatestAsync();

        // Hent alle blogindlæg
        Task<IEnumerable<BlogPost>> GetAllAsync();

        // Hent alle blogindlæg ud fra en specifik forfatter
        Task<IEnumerable<BlogPost>> GetByAuthorIdAsync(int authorId);

        // Hent et blogindlæg ud fra dets ID
        Task<BlogPost> GetByIdAsync(int id);

        // Hent blogindlæg baseret på en del af titlen eller indholdet
        Task<IEnumerable<BlogPost>> GetByPartOfTitleOrContentAsync(string partOfTitleOrContent);

        // Opdater indholdet eller titlen på et blogindlæg
        Task<bool> UpdateAsync(BlogPost entity);
    }
}
