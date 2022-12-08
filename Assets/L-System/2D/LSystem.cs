using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class LSystem : MonoBehaviour
{
    [SerializeField] LSystemData _lsystemData;
    
    [SerializeField] private DrawerLine _drawerLine;

    
    private string axmTemp;
    private float _currentAngle = 90;
    
    private Stack<float> _stack;
  
    private void Start()
    {
        Create();
        
    }
    public void Create()
    {
      
        _stack = new Stack<float>();
        _lsystemData.Init();
        Dictionary<char, string> translate = _lsystemData.TranslateToDictionary();
        string axiom = _lsystemData.Axiom;
        float angle = _lsystemData.Angle;
        int iteration = _lsystemData.Iteration;
        Vector3 positionDrawer = _lsystemData.PositionDrawer;
        float lenghtLine = _lsystemData.LenghtLine;
        float widthLine = _lsystemData.WidthLine;
        float lenghtLeaf = _lsystemData.LenghtLeaf;
        float widthLeaf = _lsystemData.WidthLeaf;
        float endWidthLeaf = _lsystemData.EndWidthLeaf;
        Material lineMaterial = _lsystemData.StebelMaterial;
        Material leafMaterial = _lsystemData.LeafMaterial;
        
        _drawerLine.SetPosition(positionDrawer.y, positionDrawer.x);
        for (int i = 0; i < iteration; i++)
        {
            for (int j = 0; j < axiom.Length; j++)
            {
                if (translate.ContainsKey(axiom[j]))
                {
                    axmTemp += translate[axiom[j]];
                }
                else
                {
                    axmTemp += axiom[j];
                }
            }
            axiom = axmTemp;
            axmTemp = "";
        }


        for (int i = 0; i < axiom.Length; i++)
        {

            if (axiom[i] == '+')
            {

                

                _currentAngle = CalculateNewAngle(angle, - 1);
              
            
            }
            else if (axiom[i] == '-')
            {
               

                _currentAngle = CalculateNewAngle(angle, 1);
               
             
            }
            else if (axiom[i] == '2')
            {
                if(Random.Range(0,10) > 7)
                {
                

                    _drawerLine.DrawLine(_currentAngle, widthLine, widthLine, lenghtLine, lineMaterial);

                }

            }
            else if (axiom[i] == '1')
            {
            
             
                _drawerLine.DrawLine(_currentAngle, widthLine, widthLine, lenghtLine, lineMaterial);
                
            }
            else if (axiom[i] == '0')
            {
               

             

                _drawerLine.DrawLine(_currentAngle, widthLeaf, endWidthLeaf, lenghtLeaf, leafMaterial) ;
            }
            else if (axiom[i] == '[')
            {
                widthLine = widthLine * 0.75f;
                _stack.Push(_drawerLine.Position.x);
                _stack.Push(_drawerLine.Position.y);
              
                _stack.Push(_currentAngle);
                _stack.Push(widthLine);
            }
            else if (axiom[i] == ']')
            {
                widthLine = _stack.Pop();
                _currentAngle = _stack.Pop();
               
                _drawerLine.SetPosition(_stack.Pop(), _stack.Pop());

               

            }


        }

    
}
    private float CalculateNewAngle(float angle, int direction)
    {
        int koefRand = 0;
       
        int newAngle = Mathf.RoundToInt((_currentAngle + direction * angle) - koefRand);
        return newAngle;
    }
}
