// Install-Package Microsoft.EntityFrameworkCore.SqlServer
// Install-Package System.Configuration.ConfigurationManager

using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace VideoAppCore.Models
{
    public class VideoDbContext: DbContext
    {
        public VideoDbContext()
        {
            // Empty
        }

        public VideoDbContext(DbContextOptions<VideoDbContext> options): base(options)
        {
            // 공식과 같은 코드
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 닷넷 프레임워크 기반에서 호출되는 코드 영역
            // App.config 또는 Web.config 연결 문자열 사용
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        /// <summary>
        /// Video 앱
        /// </summary>
        public DbSet<Video> Videos { get; set; }
    }
}
