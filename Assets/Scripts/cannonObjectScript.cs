using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cannonObjectScript : MonoBehaviour
{
    //when this object hits the player, enable the cannon script and destroy self
    BoxCollider2D bc;
    [SerializeField]
    GameObject cannon;
    [SerializeField]
    GameObject boundary;
    GameManager gm;
    [SerializeField]
    CinemachineVirtualCamera vc;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        bc = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cannon.SetActive(true);
            boundary.SetActive(false);
            gm.mainCamFollow(vc);
            Destroy(gameObject);

        }
    }
}
