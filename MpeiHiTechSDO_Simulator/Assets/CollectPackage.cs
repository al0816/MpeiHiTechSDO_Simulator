using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CollectPackage : MonoBehaviour
{
	public  AudioSource collectSound;
	
	
   void OnTriggerEnter(Collider other)
  {
	  
	  collectSound.Play();
	  Debug.Log(ScoreScript.theScore);
	  ScoreScript.theScore += 1;
	  Destroy(gameObject);
  }
}
