using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Scripts por C121.
public class Seguimiento : MonoBehaviour
{
    public GameObject target;
	public float smoothTime;

	private Vector2 vel;

    void Start()
    {
		transform.position = new Vector3(target.transform.position.x,target.transform.position.y, transform.position.z);
    }
    void Update()
    {
    	//SmoothDamp calcula un desplazamiento suavizado, usando a vel y smoothTime.
		float posX = Mathf.SmoothDamp (transform.position.x, target.transform.position.x, ref vel.x, smoothTime);
		float posY = Mathf.SmoothDamp (transform.position.y, target.transform.position.y, ref vel.y, smoothTime);
		transform.position = new Vector3(posX, posY, transform.position.z);
    }	
}
