using UnityEngine;
using UnityEngine.UIElements;

[ExecuteInEditMode] //Execute this script in editor 
public class GizmoBox : MonoBehaviour
{
    public Color boxColor = Color.cyan; //Change the color in the inspector

    void OnDrawGizmos()
    {
        Gizmos.color = boxColor; //Set the color of the next draw
        Gizmos.DrawCube(transform.position, transform.localScale); //Draw a cube gizmo and give it a position and a size
    }
}

