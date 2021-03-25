using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GAmeEnd : MonoBehaviour
{
	public  AudioSource EndSound;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
  {
	  if( ScoreScript.theScore >= 5)
	  {
		EndSound.Play();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1 );
	  }
  }
}
