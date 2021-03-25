using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class oldscriot : MonoBehaviour
{
  public GameObject scoreText2;
  public int theScore2;
  public  AudioSource collectSound2;
  
  
  void OnTriggerEnter(Collider other)
  {
	collectSound2.Play();
	theScore2 += 50;
	
	scoreText2.GetComponent<Text>().text= "=" + theScore2;
	Destroy(gameObject);
  }
}

