using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static Dictionary<string, GameObject> panels = new Dictionary<string, GameObject>();

    [SerializeField] private GameObject healthUI;
    [SerializeField] private GameObject coinUI;
    [SerializeField] private GameObject winUI;

    public void Start()
    {
        panels.Add("healthUI", healthUI);
        panels.Add("coinUI", coinUI);
        panels.Add("winUI", winUI);
    }

    public static void ActivateUI(string panelName)
    {
        GameObject panel;

        if(panels.TryGetValue(panelName, out panel))
            panel.SetActive(true);
        else
            Debug.LogError("Panel with name: " + panelName + " cannot be found.");

    }

    public static void DeActivateUI(string panelName)
    {
        GameObject panel;

        if (panels.TryGetValue(panelName, out panel))
            panel.SetActive(false);
        else
            Debug.LogError("Panel with name: " + panelName + " cannot be found.");

    }

}
