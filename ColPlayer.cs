using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColPlayer : MonoBehaviour
{
	public float vida;
	public float dano;

	private Mover mover;

	void Start(){
		mover = GetComponent<Mover>();
	}
	
    void OnTriggerEnter2D(Collider2D col){
    	if(col.CompareTag("ZonaDano") && !mover.isJumping){
    		vida-=dano*Random.Range(0.5f,5f);
    	}
    }
    void OnTriggerStay2D(Collider2D col){
    	if(col.CompareTag("ZonaDano") && !mover.isJumping){
    		vida-=dano*Time.deltaTime;
    	}
    }
}
