using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionParent : MonoBehaviour
{
    public void destroySelf()
    {
        Destroy(gameObject,0.5f);
    }
}
