using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Xml.Linq;
using System.IO;
using Extenstions.Editor;
using System.Xml.Serialization;
public class LevelConfigurationEditorWindow : EditorWindow
{
    private SelectionE configSelection;
    [MenuItem("Configuration/Level Configuration Window")]
    static void Init()
    {
        LevelConfigurationEditorWindow window = (LevelConfigurationEditorWindow)EditorWindow.GetWindow(typeof(LevelConfigurationEditorWindow));
        window.Show();
    }

    private string[] configs;
    XElement levelConfig;

    private void OnEnable()
    {
        configs = Directory.GetFiles("Assets\\Resources\\LevelConfiguration\\","*.xml");
        
        configSelection = new SelectionE(configs);
        configSelection.SelectedChanged += ConfigSelection_SelectedChanged;

    }

    private void ConfigSelection_SelectedChanged(object sender, System.EventArgs e)
    {
        levelConfig = XElement.Load(configs[configSelection.Selected]);
    }

    private void OnGUI()
    {
        configSelection.OnGUI();
    }
}
