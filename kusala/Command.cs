using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using kusala.Contracts;
using kusala.Model;
using kusala.Revit;
using Microsoft.Extensions.DependencyInjection;

namespace kusala;

public class Command : IExternalCommand
{
    private ServiceProvider _services;

    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        //создаём и собираем коллекцию сервисов
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddSingleton<IWallDataGraber, WallDataGraber>();
        serviceCollection.AddSingleton<EntryPointHandler>();
        serviceCollection.AddSingleton<MainSequence>();

        _services = serviceCollection.BuildServiceProvider();

        //подписываемся на события ошибок ревит commandData.Application.Application.FailuresProcessing
        //TODO подписаться на ошибки, написать обработчик, в отдельном классе

        //запускаем основную последовательность
        _services.GetRequiredService<EntryPointHandler>().SetEntryEntities(commandData.Application.ActiveUIDocument.Document);
        _services.GetRequiredService<MainSequence>().Go();

        return Result.Succeeded;
    }
}
