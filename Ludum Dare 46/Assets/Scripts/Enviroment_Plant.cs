using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enviroment_Plant : MonoBehaviour
{
    [SerializeField] private float decayTime = 15f;
    [SerializeField] private float cooldownDecayTime;
    private bool plantDead;

    private bool useButton;

    Player_WaterSystem waterSystem;

	[SerializeField] GameObject plant;

	public Slider slider;
    private void Start()
	{
        plantDead = false;
        cooldownDecayTime = decayTime;
		useButton = true;
		if(slider != null)
		{
			slider.value = cooldownDecayTime;
		}
    }

    private void Update()
	{
		if(slider != null)
		{
			slider.value = cooldownDecayTime;
		}
        //Check if the plant is alive and decay
        if(!plantDead)
        {
            cooldownDecayTime -= Time.deltaTime;
            if (cooldownDecayTime < 0)
            {
                plantDead = true;
	            Destroy(plant);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            waterSystem = other.GetComponent<Player_WaterSystem>();
	        waterSystem.feedPlant = true;
	        if(slider != null)
	        {
		        slider.value = cooldownDecayTime;
	        }
            if (Input.GetKeyDown(KeyCode.E) && !plantDead && !useButton)
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
	        if(slider != null)
	        {
		        slider.value = cooldownDecayTime;
	        }
            waterSystem = other.GetComponent<Player_WaterSystem>();
            waterSystem.feedPlant = true;
            if (!plantDead && useButton)
            {
                if (waterSystem.hasWater)
                {
                    Debug.Log("Feed Plant Water");
                    waterSystem.hasWater = false;
                    waterSystem.feedPlant = false;

	                cooldownDecayTime = decayTime;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
	        if(slider != null)
	        {
		        slider.value = cooldownDecayTime;
	        }
            waterSystem = other.GetComponent<Player_WaterSystem>();
            waterSystem.feedPlant = false;
        }
    }
}
