namespace VideoAppCore.Models
{
    // 비동기방식
    public interface IVideoRepositoryAsync
    {
        Task<Video> AddVideoAsync(Video model);        // 입력
        Task<List<Video>> GetVideosAsync();            // 출력
        Task<Video> GetVideoByIdAsync(int id);         // 상세
        Task<Video> UpdateVideoAsync(Video model);     // 수정
        Task RemoveVideoAsync(int id);           // 삭제
    }
}
