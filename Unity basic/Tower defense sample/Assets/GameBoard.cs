using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
public class GameBoard : MonoBehaviour
{
    private List<Node> nodes;

    private void Start()
    {
        GenerateBoard();
        foreach (Node node in nodes)
        {
            CalculateNeighbor(node);
        }
    }

    private void GenerateBoard()
    {
        nodes = new List<Node>()
        {
            new Node(0,-2),new Node(4,-2),
            new Node(1,-1),new Node(2,-1),
            new Node(1,-2)/*,new Node(2,-2)*/,new Node (3,-2),
            new Node(1,-3),new Node(2,-3),new Node (3,-3),
        };
    }

    private void CalculateNeighbor(Node node)
    {
        node.NeighborNodes.Clear();
        Node upNeighbor = nodes.Where(n1 => node.X == n1.X && node.Z == n1.Z - 1).FirstOrDefault();
        if (upNeighbor != null) node.NeighborNodes.Add(upNeighbor);
        Node rightNeighbor = nodes.Where(n1 => node.X == n1.X - 1 && node.Z == n1.Z).FirstOrDefault();
        if (rightNeighbor != null) node.NeighborNodes.Add(rightNeighbor);
        Node downNeightbor = nodes.Where(n1 => node.X == n1.X && node.Z == n1.Z + 1).FirstOrDefault();
        if (downNeightbor != null) node.NeighborNodes.Add(downNeightbor);
        Node leftNeightbor = nodes.Where(n1 => node.X == n1.X + 1 && node.Z == n1.Z).FirstOrDefault();
        if (leftNeightbor != null) node.NeighborNodes.Add(leftNeightbor);
    }

    public List<Node> SearchPath(Node start, Node end)
    {
        Queue<Node> queue = new Queue<Node>();
        Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();
        List<Node> visiteds = new List<Node>();

        queue.Enqueue(start);
        visiteds.Add(start);

        while (queue.Count > 0)
        {
            Node current = queue.Dequeue();
            if (current == end)
            {
                List<Node> path = new List<Node>();
                while (current != start)
                {
                    path.Add(current);
                    current = cameFrom[current];
                }
                path.Add(start);
                path.Reverse();
                return path;
            }

            foreach (Node neighbor in current.NeighborNodes)
            {
                if (!visiteds.Contains(neighbor))
                {
                    queue.Enqueue(neighbor);
                    visiteds.Add(neighbor);
                    cameFrom[neighbor] = current;
                }
            }
        }
        return null;
    }

    private Node GetNode(int x, int z)
    {
        return nodes.FirstOrDefault(n => n.X == x && n.Z == z);
    }

    private void OnDrawGizmos()
    {
        if (nodes == null) return;
        foreach (Node node in nodes)
        {
            Handles.Label(node.Position, $"x:{node.X},z:{node.Z}", new GUIStyle() { fontSize = 24 });
            Node node1 = GetNode(0, -2);
            Node node2 = GetNode(4, -2);
            List<Node> path = SearchPath(node1, node2);
            for (int i = 1; i < path.Count; i++)
            {
                Node currentNode = path[i];
                Node previousNode = path[i - 1];
                Gizmos.DrawLine(currentNode.Position, previousNode.Position);
            }
        }
    }
}
