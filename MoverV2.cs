//Scripts por C121.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
	//Declaración de variables
    public float speed;
    public float speedRot;
    public float jumpTime;
    
    public bool isJumping;
    public bool isMouseActive;
    public bool isJumpActive;
    public bool isTurretActive;

    private Vector3 mousePos;
    private Vector3 pos;
    private BoxCollider2D bc;
    private GameObject turret;
   
   	void Start(){
   		bc = GetComponent<BoxCollider2D>();
   		if(transform.childCount > 0)
   			transform.GetChild(0);
   	}
    void Update()
    {
    	//Movimiento
        if(Input.GetKey(KeyCode.W)){
        	transform.Translate(new Vector3(0,speed*Time.deltaTime,0));
        }
        if(Input.GetKey(KeyCode.S)){
        	transform.Translate(new Vector3(0,-speed*Time.deltaTime,0));
        }         
        //Salto  
        if(isJumpActive){
        	if(Input.GetKeyDown(KeyCode.Space) && !isJumping){
	        	isJumping = true;
	        	bc.enabled = false;
	        	transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
	        	Invoke("DetenerSalto", jumpTime);
        	}
        }        
        //Rotación
        if(isMouseActive){
        	mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	        mousePos.z = 0;
	        pos = mousePos - transform.position;
	        float angle = Mathf.Atan2(pos.y, pos.x)*Mathf.Rad2Deg;
        	if(isTurretActive){
        		if(Input.GetKey(KeyCode.A)){
    				transform.Rotate(new Vector3(0, 0, speedRot*Time.deltaTime));
		        }
		        if(Input.GetKey(KeyCode.D)){
		    		transform.Rotate(new Vector3(0, 0, -speedRot*Time.deltaTime));
		        }
	        	turret.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        	}else{				
	        	transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        	}        	
        }else{
        	if(Input.GetKey(KeyCode.A)){
    			transform.Rotate(new Vector3(0, 0, speedRot*Time.deltaTime));
	        }
	        if(Input.GetKey(KeyCode.D)){
	    		transform.Rotate(new Vector3(0, 0, -speedRot*Time.deltaTime));
	        }
        }
        if(isJumping){
        	//condiciones de salto
        }                               
    }

    void DetenerSalto(){
    	transform.localScale = new Vector3(1f, 1f, 1f);
    	isJumping = false;
    	bc.enabled = true;
    }
}
