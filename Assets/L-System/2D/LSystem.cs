using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class LSystem : MonoBehaviour
{
    [SerializeField] private float _lenghtLine;
    [SerializeField] private float _lenghtLeaf;
    [SerializeField] private float _widthLine;
    [SerializeField] private float _widthLeaf;
    [SerializeField] private string _axiom = "0";
    [SerializeField] private int _iteration;
    [SerializeField] private int _angle;
    [SerializeField] private DrawerLine _drawerLine;
    [SerializeField] private Material stebelMaterial;
    [SerializeField] private Material leafMaterial;

    private string axmTemp;
    private float _currentAngle = 90;
    
    private Stack<float> _stack;

    private List<Vector3> _pointsTree;
    private void Start()
    {
        Create();
    }
    public List<Vector3> Create()
    {
        _drawerLine.SetPosition(transform.position.y, transform.position.x);
        _pointsTree = new List<Vector3>();
        _stack = new Stack<float>();

        //Dictionary<char, string> translate = new Dictionary<char, string>()
        //{
        //    {'1', "21" },
        //    {'0',"1[-20]+20" }
        //};
        //Dictionary<char, string> translate = new Dictionary<char, string>()
        //{
        //    {'1', "1-1+1+11-1-1+1" }

        //};

        //Dictionary<char, string> translate = new Dictionary<char, string>()
        //{
        //    {'1', "1+0-1-0+1" },
        //    {'0', "0+1-0-1+0" }


        //};
        //Dictionary<char, string> translate = new Dictionary<char, string>()
        //{
        //    {'X', "X+Y1+" },
        //    {'Y', "-0X-Y" }


        //};
        Dictionary<char, string> translate = new Dictionary<char, string>()
        {
            {'1', "1+0++0-1--11-0+" },
            {'0', "-1+00++0+1--1-0" }


        };
        for (int i = 0; i < _iteration; i++)
        {
            for (int j = 0; j < _axiom.Length; j++)
            {
                if (translate.ContainsKey(_axiom[j]))
                {
                    axmTemp += translate[_axiom[j]];
                }
                else
                {
                    axmTemp += _axiom[j];
                }
            }
            _axiom = axmTemp;
            axmTemp = "";
        }


        for (int i = 0; i < _axiom.Length; i++)
        {

            if (_axiom[i] == '+')
            {

                

                _currentAngle = CalculateNewAngle(-1);
              
            
            }
            else if (_axiom[i] == '-')
            {
               

                _currentAngle = CalculateNewAngle(1);
               
             
            }
            else if (_axiom[i] == '2')
            {
                if(Random.Range(0,10) > 7)
                {
                    int direction = 1;
                    if (Mathf.Abs(_currentAngle) > 90 && Mathf.Abs(_currentAngle) < 270)
                    {
                        direction = -1;
                    }


                    _drawerLine.DrawLine(_currentAngle, _widthLine, _lenghtLine, direction, stebelMaterial);

                }

            }
            else if (_axiom[i] == '1')
            {
                int direction = 1;
                if (Mathf.Abs(_currentAngle) > 90 && Mathf.Abs(_currentAngle) < 270)
                {
                    direction = -1;
                }

             
                _drawerLine.DrawLine(_currentAngle, _widthLine, _lenghtLine, direction, stebelMaterial);
                
            }
            else if (_axiom[i] == '0')
            {
               

                int direction = 1;
                if (Mathf.Abs(_currentAngle) > 90 && Mathf.Abs(_currentAngle) < 270)
                {
                    direction = -1;
                }

                _drawerLine.DrawLine(_currentAngle, _widthLeaf, _lenghtLeaf, direction, leafMaterial) ;
            }
            else if (_axiom[i] == '[')
            {
                _widthLine = _widthLine * 0.75f;
                _stack.Push(_drawerLine.Position.x);
                _stack.Push(_drawerLine.Position.y);
              
                _stack.Push(_currentAngle);
                _stack.Push(_widthLine);
            }
            else if (_axiom[i] == ']')
            {
                _widthLine = _stack.Pop();
                _currentAngle = _stack.Pop();
               
                _drawerLine.SetPosition(_stack.Pop(), _stack.Pop());

               

            }


        }
        return _pointsTree;
    
}
    private float CalculateNewAngle(int direction)
    {
       int koefRand = 0;
       
        int newAngle = Mathf.RoundToInt((_currentAngle + direction * _angle) - koefRand);
        return newAngle;
    }
}
