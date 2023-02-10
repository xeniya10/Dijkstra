using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Edge : MonoBehaviour
{
    public LineRenderer LineRenderer;
    
    [SerializeField] private TextMeshProUGUI _weightText;
    [SerializeField] private int _minEdgeWeight = 1;
    [SerializeField] private int _maxEdgeWeight = 20;
    
    [NonSerialized] public int Weight;
    [NonSerialized] public Vertex StartVertex;
    [NonSerialized] public Vertex EndVertex;

    private void Awake()
    {
        SetColor(Color.black);
        LineRenderer.startWidth = LineRenderer.endWidth = 0.02f;
        LineRenderer.positionCount = 2;
    }

    public void Create(Vertex startVertex, Vertex endVertex, Vector3 position, Transform parent, List<Edge> list)
    {
        var edge = Instantiate(this, parent);
        edge.SetRandomWeight();
        
        edge.StartVertex = startVertex;
        edge.EndVertex = endVertex;
        
        edge.LineRenderer.SetPosition(0, new Vector3(startVertex.transform.position.x, startVertex.transform.position.y, 0));
        edge.LineRenderer.SetPosition(1, new Vector3(endVertex.transform.position.x, endVertex.transform.position.y, 0));
        
        edge.SetWeightTextPosition(position);
        list.Add(edge);
    }

    public void Reset()
    {
        SetColor(Color.black);
        SetRandomWeight();
    }

    private void SetWeightTextPosition(Vector3 position)
    {
        _weightText.transform.localPosition = position;
    }

    private void SetRandomWeight()
    {
        Weight = Random.Range(_minEdgeWeight, _maxEdgeWeight + 1);
        _weightText.text = Weight.ToString();
    }

    public void SetColor(Color color)
    {
        LineRenderer.startColor = LineRenderer.endColor = color;
    }
}
