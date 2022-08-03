namespace VideoAppCore.Models._
{
    // 동기방식
    public interface IVideoRepository
    {
        Video AddVideo(Video model);        // 입력
        List<Video> GetVideos();            // 출력
        Video GetVideoById(int id);         // 상세
        Video UpdateVideo(Video model);     // 수정
        void RemoveVideo(int id);           // 삭제
    }
}
