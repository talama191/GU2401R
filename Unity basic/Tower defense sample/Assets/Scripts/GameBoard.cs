using System;
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
    public Action<Node> OnGameBoardChanged;

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
    }

    private void GenerateBoard()
    {
        nodes = new List<Node>();
        foreach (NodeData nodeData in levelData.Nodes)
        {
            Node newNode = Instantiate(nodeData.Prefab);
            newNode.Setup(nodeData);
            newNode.transform.position = new Vector3(nodeData.X, -0.6f, nodeData.Z);
            nodes.Add(newNode);
        }
        startNode = GetNode(levelData.Start.X, levelData.Start.Z);
        endNode = GetNode(levelData.End.X, levelData.End.Z);

        foreach (Node node in nodes)
        {
            CalculateNeighbor(node);
        }
        if (!ValidateLevel()) Debug.LogError("Level validate failed");
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

    public Queue<Node> SearchFromStartToEnd()
    {
        return SearchPath(startNode, endNode);
    }

    public Queue<Node> SearchPath(Node start, Node end)
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
                Queue<Node> path = new Queue<Node>();
                while (current != start)
                {
                    path.Enqueue(current);
                    current = cameFrom[current];
                }
                path.Enqueue(start);
                Node[] reversePath = path.Reverse().ToArray();
                path.Clear();
                foreach (Node node in reversePath)
                {
                    path.Enqueue(node);
                }
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

    public bool RemoveNode(Node node)
    {
        nodes.Remove(node);
        foreach (Node neighbor in node.NeighborNodes)
        {
            CalculateNeighbor(neighbor);
        }
        if (!ValidateLevel())
        {
            nodes.Add(node);
            foreach (Node neighbor in node.NeighborNodes)
            {
                CalculateNeighbor(neighbor);
            }
            return false;
        }
        else
        {
            foreach (Node neighbor in node.NeighborNodes)
            {
                CalculateNeighbor(neighbor);
            }
            OnGameBoardChanged?.Invoke(node);
            return true;
        }
    }

    private bool ValidateLevel()
    {
        Queue<Node> path = SearchPath(startNode, endNode);
        return path != null;
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
            //Queue<Node> path = SearchPath(node1, node2);
            //for (int i = 1; i < path.Count; i++)
            //{
            //    Node currentNode = path[i];
            //    Node previousNode = path[i - 1];
            //    Gizmos.DrawLine(currentNode.Position, previousNode.Position);
            //}
        }
    }

    [ContextMenu("delete node (4,-1)")]
    public void RemoveNode1()
    {
        RemoveNode(GetNode(4, -1));
    }

    [ContextMenu("delete node (3,-2)")]
    public void RemoveNode2()
    {
        RemoveNode(GetNode(3, -2));
    }
}
