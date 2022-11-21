using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class AutoSavingWindow : EditorWindow
{
    private bool _initialized;

    [MenuItem("Tools/Auto Save System")]
    public static void Open()
    {
        GetWindow<AutoSavingWindow>("Auto Save Settings");
    }
    #region Rename Attribute
    public class RenameAttribute : PropertyAttribute
    {
        public string NewName { get; private set; }
        public RenameAttribute(string name)
        {
            NewName = name;
        }
    }
    [CustomPropertyDrawer(typeof(RenameAttribute))]
    public class RenameEditor : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.PropertyField(position, property, new GUIContent((attribute as RenameAttribute).NewName));
        }
    }
    #endregion

    private void Init()
    {
        _initialized = true;
        GUIStyles();
    }

    #region GUIStyles
    GUIStyle _headerStyle = new GUIStyle();
    GUIStyle _followerStyle = new GUIStyle();
    GUIStyle _warningStyle = new GUIStyle();
    private void GUIStyles()
    {
        // Header text
        _headerStyle.margin = new RectOffset(3, 0, 0, 0);
        _headerStyle.fontStyle = FontStyle.Bold;
        _headerStyle.fontSize = 15;
        _headerStyle.normal.textColor = Color.white;

        // Follower text
        _followerStyle.margin = new RectOffset(3, 0, 0, 0);
        _followerStyle.fontStyle = FontStyle.Italic;
        _followerStyle.fontSize = 10;
        _followerStyle.normal.textColor = Color.white;

        // Warning text
        _warningStyle.margin = new RectOffset(3, 0, 0, 0);
        _warningStyle.fontStyle = FontStyle.Italic;
        _warningStyle.fontSize = 10;
        _warningStyle.normal.textColor = Color.red;
    }
    #endregion

    [Rename("Time Interval.")]
    [Range(1, 30)] public int _saveInterval = 5;

    [Rename("Auto Save")]
    public bool _enableAutoSave = true;
    private void OnGUI()
    {
        if (!_initialized)
            Init();

        EditorApplication.playModeStateChanged += LogPlayModeState;

        SerializedObject obj = new SerializedObject(this);

        GUILayout.Label("Auto Saving Settings", _headerStyle);

        GUILayout.Label("Enable/Disable Auto save feature.", _followerStyle);
        EditorGUILayout.PropertyField(obj.FindProperty("_enableAutoSave"));

        GUILayout.Label("Save time interval in minutes.", _followerStyle);
        EditorGUILayout.PropertyField(obj.FindProperty("_saveInterval"));

        if (GUILayout.Button("Apply settings"))
        {
            AutoSavingEditor.UpdateSettings(_enableAutoSave, _saveInterval * 60);
        }
        if (GUILayout.Button("Save now"))
        {
            AutoSavingEditor.StartSave();
        }

        obj.ApplyModifiedProperties();
    }

    private void LogPlayModeState(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.EnteredEditMode) AutoSavingEditor.UpdateSettings(_enableAutoSave, _saveInterval * 60);
    }
}
