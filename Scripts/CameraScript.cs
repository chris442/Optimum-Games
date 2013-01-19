using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public Vector3 pos1;
	public Vector3 pos2;
	public int hit;
	
	
	Vector3 posM;
    Vector3 posS;
	Vector3 posF;
	Vector3 posC;
	
	public bool move;
	
	public int moveSpeed = 10;
	public bool top = true;
	
	public int s;
	
	public PlayerScript ps;
	void Start () 
	{
		pos1= new Vector3(0,20,0);
		pos2= new Vector3(0,80,0);
		
		posC = new Vector3(30.0f,20.0f,0.0f);
		posM = new Vector3(0.0f,20.0f,-30.0f);
		posS = new Vector3(-30.0f,20,0.0f);
		posF = new Vector3(0.0f,20.0f,30.0f);

		this.gameObject.transform.position = pos1;
	}
			
	void Update () 
	{
		movingToTop();
		StartCoroutine("movingToLevel");
		reset();
	}

	void movingToTop()
{ 
		if(ps.m != 0 && move==false && top == false)
		{
			move = true;
		}
		
		if(move == true)
		{
	 	 transform.localPosition = Vector3.MoveTowards(transform.localPosition,pos2, Time.deltaTime* moveSpeed); 
		}
		
			if(transform.localPosition == pos2)
		{
			move = false;
			top = true;
	  
	}
	}
		IEnumerator movingToLevel()
		{
		if(ps.m==1 && top == true)
		{
			transform.localPosition = Vector3.MoveTowards(transform.localPosition,posM, Time.deltaTime * moveSpeed); 
			yield return new WaitForSeconds(0.4f);
			if(transform.localPosition == posM)
			{
			top = false;
			move = false;
				s=1;
			}
		}
		 if(ps.m==2 && top == true)
		{
			transform.localPosition = Vector3.MoveTowards(transform.localPosition,posC, Time.deltaTime * moveSpeed); 
			yield return new WaitForSeconds(0.4f);
			if(transform.localPosition == posC)
			{
			top = false;
			move = false;
				s=2;
			}
		}
		 if(ps.m==3 && top == true)
		{
			transform.localPosition = Vector3.MoveTowards(transform.localPosition,posS, Time.deltaTime * moveSpeed); 
			yield return new WaitForSeconds(0.4f);
			if(transform.localPosition == posS)
			{
			top = false;
			move = false;
				s=3;
			}
		}
		 if(ps.m==4 && top == true)
		{
			transform.localPosition = Vector3.MoveTowards(transform.localPosition,posF, Time.deltaTime * moveSpeed); 
			yield return new WaitForSeconds(0.4f);
			if(transform.localPosition == posF)
			{
			top = false;
			move = false;
				s=4;
			}
	}
				 if(ps.m==5 && top == true)
		{
			transform.localPosition = Vector3.MoveTowards(transform.localPosition,pos1, Time.deltaTime * moveSpeed); 
			yield return new WaitForSeconds(0.4f);
			if(transform.localPosition == pos1)
			{
			top = false;
			move = false;
				s=5;
			}
	}
	}
	
	void reset()
	{
		if(transform.localPosition == pos1 || transform.localPosition == posM || transform.localPosition == posC || transform.localPosition == posS || transform.localPosition == posF )
			{
			ps.m = 0;
			move = false;
			}
	}
}