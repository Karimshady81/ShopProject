using Microsoft.AspNetCore.Components;
using ShopProject.Models;

namespace ShopProject.App.Pages
{
    partial class PieCard
    {
        [Parameter]
        public Pie? Pie { get; set; }
    }
}
