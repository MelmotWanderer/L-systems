using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class Lsystem : MonoBehaviour
{
    
    [SerializeField] private string _axiom = "0";
    [SerializeField] private int _iteration;
    [SerializeField] private int _angle;
    [SerializeField] private int lenght;

    [SerializeField] private int lenghtLeaf;

    private string axmTemp;
    private int _currentAngle = 90;
    private int nnEw = 90;
    private Stack<int> _stack;
    public Texture2D Create(Texture2D texture, Drawer drawer)
    {
        _stack = new Stack<int>();
      
        Dictionary<char, string> translate = new Dictionary<char, string>()
        {
            {'1', "11" },
            {'0',"1[-0]+0" }
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
                int newAngle = 0;

                if (_currentAngle - _angle == 90) newAngle = 90;
                else if (_currentAngle - _angle == 270 || _currentAngle - _angle == -90) { newAngle = 270; }
                else if (_currentAngle - _angle == 0) newAngle = 0;
                else newAngle = Mathf.RoundToInt(Mathf.Atan(Mathf.Tan((_currentAngle - _angle) * Mathf.Deg2Rad)) * Mathf.Rad2Deg);

                _currentAngle = _currentAngle - _angle;
                nnEw = newAngle;
                //  Debug.Log(nnEw + " " + _currentAngle);
            }
            else if (_axiom[i] == '-')
            {

                int newAngle = 0;

                if (_angle + _currentAngle == 90) newAngle = 90;
                else if (_currentAngle + _angle == 270 || _currentAngle + _angle == -90) newAngle = 270;
                else if (_angle + _currentAngle == 0) newAngle = 0;
                else newAngle = Mathf.RoundToInt(Mathf.Atan(Mathf.Tan((_angle + _currentAngle) * Mathf.Deg2Rad)) * Mathf.Rad2Deg);


                _currentAngle = _angle + _currentAngle;
                nnEw = newAngle;
                // Debug.Log(nnEw + " " + _currentAngle);
            }

            else if (_axiom[i] == '1')
            {
                int direction = 1;
                if (Mathf.Abs(_currentAngle) > 90 && Mathf.Abs(_currentAngle) < 270)
                {
                    direction = -1;
                }
                Debug.Log(drawer.position + " " + _currentAngle + " " + nnEw);
                texture = drawer.DrawLine(nnEw, direction, lenght, texture, Color.red);

            }
            else if (_axiom[i] == '0')
            {
                Debug.Log(drawer.position + " " + _currentAngle + " " + nnEw);

                int direction = 1;
                if (Mathf.Abs(_currentAngle) > 90 && Mathf.Abs(_currentAngle) < 270)
                {
                    direction = -1;
                }
                texture = drawer.DrawLine(nnEw, direction, lenghtLeaf, texture, Color.green);
            }
            else if (_axiom[i] == '[')
            {
                //  Debug.Log((int)drawer.position.x + " " + (int)drawer.position.y);
                _stack.Push((int)drawer.position.x);
                _stack.Push((int)drawer.position.y);
                _stack.Push(nnEw);
                _stack.Push(_currentAngle);
            }
            else if (_axiom[i] == ']')
            {
                // Debug.Log(_stack.ToArray()[0] + " " + _stack.ToArray()[2] + " " + _stack.ToArray()[1]);
                _currentAngle = _stack.Pop();
                nnEw = _stack.Pop();
                drawer.SetPosition(_stack.Pop(), _stack.Pop());

                // Debug.Log((int)drawer.position.x + " " + (int)drawer.position.y);

            }


        }
        return texture;
    }
}
