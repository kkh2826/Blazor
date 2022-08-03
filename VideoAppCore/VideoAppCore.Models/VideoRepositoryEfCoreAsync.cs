using Microsoft.EntityFrameworkCore;

namespace VideoAppCore.Models
{
    public class VideoRepositoryEfCoreAsync : IVideoRepositoryAsync
    {
        private readonly VideoDbContext _context;

        public VideoRepositoryEfCoreAsync(VideoDbContext context)
        {
            this._context = context;
        }
        public async Task<Video> AddVideoAsync(Video model)
        {
            _context.Videos.Add(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<Video> GetVideoByIdAsync(int id)
        {
            return await _context.Videos.FindAsync(id);
        }

        public async Task<List<Video>> GetVideosAsync()
        {
            return await _context.Videos.ToListAsync();
        }

        public async Task RemoveVideoAsync(int id)
        {
            var video = await _context.Videos.FindAsync(id);
            if (video != null)
            {
                _context.Videos.Remove(video);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Video> UpdateVideoAsync(Video model)
        {
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
