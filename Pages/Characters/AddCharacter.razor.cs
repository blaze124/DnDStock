using DnDStock.Data;
using DnDStock.Services;
using Microsoft.AspNetCore.Components;

namespace DnDStock.Pages.Characters
{
    public partial class AddCharacter
    {
        [Inject]
        private NavigationManager _navigator { get; set; }

        [Inject]
        private CharacterService _charService { get; set; }

        private Character _character = new();

        [Parameter]
        public EventCallback<int> OnCharacterCreated { get; set; }

        private async void HandleSubmit()
        {
            await _charService.CreateCharacterAsync(_character);

            await OnCharacterCreated.InvokeAsync(_character.Id);

            _character = new();
        }

    }
}
