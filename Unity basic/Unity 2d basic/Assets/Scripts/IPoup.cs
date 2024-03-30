using UnityEngine;

public abstract class PopupBase : MonoBehaviour
{
    [SerializeField] private GameObject container;

    public void Open()
    {
        container.SetActive(true);
    }

    public void Close()
    {
        container.SetActive(false);
    }
}
