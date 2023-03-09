using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectFade : MonoBehaviour
{
    public Animator an;


    private void Start()
    {
        an = GetComponent<Animator>();
    }

    public void startFadeAway()
    {
        an.SetBool("Fade Out", true);
    }
}
