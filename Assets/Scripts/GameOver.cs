using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private SceneController manager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneController.LastGameScene = SceneManager.GetActiveScene().buildIndex;
        manager = GameObject.FindAnyObjectByType<SceneController>();
        manager.toScene("Lose");
    }
}