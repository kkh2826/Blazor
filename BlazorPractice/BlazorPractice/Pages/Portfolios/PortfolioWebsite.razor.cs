using Microsoft.AspNetCore.Components;

namespace BlazorPractice.Pages.Portfolios
{
    public partial class PortfolioWebsite
    {
        [Inject]
        public NavigationManager NavigationManagerReference { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected void GoToDotNetKorea()
        {
            NavigationManagerReference.NavigateTo("/");
        }
    }
}
