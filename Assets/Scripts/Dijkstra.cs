using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Dijkstra
{
    public void FindShortestPath(List<Edge> edges, Vertex start, Vertex end)
    {
        var currentVertex = start;
        currentVertex.WeightSum = 0;
        CheckNext(edges, currentVertex);
        HighlightPath(edges, start, end);
    }

    private void HighlightPath(List<Edge> edges, Vertex start, Vertex end)
    {
        while (end != start)
        {
            var edge = edges.Find(edge => edge.EndVertex == end && edge.StartVertex == edge.EndVertex.PreviousVertex);
            end = edge.StartVertex;
            edge.SetColor(Color.red);
        }
    }

    private void CheckNext(List<Edge> edges, Vertex currentVertex)
    {
        var suitableEdges = edges.Where(edge => edge.StartVertex == currentVertex).ToList();
        if (suitableEdges.Count != 0)
        {
            suitableEdges.ForEach(edge =>
            {
                SetWeight(edge, currentVertex);
                CheckNext(edges, edge.EndVertex);
            });
        }
    }

    private void SetWeight(Edge edge, Vertex currentVertex)
    {
        if (edge.EndVertex.WeightSum > currentVertex.WeightSum + edge.Weight || edge.EndVertex.WeightSum == 0)
        {
            edge.EndVertex.WeightSum = currentVertex.WeightSum + edge.Weight;
            edge.EndVertex.PreviousVertex = currentVertex;
        }
    }
}
