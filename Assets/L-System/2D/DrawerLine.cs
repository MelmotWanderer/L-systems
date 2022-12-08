using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEditor.Rendering;
using UnityEngine;
[RequireComponent(typeof(LSystem))]
public class DrawerLine : MonoBehaviour
{
    public Vector2 Position { get; private set; }
    [SerializeField] private  Line _linePrefab;
    [SerializeField] private float radius;
   
    
    private PointCreator pointCreator;
   
    public void SetPosition(float y, float x)
    {
        Position = new Vector2(x, y);
    }
    public void DrawLine(float angle,float width, float lenghtLine, int direction, Material material)
    {
       pointCreator = new PointCreator(Position.x, Position.y);
       Vector2 endLine =  pointCreator.CreatePoint(angle, lenghtLine, direction);
        Debug.Log(angle);
       CreateLine(endLine, width, material);
       Position = endLine;
    
       


    }
    private LineRenderer CreateLine(Vector2 endLine, float width, Material material)
    {
        LineRenderer newLine = Instantiate(_linePrefab).GetComponent<LineRenderer>();
        
        newLine.transform.parent = this.transform;
        newLine.material = material;
        newLine.startWidth = width;
        newLine.positionCount = 2;
        newLine.SetPosition(0, Position);
        newLine.SetPosition(1, endLine);
        return newLine;
    }

   
}
