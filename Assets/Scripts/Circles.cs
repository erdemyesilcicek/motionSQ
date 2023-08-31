using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circles : MonoBehaviour
{
    public SceneController controller;
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}