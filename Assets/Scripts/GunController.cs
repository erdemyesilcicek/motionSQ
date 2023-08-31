using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public SceneController SceneController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Circle"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            CircleController.LiveCircles--;
        }
        if (collision.gameObject.CompareTag("Block"))
        {
            Destroy(gameObject);
        }
        Debug.Log(CircleController.LiveCircles);
        if (CircleController.LiveCircles <= 0)
        {
            SceneController.NextScene();
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}