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
    float rotateDir = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target.position, Vector3.back, rotateDir * Time.deltaTime);
        Debug.DrawRay(transform.position, transform.right, Color.red);

        changeDir();

        if (Input.GetKeyDown(KeyCode.E))
        {
            Transform bp = GameObject.Find("bombparent").GetComponent<Transform>();
            GameObject spawnedBomb = Instantiate(bomb, endOfCannon.position, Quaternion.identity, bp);
        }

    }

    private void changeDir()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rotateDir = -60;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rotateDir = 60;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rotateDir = 0;
        }
    }

    public Vector3 getTransformRight()
    {
        return transform.right;
    }
}
