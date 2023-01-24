using DnDStock.Data;
using DnDStock.Services;
using Microsoft.AspNetCore.Components;

namespace DnDStock.Pages
{

    public partial class Index
    {
        [Inject]
        private NavigationManager _navigator { get; set; }

        [Inject]
        private CharacterService _charService { get; set; }

        private List<Character> _characterList { get; set; } = new();

        private bool _hideForm = true;

        private void ShowAddCharacterForm()
        {
            _hideForm = false;
        }

        protected override async Task OnInitializedAsync()
        {
            _characterList = await _charService.GetAllAsync();
        }

        private async Task CharacterDeleted()
        {
            _characterList = await _charService.GetAllAsync();
        }

        private async Task CharacterCreated()
        {
            _hideForm = true;
            _characterList = await _charService.GetAllAsync();
        }
    }
}
