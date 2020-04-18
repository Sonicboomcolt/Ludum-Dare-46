using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_WaterSystem : MonoBehaviour
{
    public bool canPickupWater;
    public bool hasWater;
    public bool feedPlant;

    [SerializeField] GameObject waterObject;

    private void Update()
    {
        waterObject.SetActive(hasWater);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if(canPickupWater && !hasWater && !feedPlant)
            {
                Debug.Log("Pickedup water");
                hasWater = true;
            }

            if (!canPickupWater && hasWater && !feedPlant)
            {
                Debug.Log("Dropped water");
                hasWater = false;
            }

            if (!canPickupWater && hasWater && feedPlant)
            {
                hasWater = false;
                feedPlant = false;
            }
        }
    }
}
