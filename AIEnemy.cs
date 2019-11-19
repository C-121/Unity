using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemy : MonoBehaviour
{	
	public GameObject player, a, b;
	public bool onPatrol = true;
	public float speed = 2;
	public float speedRunning = 4;
	public float visionRange = 3;

	private GameObject target;

	void Start(){
		target = a;
	}
		
    void Update()
    {
		if(onPatrol){
			/*if(transform.position.x >= target.transform.position.x){
				transform.Translate(-speed*Time.deltaTime, 0, 0);
			}else{
				transform.Translate(speed*Time.deltaTime, 0, 0);
			}
			if(transform.position.y >= target.transform.position.y){
				transform.Translate(0, -speed*Time.deltaTime, 0);
			}else{
				transform.Translate(0, speed*Time.deltaTime, 0);
			}*/
			Vector3 dir = target.transform.position - transform.position;
			float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
			transform.Translate(Vector3.up * speed * Time.deltaTime);

			if(visionRange > Mathf.Sqrt(Mathf.Pow(Mathf.Abs(transform.position.x - player.transform.position.x), 2) + Mathf.Pow(Mathf.Abs(transform.position.y - player.transform.position.y),2))){
				onPatrol = false;
				target = player;
			}
		}else{
			/*if(transform.position.x >= target.transform.position.x){
				transform.Translate(-speedRunning*Time.deltaTime, 0, 0);
			}else{
				transform.Translate(speedRunning*Time.deltaTime, 0, 0);
			}
			if(transform.position.y >= target.transform.position.y){
				transform.Translate(0, -speedRunning*Time.deltaTime, 0);
			}else{
				transform.Translate(0, speedRunning*Time.deltaTime, 0);
			}*/
			Vector3 dir = target.transform.position - transform.position;
			float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
			transform.Translate(Vector3.up * speedRunning * Time.deltaTime);
			if(visionRange < Mathf.Sqrt(Mathf.Pow(Mathf.Abs(transform.position.x - player.transform.position.x), 2) + Mathf.Pow(Mathf.Abs(transform.position.y - player.transform.position.y),2))){
				onPatrol = true;
				target = a;
			}
		}

    }

	void OnTriggerEnter2D(Collider2D col){
		if(onPatrol){
			if(col.CompareTag("WaypointA")){
				target = b;
			}
			if(col.CompareTag("WaypointB")){
				target = a;
			}
		}
		if(col.CompareTag("Melee")){
			Destroy(this.gameObject);
		}
	}
}
