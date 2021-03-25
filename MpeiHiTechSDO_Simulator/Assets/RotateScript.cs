using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    // Start is called before the first frame update
 
    // Update is called once per frame
	float y;
    void Update()
    {
        y+= Time.deltaTime * 100;
		transform.rotation=Quaternion.Euler(0,y,0);
    }
}
