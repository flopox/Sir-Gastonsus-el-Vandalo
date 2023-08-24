using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemigo : MonoBehaviour
{
	private PlayerScript player;
	[SerializeField]
	float step;
	private Vector3 target;
	
	void Start(){
		player = FindObjectOfType < PlayerScript >();
		target = player.GetComponent < Transform >().position;
	}

	void Update(){
		 transform.position = Vector2.MoveTowards(transform.position, target, step);
	}
    private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.CompareTag("Player")) {
			GameManager.Instance.PerderVidas();
		}
	}

}