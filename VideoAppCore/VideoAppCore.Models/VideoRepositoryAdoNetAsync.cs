namespace VideoAppCore.Models
{
    // 비동기
    public class VideoRepositoryAdoNetAsync : IVideoRepositoryAsync
    {
        public Task<Video> AddVideoAsync(Video model)
        {
            throw new NotImplementedException();
        }

        public Task<Video> GetVideoByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Video>> GetVideosAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoveVideoAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Video> UpdateVideoAsync(Video model)
        {
            throw new NotImplementedException();
        }
    }
}
