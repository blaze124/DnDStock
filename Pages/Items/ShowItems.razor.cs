using DnDStock.Data;
using DnDStock.Services;
using Microsoft.AspNetCore.Components;

namespace DnDStock.Pages.Items
{
    public partial class ShowItems
    {
        [Inject]
        private ItemService _itemService { get; set; }

        [Inject]
        private NavigationManager _navigator { get; set; }

        private List<Item> _items { get; set; } = new();

        private List<Item> _equipment { get; set; } = new();

        private bool _hiddenForm = true;

        protected override async Task OnInitializedAsync()
        {
            _items = await _itemService.GetAllAsync();

            _equipment = _items.Where(i => i.IsEquipment).ToList();
            _items.RemoveAll(i => i.IsEquipment);
        }

        private void ShowFormSection()
        {
            _hiddenForm = false;
        }

        private void HideFormSection()
        {
            _hiddenForm = true;
        }

        private async Task ItemCreated()
        {
            _hiddenForm = true;
            await OnInitializedAsync();
        }

        private async Task ItemDeleted()
        {
            await OnInitializedAsync();
        }
    }
}
