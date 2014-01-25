using UnityEngine;
using System.Collections;

public class SimpleAnimator : MonoBehaviour {

	public Sprite[] sprites;
	public float framesPerSecond;
	
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = renderer as SpriteRenderer;	
	}
	
	// Update is called once per frame
	void Update () {
		int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
		index = index % sprites.Length;
		if(BetsyController.onGround)
			spriteRenderer.sprite = sprites[index];
		else
			spriteRenderer.sprite = sprites[0];
	}
}
