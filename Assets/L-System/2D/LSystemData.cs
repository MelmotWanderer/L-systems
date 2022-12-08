using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LSystemData", menuName = "ScriptableObjects/LSystemData", order = 1)]
public class LSystemData : ScriptableObject
{
    public string Axiom { get; private set; }
    public float Angle { get; private set; }

    public int Iteration { get; private set; }
    public Vector3 PositionDrawer { get; private set; }
    public float LenghtLine { get; private set; }
    public float LenghtLeaf { get; private set; }
    public float WidthLine { get; private set; }
    public float WidthLeaf { get; private set; }
    public float EndWidthLeaf { get; private set; }
    public Material StebelMaterial { get; private set; }
    public Material LeafMaterial { get; private set; }



    [SerializeField] private string _axiom;
    [SerializeField] private List<string> translateList;
    [SerializeField] private float _angle;
    [SerializeField] private int _iteration;
    [SerializeField] Vector3 _positionDrawer;

    [SerializeField] private float _lenghtLine;
    [SerializeField] private float _lenghtLeaf;
    [SerializeField] private float _widthLine;
    [SerializeField] private float _widthLeaf;
    [SerializeField] private float _endWidthLeaf;

    [SerializeField] private Material _stebelMaterial;
    [SerializeField] private Material _leafMaterial;

    private Dictionary<char, string> translate;

    public void Init()
    {
        
        Axiom = _axiom;
        Angle = _angle;
        Iteration = _iteration;
        PositionDrawer = _positionDrawer; 
        LenghtLine = _lenghtLine;
        LenghtLeaf = _lenghtLeaf;
        WidthLine = _widthLine;
        WidthLeaf = _widthLeaf;
        EndWidthLeaf = _endWidthLeaf;
        StebelMaterial = _stebelMaterial;
        LeafMaterial = _leafMaterial;

    }
    public Dictionary<char, string> TranslateToDictionary()
    {
        translate = new Dictionary<char, string>();
        foreach (string translateString in translateList)
        {
            char key = translateString[0];
            string rule = translateString.Remove(0, 2);
            translate.Add(translateString[0], rule);
        }
        return translate;
    }
    
    
}
