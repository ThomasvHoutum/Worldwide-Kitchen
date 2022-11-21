using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad()]
public class PointGyzmoDrawer : MonoBehaviour
{
   [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected | GizmoType.Pickable)]
   public static void OnDrawSceneGizmo(Point point, GizmoType gizmoType)
   {
        if ((gizmoType & GizmoType.Selected) != 0)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.red * 0.5f;
        }

        Gizmos.DrawSphere(point.transform.position, 0.1f);

        if (point.PreviousPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(point.transform.position, point.PreviousPoint.transform.position);
        }
        if (point.NextPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(point.transform.position, point.NextPoint.transform.position);

            Vector2 posOnLine = Vector2.Lerp(point.transform.position, point.NextPoint.transform.position, 0.1f);
            Vector2 from = new Vector2(posOnLine.x - 0.1f, posOnLine.y);
            Vector2 to = new Vector2(posOnLine.x + 0.1f, posOnLine.y);

            float thickness = 5;
            Handles.DrawBezier(from, to, from, to, Color.blue, null, thickness);
        }
    }
}