using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cupChange : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){

		Vector3 direction = this.transform.position;
		SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>(); 	
		int playerNo = 2;

		if(other.gameObject.tag.Equals("waterdrop"))
		{
			Destroy(other.gameObject);
			spriteRenderer.sprite = Resources.Load<Sprite>("cup/cup_" + playerNo);
		}
	}
}
