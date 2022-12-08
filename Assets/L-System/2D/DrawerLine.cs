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
 
   
    
    private PointCreator pointCreator;
   
    public void SetPosition(float y, float x)
    {
        Position = new Vector2(x, y);
    }
    public void DrawLine(float angle,float width, float endWidth, float lenghtLine, Material material)
    {
       pointCreator = new PointCreator(Position.x, Position.y);
       Vector2 endLine =  pointCreator.CreatePoint(angle, lenghtLine);
        
       CreateLine(endLine, width, endWidth, material);
       Position = endLine;
    
       


    }
    private LineRenderer CreateLine(Vector2 endLine, float width, float endWidth, Material material)
    {
        LineRenderer newLine = Instantiate(_linePrefab).GetComponent<LineRenderer>();
        
        newLine.transform.parent = this.transform;
        newLine.material = material;
        newLine.startWidth = width;
        newLine.endWidth = endWidth;
        newLine.positionCount = 2;
        newLine.SetPosition(0, Position);
        newLine.SetPosition(1, endLine);
        return newLine;
    }

   
}
