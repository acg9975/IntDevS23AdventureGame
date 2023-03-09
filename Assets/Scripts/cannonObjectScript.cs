using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonObjectScript : MonoBehaviour
{
    //when this object hits the player, enable the cannon script and destroy self
    BoxCollider2D bc;
    [SerializeField]
    GameObject cannon;
    private void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cannon.SetActive(true);
            Destroy(gameObject);
        }
    }
}
