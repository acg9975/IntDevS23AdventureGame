using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionBehavior : MonoBehaviour
{
    [SerializeField]
    AudioSource AS;
    // Start is called before the first frame update
    void Start()
    {
        AS.Play();
        transform.parent.gameObject.GetComponent<explosionParent>().destroySelf();
        Destroy(gameObject, 0.5f);
    }

}
