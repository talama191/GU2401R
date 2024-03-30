
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField] PickupType pickupType;
    [SerializeField] float pickupValue;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //GameManager.Instance.AddScore(1);
            switch (pickupType)
            {
                case PickupType.HP:
                    PlayerController.Instance.HealPlayer(pickupValue);
                    break;
                case PickupType.MP:
                    //cong mana
                    break;
                case PickupType.Damage:
                    //cong damage
                    break;
            }

            Destroy(gameObject);
        }
    }
}

public enum PickupType
{
    HP, MP, Damage
}
