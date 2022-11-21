using UnityEngine;
using UnityEngine.Events;

public class PointEventSystem : MonoBehaviour
{
    [Header("Events when point reached")]
    public UnityEvent OneWayEnd;
    public UnityEvent PingPongEnd;
    public UnityEvent LoopLapped;

    [Header("Events when action is done")]
    public UnityEvent OnStartMove;
    public UnityEvent OnStopMove;
    public UnityEvent OnResetPath;

    public bool GoOnAwake = true;

    public void SetEvents(UnityEvent _event1, UnityEvent _event2, UnityEvent _event3)
    {
        OneWayEnd = _event1;
        PingPongEnd = _event2;
        LoopLapped = _event3;
    }

    public void Loop(){ LoopLapped.Invoke(); }
    public void PingPong(){ PingPongEnd.Invoke(); }
    public void Oneway(){ OneWayEnd.Invoke(); }
    public void StartMove(){ OnStartMove.Invoke(); }
    public void StopMove(){ OnStopMove.Invoke(); }
    public void ResetPath() { OnResetPath.Invoke(); }
}
