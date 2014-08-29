using System;
using Anotar.Custom;
using UnityEngine;

[KSPAddon(KSPAddon.Startup.EditorAny, false)]
class Quatermaster : MonoBehaviour
{
    private Rect filterLocation;
    private string filterString = "";

    [LogToErrorOnException]
    public void Start()
    {
        filterLocation = new Rect(60, Screen.height - 92, EditorPanels.Instance.partsPanelWidth - 146, 20);

        EditorPartList.Instance.ExcludeFilters.AddFilter(new EditorPartListFilter("QUATERMASTER_FILTER", Filter));
    }

    [LogToErrorOnException]
    public void OnGUI()
    {
        if (Event.current.type == EventType.Repaint)
            GUI.skin = HighLogic.Skin;

        if (EditorLogic.fetch.editorScreen != EditorLogic.EditorScreen.Parts)
            return;

        var returnFilter = GUI.TextField(filterLocation, filterString);

        if (returnFilter != filterString)
        {
            filterString = returnFilter;
            LogTo.Debug(filterString);
            EditorPartList.Instance.Refresh();
        }
    }

    [LogToErrorOnException]
    private bool Filter(AvailablePart part)
    {
        var result = Compare(part.title, filterString);

        if (!result)
            result = Compare(part.manufacturer, filterString);

        return result;
    }

    [LogToErrorOnException]
    private bool Compare(string value, string searchString)
    {
        return value.IndexOf(searchString, StringComparison.InvariantCultureIgnoreCase) >= 0;
    }
}