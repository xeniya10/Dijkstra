using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Vertex : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _pointNumberText;
    
    private int _number;
    private Vector2 _position;

    public int WeightSum;
    public Vertex PreviousVertex;

    public int Number { get { return _number; } set { SetNumber(value); } }
    public Vector2 Position { get { return _position;} set {SetPosition(value);} }

    public void Create(int number, Vector2 position, Transform parent, List<Vertex> list)
    {
        var vertex = Instantiate(this, parent);
        vertex.Number = number;
        vertex.Position = position;
        list.Add(vertex);
    }

    private void SetNumber(int number)
    {
        _number = number;
        _pointNumberText.text = _number.ToString();
    }

    private void SetPosition(Vector2 position)
    {
        _position = position;
        transform.localPosition = _position;
    }
}
