using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class detectPlayerCameraArea : MonoBehaviour
{
    GameManager gm;
    BoxCollider2D bc;
    [SerializeField]
    moveablePlatScript mps;
    [SerializeField]
    CinemachineVirtualCamera cmvc;
    [SerializeField]
    bool stopMovement = false;
    [SerializeField]
    GameObject boundary;
    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        bc = gameObject.GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameObject.tag == "endingChange")
            {
                mps.changeCanMove(true);
                gm.endingCameraChange();
            }
            else if (gameObject.tag == "cutsceneone")
            {
                gm.changeActiveCam(cmvc);
                boundary.SetActive(true);
            }
            else if (gameObject.tag == "cutscenetwo")
            {
                gm.mainCamFollow(cmvc);
            }
            else
            {
                gm.changeActiveCam(cmvc);
                if (mps != null)
                {
                    mps.changeCanMove(true);
                }
                //StartCoroutine(ResetCameras());
            }
        }

    }
    IEnumerator ResetCameras()
    {
        yield return new WaitForSeconds(5f);
        gm.mainCamFollow(cmvc);
    }
}
