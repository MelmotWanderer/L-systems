using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class PointCreator
{
   

    public Vector2 Position { get; set; }

    public PointCreator(float x, float y)
    {
        Position = new Vector2(x, y);
    }

    public void SetPosition(int y, int x)
    {
        Position = new Vector2(x, y);
    }
    public Vector2 CreatePoint(float angle, float lenghtLine, int direction)
    {
        float currentX = Position.x;
        float currentY = Position.y;


        Position = new Vector2(currentX + Mathf.Cos(angle * Mathf.Deg2Rad) * lenghtLine, currentY + Mathf.Sin(angle *Mathf.Deg2Rad) * lenghtLine);
   
        return Position;
    }
}
