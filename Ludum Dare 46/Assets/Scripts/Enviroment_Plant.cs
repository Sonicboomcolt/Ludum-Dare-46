using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enviroment_Plant : MonoBehaviour
{
    [SerializeField] private float decayTime = 15f;
    [SerializeField] private float cooldownDecayTime;
    private bool plantDead;

    private void Start()
    {
        plantDead = false;
        cooldownDecayTime = decayTime;
    }

    private void Update()
    {
        cooldownDecayTime -= Time.deltaTime;

        if(cooldownDecayTime < 0)
        {
            plantDead = true;
        }
    }

    public void FeedPlant()
    {
        cooldownDecayTime = decayTime;
    }
}
