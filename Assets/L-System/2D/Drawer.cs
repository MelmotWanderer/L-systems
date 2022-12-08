using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Drawer 
{
    public Vector2 position { get; set;  }
    public Drawer(Vector2 to)
    {
        position = to;
     
    }
    public void SetPosition(int y, int x)
    {
        position = new Vector2(x, y);
    }
  

    public Texture2D DrawLine(int angle, int direction ,int lenghtLine, Texture2D texture, Color color)
    {
        int currentX = (int)position.x;
        int currentY = (int)position.y;
        //Debug.Log(angle);
        switch (angle)
        {
            
            case 90:
                for (int i = 0; i < lenghtLine; i++)
                {

                    texture.SetPixel(currentX, i + currentY, color);
                    position = new Vector2(currentX, i + currentY);
                }
                break;
            case 270:

                 for (int i = 0; i < lenghtLine; i++)
                {

                  
                    position = new Vector2(currentX, currentY -  i );
                }
                break;
            case 0:
                for (int i = 0; i < lenghtLine; i++)
                {

                 
                    position = new Vector2(currentX + direction * i, currentY);
                }
                break;

            
            default:
                for (int x = Mathf.Abs(currentX + (int)(lenghtLine * Mathf.Clamp(direction, -1, 0))); x <= currentX + (lenghtLine * Mathf.Clamp01(direction)); x++)
                {
                   
                    int y = Mathf.RoundToInt(Mathf.Tan(Mathf.Deg2Rad * angle)) * (x - currentX);
             
                   
                    if (angle > 0 && angle < 90)
                    {
                        if(direction == 1) position = new Vector2(x, y + currentY);
                        if (direction == -1) position = new Vector2(currentX - lenghtLine, Mathf.Abs(currentY - lenghtLine));

                    }
                 
                    else
                    {
                        if(direction == -1)
                        position = new Vector2(currentX - lenghtLine, currentY + lenghtLine);
                        if(direction == 1)
                        position = new Vector2(x, y + currentY);
                    }

                }
                break;

        }
       
        return texture;
    }
}
