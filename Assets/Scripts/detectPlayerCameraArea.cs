using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectPlayerCameraArea : MonoBehaviour
{
    GameManager gm;
    BoxCollider2D bc;
    [SerializeField]
    moveablePlatScript mps;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        bc = gameObject.GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            mps.changeCanMove(true);
            gm.endingCameraChange();
        }
    }

}
