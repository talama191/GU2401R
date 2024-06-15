
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    private int x;
    private int z;
    private Vector3 position;

    public List<Node> NeighborNodes { get; private set; }

    public int X => x;
    public int Z => z;
    public Vector3 Position => position;

    public Node(int x, int z)
    {
        this.x = x;
        this.z = z;
        position = new Vector3(x, 0, z);
        NeighborNodes = new List<Node>();
    }
}
