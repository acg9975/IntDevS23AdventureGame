using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject player, mainMenuButton, backgroundFade;

    CinemachineBrain cb;
    CinemachineVirtualCamera mainMenuCam, playerFollow_VC, endCamVC;
    CinemachineBlend blend;

    // Start is called before the first frame update
    void Start()
    {

        
        //player = GameObject.Find("player");
        cb = Camera.main.GetComponent<CinemachineBrain>();

        mainMenuCam = GameObject.Find("Main Menu Camera").GetComponent<CinemachineVirtualCamera>();

        playerFollow_VC = GameObject.Find("Player Follow Cameras").GetComponent<CinemachineVirtualCamera>();

        endCamVC = GameObject.Find("EndVC").GetComponent<CinemachineVirtualCamera>();
        /*
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {

        }
        */
    }

    void checkValue(GameObject obj)
    {
        if (obj == null)
        {
            Debug.LogError(obj + " is null");
            return;
        }
    }

    public void SetCameraTargetPlayer()
    {
        StartCoroutine(gameStart());
    }

    IEnumerator gameStart()
    {
        mainMenuButton.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        backgroundFade.GetComponent<objectFade>().startFadeAway();

        yield return new WaitForSeconds(1f);
        mainMenuCam.Priority = playerFollow_VC.Priority - 1;

        player.SetActive(true);
    }
    
    public void endingCameraChange()
    {
        endCamVC.Priority = playerFollow_VC.Priority + 1;
    }


}
