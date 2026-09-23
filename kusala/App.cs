using Autodesk.Revit.UI;

namespace kusala;

public class App : IExternalApplication
{
    public Result OnShutdown(UIControlledApplication application)
    {
        return Result.Succeeded;
    }

    public Result OnStartup(UIControlledApplication application)
    {
        //создаём кнопку плагина в панели из класса Command
    }
}
