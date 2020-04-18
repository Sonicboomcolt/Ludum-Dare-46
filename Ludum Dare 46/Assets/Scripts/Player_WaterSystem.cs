using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_WaterSystem : MonoBehaviour
{
    public bool canPickupWater;
    public bool hasWater;
    public bool feedPlant;
    public bool buttonPress;

    [SerializeField] GameObject waterObject;
    [SerializeField] GameObject pubbleObject;

    private void Update()
    {
        waterObject.SetActive(hasWater);

        if(!buttonPress)
        {
            if (canPickupWater && !hasWater && !feedPlant)
            {
                Debug.Log("Picked up water");
                hasWater = true;
            }

            if (!canPickupWater && hasWater && feedPlant)
            {
                hasWater = false;
                feedPlant = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && buttonPress)
        {
            if (canPickupWater && !hasWater && !feedPlant)
            {
                Debug.Log("Picked up water");
                hasWater = true;
            }

            if (!canPickupWater && hasWater && !feedPlant)
            {
                GameObject puddle = Instantiate(pubbleObject, transform.position, transform.rotation);
                Destroy(puddle, 5f);

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
