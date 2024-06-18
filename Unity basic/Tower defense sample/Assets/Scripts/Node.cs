
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private NodeData data;
    private Vector3 position;

    public List<Node> NeighborNodes { get; private set; }
    public NodeData NodeData => data;
    public Vector3 Position => position;
    public float X => data.X;
    public float Z => data.Z;

    public void Setup(NodeData node)
    {
        data = node;
        position = new Vector3(data.X, 0, data.Z);
        NeighborNodes = new List<Node>();
    }
}


[System.Serializable]
public class NodeData
{
    [SerializeField] private int x;
    [SerializeField] private int z;
    [SerializeField] private Node prefab;

    public int X => x;
    public int Z => z;
    public Node Prefab => prefab;
}