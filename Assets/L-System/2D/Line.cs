using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))]
public class Line : MonoBehaviour
{
    private LineRenderer _lineRenderer;


    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }


    public void SetPoints(List<Vector3> points)
    {
        _lineRenderer.SetPositions(points.ToArray());
    }
}
