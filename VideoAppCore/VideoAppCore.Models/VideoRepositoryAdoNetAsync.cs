using System.Data;
using System.Data.SqlClient;

namespace VideoAppCore.Models
{
    // 비동기
    public class VideoRepositoryAdoNetAsync : IVideoRepositoryAsync
    {
        private string _connectionString { get; }
        public VideoRepositoryAdoNetAsync(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public async Task<Video> AddVideoAsync(Video model)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                const string query =
                    "INSERT INTO VIDEOS(TITLE, URL, NAME, COMPANY, CREATEDBY) VALUES (@Title, @Url, @Name, @Company, @CreatedBy);" +
                    "SELECT CAST(SCOPE_IDENTITY() AS INT);";
                SqlCommand cmd = new SqlCommand(query, con) { CommandType = CommandType.Text };

                cmd.Parameters.AddWithValue("@Title", model.Title);
                cmd.Parameters.AddWithValue("@Url", model.Url);
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Company", model.Company);
                cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);

                con.Open();
                object result = await cmd.ExecuteScalarAsync();
                if (int.TryParse(result.ToString(), out int id))
                {
                    model.Id = id;
                }
                con.Close();
            }

            return model;
        }

        public async Task<Video> GetVideoByIdAsync(int id)
        {
            Video video = new Video();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                const string query = "SELECT * FROM VIDEOS WHERE ID = @Id";
                SqlCommand cmd = new SqlCommand(query, con)
                {
                    CommandType = CommandType.Text
                };

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                if (dr.Read())
                {
                    video.Id = dr.GetInt32(0);
                    video.Title = dr["Title"].ToString();
                    video.Url = dr["Url"].ToString();
                    video.Name = dr["Name"].ToString();
                    video.Company = dr["Company"].ToString();
                    video.Created = Convert.ToDateTime(dr["Created"]);
                }
                con.Close();
            
            }

            return video;
        }

        public async Task<List<Video>> GetVideosAsync()
        {
            List<Video> videos = new List<Video>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                const string query = "SELECT * FROM VIDEOS";
                SqlCommand cmd = new SqlCommand(query, con)
                {
                    CommandType = CommandType.Text
                };

                con.Open();
                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                while (dr.Read())
                {
                    Video video = new Video
                    {
                        Id = dr.GetInt32(0),
                        Title = dr["Title"].ToString(),
                        Url = dr["Url"].ToString(),
                        Name = dr["Name"].ToString(),
                        Company = dr["Company"].ToString(),
                        Created = Convert.ToDateTime(dr["Created"])
                    };
                    videos.Add(video);
                }

                con.Close();
            }
            return videos;
        }

        public async Task RemoveVideoAsync(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                const string query = "DELETE VIDEOS WHERE ID = @Id";
                SqlCommand cmd = new SqlCommand(query, con)
                {
                    CommandType = CommandType.Text
                };

                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                await cmd.ExecuteNonQueryAsync();
                con.Close();
            }
        }

        public async Task<Video> UpdateVideoAsync(Video model)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                const string query =
                    "UPDATE VIDEOS" +
                    "   SET TITLE   = @Title" +
                    "     , URL     = @Url" +
                    "     , NAME    = @Name" +
                    "     , COMPANY = @Company" +
                    "     , MODIFIEDBY = @ModifiedBy" +
                    " WHERE ID         = @Id";
                SqlCommand cmd = new SqlCommand(query, con) { CommandType = CommandType.Text };

                cmd.Parameters.AddWithValue("@Title", model.Title);
                cmd.Parameters.AddWithValue("@Url", model.Url);
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Company", model.Company);
                cmd.Parameters.AddWithValue("@CreatedBy", model.CreatedBy);

                con.Open();
                await cmd.ExecuteNonQueryAsync();
                con.Close();
            }

            return model;
        }
    }
}
