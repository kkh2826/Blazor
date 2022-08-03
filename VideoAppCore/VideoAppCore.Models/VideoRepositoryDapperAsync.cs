using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace VideoAppCore.Models
{
    public class VideoRepositoryDapperAsync : IVideoRepositoryAsync
    {
        private readonly SqlConnection db;
        public VideoRepositoryDapperAsync(string connectionString)
        {
            db = new SqlConnection(connectionString);
        }

        public async Task<Video> AddVideoAsync(Video model)
        {
            const string query =
                    "INSERT INTO VIDEOS(TITLE, URL, NAME, COMPANY, CREATEDBY) VALUES (@Title, @Url, @Name, @Company, @CreatedBy);" +
                    "SELECT CAST(SCOPE_IDENTITY() AS INT);";

            int id = await db.ExecuteScalarAsync<int>(query, model);

            model.Id = id;

            return model;
        }

        public async Task<Video> GetVideoByIdAsync(int id)
        {
            const string query = "SELECT * FROM VIDEOS WHERE ID = @Id";

            var video = await db.QueryFirstOrDefaultAsync<Video>(query, new { id }, commandType: CommandType.Text);

            return video;
        }

        public async Task<List<Video>> GetVideosAsync()
        {
            const string query = "SELECT * FROM VIDEOS";

            var videos = await db.QueryAsync<Video>(query);

            return videos.ToList();
        }

        public async Task RemoveVideoAsync(int id)
        {
            const string query = "DELETE VIDEOS WHERE ID = @Id";

            await db.ExecuteAsync(query, new { id }, commandType: CommandType.Text);
        }

        public async Task<Video> UpdateVideoAsync(Video model)
        {
            const string query =
                    "UPDATE VIDEOS" +
                    "   SET TITLE   = @Title" +
                    "     , URL     = @Url" +
                    "     , NAME    = @Name" +
                    "     , COMPANY = @Company" +
                    "     , MODIFIEDBY = @ModifiedBy" +
                    " WHERE ID         = @Id";

            await db.ExecuteAsync(query, model);

            return model;
        }
    }
}
