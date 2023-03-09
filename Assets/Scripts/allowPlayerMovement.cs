using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allowPlayerMovement : MonoBehaviour
{
    [SerializeField]
    improvedController controller;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            controller.enabled = true;
        }
    }
}
