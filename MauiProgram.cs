using Microsoft.Extensions.Logging;
using DnDStock.Data;
using DnDStock.Services;

namespace DnDStock;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		var dbPath = Path.Combine(
			Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
			@"DnDStock.db3"
			);

		builder.Services.AddSingleton<CharacterService>(p => ActivatorUtilities.CreateInstance<CharacterService>(p, dbPath));
        builder.Services.AddSingleton<ItemService>(p => ActivatorUtilities.CreateInstance<ItemService>(p, dbPath));
        builder.Services.AddSingleton<StockService>(p => ActivatorUtilities.CreateInstance<StockService>(p, dbPath));

        return builder.Build();
	}
}
