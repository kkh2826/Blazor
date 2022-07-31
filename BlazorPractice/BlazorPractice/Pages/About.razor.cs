namespace BlazorPractice.Pages
{
    public partial class About
    {
        private string title = "정보";
        private string subTitle = "사이트 정보";

        protected override void OnInitialized()
        {
            subTitle = DateTime.Now.ToShortTimeString();
        }
    }
}
