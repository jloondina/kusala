using Autodesk.Revit.DB;

namespace kusala.Revit;

public class EntryPointHandler
{
    public void SetEntryEntities(Document document)
    {
        Document = document;
    }

    public Document Document { get; private set; }
}
