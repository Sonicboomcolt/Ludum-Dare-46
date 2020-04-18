using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enviroment_Plant : MonoBehaviour
{
    [SerializeField] private float decayTime = 15f;
    [SerializeField] private float cooldownDecayTime;
    private bool plantDead;

    Player_WaterSystem waterSystem;

    private void Start()
    {
        plantDead = false;
        cooldownDecayTime = decayTime;
    }

    private void Update()
    {
        //Check if the plant is alive and decay
        if(!plantDead)
        {
            cooldownDecayTime -= Time.deltaTime;

            if (cooldownDecayTime < 0)
            {
                plantDead = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            waterSystem = other.GetComponent<Player_WaterSystem>();
            waterSystem.feedPlant = true;

            if (Input.GetKeyDown(KeyCode.E) && !plantDead)
            {
                if (waterSystem.hasWater)
                {
                    Debug.Log("Feed Plant Water");
                    waterSystem.hasWater = false;

                    cooldownDecayTime = decayTime;
                }
            } 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            waterSystem = other.GetComponent<Player_WaterSystem>();
            waterSystem.feedPlant = false;
        }
    }
}
