using UnityEngine;

public class RootController : MonoBehaviour
{
    [HideInInspector] public int ToolbarInt;
    [HideInInspector] public bool Loop;
    [HideInInspector] public bool PingPong;
    [HideInInspector] public bool Oneway;

    private void OnValidate()
    {
        
    }

    public void ValidateEditor()
    {
        OnValidate();
    }
}
