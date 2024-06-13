using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
public class GameBoard : MonoBehaviour
{
    public static GameBoard Instance;

    [SerializeField] private LevelData levelData;

    private List<Node> nodes;
    private Node endNode;
    private Node startNode;

    public Node EndNode => endNode;
    public Node StartNode => startNode;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        GenerateBoard();
        foreach (Node node in nodes)
        {
            CalculateNeighbor(node);
        }
    }

    private void GenerateBoard()
    {
        nodes = new List<Node>();
        foreach (NodeData nodeData in levelData.Nodes)
        {
            nodes.Add(new Node(nodeData.X, nodeData.Z));
        }
        endNode = GetNode(levelData.End.X, levelData.End.Z);
        startNode = GetNode(levelData.Start.X, levelData.Start.Z);

        if (!ValidateLevel()) Debug.LogError("Level validate failed");
    }

    private bool ValidateLevel()
    {
        List<Node> path = SearchPath(startNode, endNode);
        return path != null;
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

    public List<Node> SearchFromStartToEnd()
    {
        return SearchPath(startNode, endNode);
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
            NodeData start = levelData.Start;
            NodeData end = levelData.End;
            Handles.Label(node.Position, $"x:{node.X},z:{node.Z}", new GUIStyle() { fontSize = 24 });
            Node node1 = GetNode(start.X, start.Z);
            Node node2 = GetNode(end.X, end.Z);
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
