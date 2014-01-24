using UnityEngine;
using System.Collections;

public class BackgroundBehaviour : MonoBehaviour {
	
	private bool hasAppeared;
	
	// Use this for initialization
	void Start () {
		// If object starts off screen
		hasAppeared = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnBecomeVisible(){
		hasAppeared = true;
	}
	
	void OnBecomeInvisible(){
		// Destroy object once it's come onto the screen and then left it.
		if(hasAppeared){
			Destroy(gameObject);
		}
	}

}
