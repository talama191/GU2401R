using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoSingleton<ResourceManager>
{
    [SerializeField] List<TowerData> towerDatas;

    public List<TowerData> TowerDatas => towerDatas;
}

