using DnDStock.Data;
using DnDStock.Services;
using Microsoft.AspNetCore.Components;

namespace DnDStock.Pages.Components
{
    public partial class CharacterCardComponent
    {
        [Inject]
        private CharacterService _charService { get; set; }

        [Inject]
        private NavigationManager _navigator { get; set; }

        [Parameter]
        public Character MyCharacter { get; set; }

        [Parameter]
        public EventCallback<int> OnCharacterDeleted { get; set; }

        public async Task LevelUp() {
            MyCharacter.Level++;

            await _charService.UpdateCharacterAsync(MyCharacter);

        }

        private async Task DeleteCharacter()
        {
            await _charService.DeleteCharacterAsync(MyCharacter);

            await OnCharacterDeleted.InvokeAsync(MyCharacter.Id);

        }
    }
}
