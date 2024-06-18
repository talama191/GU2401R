﻿
using System.Collections.Generic;
using UnityEngine;
public class BasicEnemy : MonoBehaviour
{
    private float currentHp;
    private float movementSpeed;

    private EnemyData enemyData;
    private Queue<Node> currentPath;
    private Node prevNode;
    private bool hasSetup = false;

    private void OnEnable()
    {
        GameBoard.Instance.OnGameBoardChanged += OnGameBoardChange;
    }

    private void OnDestroy()
    {
        GameBoard.Instance.OnGameBoardChanged -= OnGameBoardChange;
    }

    public void Setup(EnemyData enemyData)
    {
        this.enemyData = enemyData;
        movementSpeed = enemyData.MovementSpeed;
        currentHp = enemyData.MaxHp;
        currentPath = GameBoard.Instance.SearchFromStartToEnd();
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
            if (distance <= 0.01f)
            {
                prevNode = currentPath.Dequeue();
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

    public void OnGameBoardChange(Node node)
    {
        if (!currentPath.Contains(node)) return;
        if (prevNode != null)
        {
            if (currentPath.Peek() == node)
            {
                currentPath = GameBoard.Instance.SearchPath(prevNode, GameBoard.Instance.EndNode);
            }
            else
            {
                currentPath = GameBoard.Instance.SearchPath(currentPath.Peek(), GameBoard.Instance.EndNode);
            }
        }
        else
        {
            currentPath = GameBoard.Instance.SearchFromStartToEnd();
        }
    }
}