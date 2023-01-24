using DnDStock.Data;
using DnDStock.Services;
using Microsoft.AspNetCore.Components;

namespace DnDStock.Pages.Items
{
    public partial class AddItem
    {
        [Inject]
        private NavigationManager _navigator { get; set; }

        [Inject]
        private ItemService _itemService { get; set; }

        private Item _item = new();

        [Parameter]
        public EventCallback<int> OnItemCreated { get; set; }

        private async void HandleSubmit() {
            await _itemService.CreateItemAsync(_item);

            await OnItemCreated.InvokeAsync(_item.Id);

            _item = new();
        }
    }
}
