
using System.Collections.Generic;
using UnityEngine;
public class BasicEnemy : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    private Queue<Node> currentPath;
    private bool hasSetup = false;

    public void Setup()
    {
        List<Node> path = GameBoard.Instance.SearchFromStartToEnd();
        currentPath = new Queue<Node>();
        foreach (Node node in path)
        {
            currentPath.Enqueue(node);
        }
        hasSetup = true;
    }

    private void Update()
    {
        //di chuyển đến ô ở trên cùng của Queue
        //khi sát ô đang di chuyển tới thì chuyển sang ô tiếp theo trong Queue, và dequeue ô hiện tại
        //khi queue trống thì kẻ địch chết

        if (hasSetup)
        {
            Node nextNode = currentPath.Peek();
            float distance = MoveTo(nextNode);
            if (distance <= 0.1f)
            {
                currentPath.Dequeue();
            }
            if (currentPath.Count == 0)
            {
                //tru diem ng choi hay gi do
                Destroy(gameObject);
            }
        }
    }

    private float MoveTo(Node node)
    {
        Vector3 directionVector = node.Position - new Vector3(transform.position.x, 0, transform.position.z);
        transform.position += directionVector.normalized * movementSpeed * Time.deltaTime;
        return directionVector.magnitude;
    }

}
