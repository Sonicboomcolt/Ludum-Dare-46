using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Manager : MonoBehaviour
{
    private static Music_Manager musicInstance;

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (musicInstance == null)
        {
            musicInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
