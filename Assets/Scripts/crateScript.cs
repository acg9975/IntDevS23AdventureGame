using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crateScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CollisionArea"))
        {
            other.GetComponent<areadetection>().addBoxtoArea();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("CollisionArea"))
        {
            other.GetComponent<areadetection>().removeBoxtoArea();
        }
    }
}
