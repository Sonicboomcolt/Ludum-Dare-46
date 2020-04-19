using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
	public GameObject BigMap;
	public GameObject MiniMap;
	public Camera MiniMapCamera;
    // Start is called before the first frame update
    void Start()
	{
		if(Time.timeScale >= 1)
	    BigMap.SetActive(false);
	    MiniMap.SetActive(false);
    }

    // Update is called once per frame
    void Update()
	{
		if(Time.timeScale >= 1)
	    if(Input.GetKey(KeyCode.M))
	    {
		    BigMap.SetActive(true);
		    MiniMap.SetActive(false);
		    MiniMapCamera.orthographicSize = 40;
	    }
	    if(!Input.GetKey(KeyCode.M))
	    {
		    BigMap.SetActive(false);
		    MiniMap.SetActive(true);
		    MiniMapCamera.orthographicSize = 16;
	    }
    }
}
