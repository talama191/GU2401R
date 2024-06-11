using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseController : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Weapon")
        {
            Weapon weapon = collision.GetComponent<Weapon>();
            if (Input.GetKeyDown(weapon.keyCode))
            {
                Destroy(weapon.gameObject);
            }
        }
    }
}
