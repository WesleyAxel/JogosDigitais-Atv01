using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tocadorWin : MonoBehaviour
{
    AudioSource audio3;

    public void playWin()
    {
        audio3 = GetComponent<AudioSource>();
        audio3.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


