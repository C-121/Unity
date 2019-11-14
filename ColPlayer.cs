using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColPlayer : MonoBehaviour
{	
	public Text texto;
	public Text textoVida;
	public float vida;
	public float dano;
	public int monedas;
	public float tiempoSeg;


	private Mover mover;

	void Start(){
		mover = GetComponent<Mover>();
		tiempoSeg = 0;
	}
	
	void Update(){
		tiempoSeg += Time.deltaTime;
	}
    void OnTriggerEnter2D(Collider2D col){
    	if(col.CompareTag("ZonaDano") && !mover.isJumping){
    		vida-=dano*Random.Range(0.5f,5f);
    		textoVida.text = "Salud: " + Mathf.Round(vida);
    	}
    	if(col.CompareTag("Moneda")){
    		monedas = monedas + 1;
    		texto.text = "Monedas: " + monedas;
    	}
    }
    void OnTriggerStay2D(Collider2D col){
    	if(col.CompareTag("ZonaDano") && !mover.isJumping){
    		vida-=dano*Time.deltaTime;
    		textoVida.text = "Salud: " + Mathf.Round(vida);
    	}
    }
}
