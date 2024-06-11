using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "level_", menuName = "Data/Level Data")]
public class LevelData : ScriptableObject
{
    [SerializeField] private List<NodeData> nodes;
    [SerializeField] private NodeData start;
    [SerializeField] private NodeData end;

    public List<NodeData> Nodes => nodes;
    public NodeData Start => start;
    public NodeData End => end;
}

[System.Serializable]
public class NodeData
{
    [SerializeField] private int x;
    [SerializeField] private int z;

    public int X => x;
    public int Z => z;
}
