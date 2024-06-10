using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour {

	public Transform cameraCorrection;
	public float smooth = 3f;
	public Transform normalPosition;
	public Transform frontPosition;
	private bool isFront;
	private Vector3 curPos;
	public static Transform positionCorrection;
	public static float targetHeight;
	
	void Start()
	{
		isFront = false;
		transform.position = normalPosition.position;
		transform.forward = normalPosition.forward;	
	}

	void FixedUpdate()
	{
		if(Input.GetMouseButton(0)) FrontView(); else NormalView(); //переключить вид - удерживать ЛКМ
	}

	void Result()
	{
		transform.position = Vector3.Lerp(transform.position, cameraCorrection.position, Time.fixedDeltaTime * smooth);
		transform.forward = Vector3.Lerp(transform.forward, cameraCorrection.forward, Time.fixedDeltaTime * smooth);
	}
	
	void NormalView()
	{
		positionCorrection = normalPosition;
		targetHeight = normalPosition.position.y;
		if(!isFront)
		{
			Result();
		}
		else
		{
			transform.position = normalPosition.position;	
			transform.forward = normalPosition.forward;
			isFront = false;
		}
	}
	
	
	void FrontView()
	{
		positionCorrection = frontPosition;
		targetHeight = frontPosition.position.y;
		if(!isFront)
		{
			isFront = true;
			transform.position = frontPosition.position;	
			transform.forward = frontPosition.forward;
		}
		else
		{
			Result();
		}
	}
}