using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour
{
    [SerializeField]
    Transform target, endOfCannon;

    [SerializeField]
    GameObject bomb;
    [SerializeField]
    GameObject implosionBomb;

    private Vector3 mousePos;
    private Camera mainCam;

    [SerializeField]
    float rotateDir = 0;

    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }


    // Update is called once per frame
    void Update()
    {
        MouseAim();

        //transform.RotateAround(target.position, Vector3.back, rotateDir * Time.deltaTime);


        Debug.DrawRay(transform.position, transform.right, Color.red);


        if (Input.GetKeyDown(KeyCode.E))
        {
            Transform bp = GameObject.Find("bombparent").GetComponent<Transform>();
            GameObject spawnedBomb = Instantiate(bomb, endOfCannon.position, Quaternion.identity, bp);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Transform bp = GameObject.Find("bombparent").GetComponent<Transform>();
            GameObject spawnedBomb = Instantiate(bomb, endOfCannon.position, Quaternion.identity, bp);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Transform bp = GameObject.Find("bombparent").GetComponent<Transform>();
            GameObject spawnedBomb = Instantiate(implosionBomb, endOfCannon.position, Quaternion.identity, bp);
        }

    }

    private void MouseAim()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    public Vector3 getTransformRight()
    {
        return transform.right;
    }
}
