using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_WaterSystem : MonoBehaviour
{
    [SerializeField] public bool canPickupWater;
    [SerializeField] private bool hasWater;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(canPickupWater && !hasWater)
            {
                Debug.Log("Pickedup water");
                hasWater = true;
            }

            if (!canPickupWater && hasWater)
            {
                Debug.Log("Dropped water");
                hasWater = false;
            }
        }
    }
}
