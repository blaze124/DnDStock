using DnDStock.Data;
using DnDStock.Services;
using Microsoft.AspNetCore.Components;

namespace DnDStock.Pages.Components
{
    public partial class ItemListComponent
    {
        [Inject]
        private ItemService _service { get; set; }

        [Parameter]
        public Item MyItem { get; set; }

        [Parameter]
        public EventCallback<int> OnItemDeleted { get; set; }

        public async Task DeleteItem() {
            await _service.DeleteItemAsync(MyItem);
            await OnItemDeleted.InvokeAsync(MyItem.Id);
        }
    }
}
