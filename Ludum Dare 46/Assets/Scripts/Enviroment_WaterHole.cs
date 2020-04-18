using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enviroment_WaterHole : MonoBehaviour
{
    Player_WaterSystem waterSystem;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            waterSystem = other.GetComponent<Player_WaterSystem>();
            waterSystem.canPickupWater = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            waterSystem = other.GetComponent<Player_WaterSystem>();
            waterSystem.canPickupWater = false;
        }
    }
}
