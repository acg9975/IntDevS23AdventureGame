using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerItemDrop : MonoBehaviour
{
    // Start is called before the first frame update
    BoxCollider2D bx;
    [SerializeField]
    GameObject objectToRelease;

    private void Start()
    {
        bx = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            objectToRelease.SetActive(true);
        }
    }
}
