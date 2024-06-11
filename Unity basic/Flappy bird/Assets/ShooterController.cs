using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ShooterController : MonoBehaviour
{
    private void Update()
    {
        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        if (hit.collider != null)
        {
            Vector3 playerToHit = hit.point - transform.position;
            playerToHit.y = 0;
            transform.rotation = Quaternion.LookRotation(playerToHit);
        }

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 moveVector = new Vector2(x, y);
        transform.Translate(moveVector);
    }

    public void OpenGameScene()
    {
        SceneManager.LoadScene(1);
    }
}
