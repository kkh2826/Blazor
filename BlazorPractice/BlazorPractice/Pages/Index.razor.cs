using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorPractice.Pages
{
    public partial class Index
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        protected override void OnInitialized()
        {
            
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await JSRuntime.InvokeAsync<object>("RunCarousel");
        }
    }
}
