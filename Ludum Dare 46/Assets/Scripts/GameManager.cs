using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public Enviroment_Plant Plant1;
	public Enviroment_Plant Plant2;
	public Enviroment_Plant Plant3;
	public Player_SunDetector Player;
	
    // Start is called before the first frame update
    void Start()
    {
	    
    }

    // Update is called once per frame
    void Update()
    {
	    if(Plant1.cooldownDecayTime <= 0)
	    {
		    if(Plant2.cooldownDecayTime <= 0)
		    {
			    if(Plant3.cooldownDecayTime <= 0)
			    {
	    			Player.Charge = -1;
			    }
		    }
	    }
    }
    
}
