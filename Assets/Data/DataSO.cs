using System.Collections;
using System.Collections.Generic;
using EasyButtons;
using UnityEngine;
using UnityEngine.Rendering;
using System.ComponentModel;
using Unity.Collections;
using System.IO;

public abstract class DataSO : ScriptableObject
{
    [Header("Loading JSON")]
    public string LoadJsonNameInput;

    [Button(Spacing = ButtonSpacing.Before)]
    public void LoadFromJSON()
    {
        //check if changes are saved
        string json = ""/*get json file */;
        DataSO self = JsonUtility.FromJson<DataSO>(json);
    }
    [Button(Spacing = ButtonSpacing.Before)]
    public void SaveToJSON()
    {
        
    }
    [Button(Spacing = ButtonSpacing.Before)]
    public void CreateJSONFile()
    {
        string json = JsonUtility.ToJson(this);
        File.WriteAllText($"{Application.dataPath}/{this.GetType().Name}_{JSONFileName}.json", json);
        Debug.Log($"{Application.dataPath}/{this.GetType().Name}_{JSONFileName}.json");
        Debug.Log(json);
    }

    [Header("Current File Data")]
    public string JSONFileName;
}
