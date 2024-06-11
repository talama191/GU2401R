using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class IEnumerableExample : MonoBehaviour
{
    void Demo()
    {
        string[] listArray = new string[10];
        List<string> listStr = new List<string>();

        Queue<string> queue = new Queue<string>();
        Stack<string> stack = new Stack<string>();

        queue.Enqueue("a");
        queue.Enqueue("b");
        queue.Enqueue("C");
        string test = queue.Dequeue();//a
        stack.Push("a");
        stack.Push("c");
        stack.Push("b");
        string test2 = stack.Pop();//b
        //Dictionary
    }
}
