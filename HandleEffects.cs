using UnityEngine;
using System.Collections;

public class HandleEffects : MonoBehaviour {
	public Transform lockEffect;
	Transform lockObject;
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void ActiveLockEffect(fieldPositions pos)
	{
		Debug.Log("" + pos);
		
		Vector3 newVector = new Vector3(0.0f, 0.0f, 0.0f);
		
		if(pos == fieldPositions.FRONT_GUARD_LEFT)       newVector = new Vector3(-25.30901f, -19.16035f, -13.45249f);	
		else if(pos == fieldPositions.VANGUARD_CIRCLE)   newVector = new Vector3(-16.44314f, -19.1047f, -13.18696f);
		else if(pos == fieldPositions.FRONT_GUARD_RIGHT) newVector = new Vector3(-7.641356f, -19.1047f, -13.18696f);
		else if(pos == fieldPositions.REAR_GUARD_CENTER) newVector = new Vector3(-16.42526f, -19.1047f, -22.72871f);
		else if(pos == fieldPositions.REAR_GUARD_LEFT)   newVector = new Vector3(-25.23825f, -19.1047f, -22.72871f);
		else if(pos == fieldPositions.REAR_GUARD_RIGHT)  newVector = new Vector3(-7.890007f, -19.1047f, -22.75553f);
		else if(pos == fieldPositions.ENEMY_FRONT_LEFT)  newVector = new Vector3(-7.404234f, -19.1047f, 5.36107f);
		else if(pos == fieldPositions.ENEMY_VANGUARD)    newVector = new Vector3(-16.44624f, -19.1047f, 5.36107f);
		else if(pos == fieldPositions.ENEMY_REAR_CENTER) newVector = new Vector3(-16.44624f, -19.1047f, 14.68424f);
		else if(pos == fieldPositions.ENEMY_REAR_LEFT)   newVector = new Vector3(-7.624998f, -19.1047f, 14.91637f);
		else if(pos == fieldPositions.ENEMY_REAR_RIGHT)  newVector = new Vector3(-25.14756f, -19.1047f, 14.91637f);
		else if(pos == fieldPositions.ENEMY_FRONT_RIGHT) newVector = new Vector3(-25.14756f, -19.1047f, 5.720847f);
		
		lockObject = (Transform)Instantiate(lockEffect, newVector, Quaternion.identity);
	}
	
	public void EndLockEffect()
	{
		DestroyObject(lockObject.gameObject);
	}
}
