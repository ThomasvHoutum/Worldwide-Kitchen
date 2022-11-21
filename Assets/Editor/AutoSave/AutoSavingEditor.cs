using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad()]
[ExecuteInEditMode]

public class AutoSavingEditor : MonoBehaviour
{
    private static bool _initialized;
    static AutoSavingEditor()
    {
        if (!_initialized)
            Init();
    }
    private static void Init()
    {
        _initialized = true;
        EditorApplication.update += HandleSaveTime;
    }
    private static bool _enableAutoSave = true;

    private static float _saveInterval = 60;
    private static float _saveIntervalTemp;
    private static double _lastSaveTime;
    public static void UpdateSettings(bool enable, float interval)
    {
        _enableAutoSave = enable;
        _saveInterval = interval;
    }

    private static void HandleSaveTime()
    {
        if (EditorApplication.isPlayingOrWillChangePlaymode) return;
        if (EditorApplication.isPlaying) return;

        if (!_enableAutoSave) return;
        if (EditorApplication.timeSinceStartup - _lastSaveTime > (_saveInterval)) StartSave();
    }

    public static void StartSave()
    {
        EditorSceneManager.SaveOpenScenes();
        AssetDatabase.SaveAssets();
        _lastSaveTime = EditorApplication.timeSinceStartup;
    }
}
