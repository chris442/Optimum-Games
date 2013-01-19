using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	
	public int m;
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		movePlayer();
	
	}
	void movePlayer()
	{
		if(m == 1)
		{
			transform.localPosition = new Vector3(0.0f, 2.0f, -30.0f); 
		}
		
		if(m == 2)
		{
			transform.localPosition = new Vector3(30.0f,2.0f,0.0f); 
		}
		
		if(m == 3)
		{
			transform.localPosition = new Vector3(-30.0f,2.0f,0.0f); 
		}
		
		if(m == 4)
		{
			transform.localPosition = new Vector3(0.0f,2.0f,30.0f); 
		}
		
		if(m==5)
		{
			transform.localPosition = new Vector3(0.0f,2.0f,0.0f);
		}
	}
	
	void OnTriggerEnter(Collider hit)
	{
		if(hit.collider.gameObject.tag == "Maths")
		{
			m = 1;			
		}
		if(hit.collider.gameObject.tag == "Computing")
		{
			m = 2;			
		}
		if(hit.collider.gameObject.tag == "Science")
		{
			m = 3;			
		}
		if(hit.collider.gameObject.tag == "Sports")
		{
			m = 4;			
		}	
		
		if(hit.collider.gameObject.tag == "Home")
		{
			m = 5;			
		}
	}
}