using UnityEngine;
using System.Collections.Generic;

public class BackgroundManager : MonoBehaviour {

	public Transform prefab;
	public int numberOfBackgrounds;
	public float recycleOffset;
	public Vector2 startPosition;

	private Vector2 nextPosition;
	private Queue<Transform> objectQueue;

	// Use this for initialization
	void Start () {
		objectQueue = new Queue<Transform>(numberOfBackgrounds);
		nextPosition = startPosition;
		for (int i = 0; i < numberOfBackgrounds; i++){
			Transform b = (Transform)Instantiate (prefab);
			b.localPosition = nextPosition;
			nextPosition.x += recycleOffset;
			objectQueue.Enqueue(b);
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (objectQueue.Peek().localPosition.x + recycleOffset < BetsyController.distanceTraveled) { 
			Transform b = objectQueue.Dequeue();
			b.localPosition = nextPosition;
			nextPosition.x += recycleOffset;
			objectQueue.Enqueue(b);
		}
	}
}
