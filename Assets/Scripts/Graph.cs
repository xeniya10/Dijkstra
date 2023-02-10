using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class Graph : MonoBehaviour
{
    [SerializeField] private Vertex _vertex;
    [SerializeField] private Edge _edge;
    [SerializeField] private Transform _edgeParent;
    
    [SerializeField] private int _startPoint;
    [SerializeField] private int _endPoint;
    
    private Dijkstra _dijkstra;
    private List<Vertex> _vertexes = new List<Vertex>();
    private List<Edge> _edges = new List<Edge>();

    private void Start()
    {
        _dijkstra = new Dijkstra();
        CreatePoints();
        DrawEdges();
        FindPath();
    }

    private void CreatePoints()
    {
        _vertex.Create(1, new Vector2(-340, 250), transform, _vertexes);
        _vertex.Create(2, new Vector2(-150, 0), transform, _vertexes);
        _vertex.Create(3, new Vector2(100, 250), transform, _vertexes);
        _vertex.Create(4, new Vector2(120, 0), transform, _vertexes);
        _vertex.Create(5, new Vector2(350, 0), transform, _vertexes);
        _vertex.Create(6, new Vector2(140, -250), transform, _vertexes);
    }

    private void DrawEdges()
    {
        _edge.Create(_vertexes[0], _vertexes[1], new Vector3(-220,170,0), _edgeParent, _edges);
        _edge.Create(_vertexes[1], _vertexes[2], new Vector3(-60,170,0), _edgeParent, _edges);
        _edge.Create(_vertexes[1], _vertexes[3], new Vector3(0,25,0), _edgeParent, _edges);
        _edge.Create(_vertexes[1], _vertexes[5], new Vector3(-40,-150,0), _edgeParent, _edges);
        _edge.Create(_vertexes[2], _vertexes[3], new Vector3(70, 120, 0), _edgeParent, _edges);
        _edge.Create(_vertexes[2], _vertexes[4], new Vector3(250, 160, 0), _edgeParent, _edges);
        _edge.Create(_vertexes[3], _vertexes[4], new Vector3(220, 30, 0), _edgeParent, _edges);
        _edge.Create(_vertexes[3], _vertexes[5], new Vector3(170, -100, 0), _edgeParent, _edges);
        _edge.Create(_vertexes[4], _vertexes[5], new Vector3(280, -150,0), _edgeParent, _edges);
    }

    private void FindPath()
    {
        _dijkstra.FindShortestPath(_edges, _vertexes[_startPoint-1], _vertexes[_endPoint-1]);
    }
    
    public void ResetGraph()
    {
        _vertexes.ForEach(vertex => vertex.WeightSum = 0);
        ResetEdges();
        FindPath();
    }

    private void ResetEdges()
    {
        foreach (var edge in _edges)
        {
            edge.Reset();
        }
    }
}
