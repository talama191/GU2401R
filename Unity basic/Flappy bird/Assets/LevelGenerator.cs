using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float GroundSpacing = 6.7f;

    public static LevelGenerator Instance { get; private set; }

    [Header("Obstacle config")]
    [SerializeField] private List<GameObject> obstaclePrefab;
    [SerializeField] private float initialSpawnDistance;
    [SerializeField] private float minObstacleDistance;
    [SerializeField] private float maxObstacleDistance;
    [SerializeField] private float minObstacleY;
    [SerializeField] private float maxObstacleY;
    [Header("Misc")]
    [SerializeField] private List<Transform> grounds;

    private float nextObstacleDistance;

    private Queue<Transform> groundQueue = new Queue<Transform>();
    private float nextGroundPosition = 0;
    private List<GameObject> obstacles = new List<GameObject>();

    [HideInInspector] public float ObstacleSpawnTimer = 0;
    [HideInInspector] public float ShiftDistance = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
        for (int i = 0; i < grounds.Count; i++)
        {
            Transform t = grounds[i];
            groundQueue.Enqueue(t);
        }
        nextGroundPosition = grounds[grounds.Count - 1].position.x + GroundSpacing;

        nextObstacleDistance = initialSpawnDistance;
        ObstacleSpawnTimer = initialSpawnDistance;
    }

    private void Update()
    {
        ShiftGround();
        ObstacleSpawning();
    }

    public void ObstacleSpawning()
    {
        if (ObstacleSpawnTimer > nextObstacleDistance)
        {
            float x = nextObstacleDistance;
            float y = Random.Range(minObstacleY, maxObstacleY);
            GameObject newObstacle = obstacles.FirstOrDefault(o => !o.activeInHierarchy);
            if (newObstacle == null)
            {
                int randomIndex = Random.Range(0, obstacles.Count);
                newObstacle = Instantiate(obstaclePrefab[randomIndex]);
                obstacles.Add(newObstacle);
            }
            newObstacle.SetActive(true);
            newObstacle.transform.position = new Vector3(x, y, 0);
            nextObstacleDistance += Random.Range(minObstacleDistance, maxObstacleDistance);
        }
    }

    public void ShiftGround()
    {
        if (ShiftDistance > GroundSpacing)
        {
            ShiftDistance = ShiftDistance - GroundSpacing;
            Transform ground = groundQueue.Dequeue();
            ground.position = new Vector3(nextGroundPosition, ground.position.y);
            nextGroundPosition += GroundSpacing;
            groundQueue.Enqueue(ground);
        }
    }
}
