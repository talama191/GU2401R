using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "level_", menuName = "Data/Level Data")]
public class LevelData : ScriptableObject
{
    [Header("Board")]
    [SerializeField] private List<NodeData> nodes;
    [SerializeField] private NodeData start;
    [SerializeField] private NodeData end;
    [Header("WaveConfig")]
    [SerializeField] WaveData[] waves;

    public List<NodeData> Nodes => nodes;
    public NodeData Start => start;
    public NodeData End => end;
    public WaveData[] Waves => waves;
}

[System.Serializable]
public class NodeData
{
    [SerializeField] private int x;
    [SerializeField] private int z;

    public int X => x;
    public int Z => z;
}
