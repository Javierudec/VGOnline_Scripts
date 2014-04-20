using UnityEngine;
using System.Collections;

public class BindZoneScript : MonoBehaviour {
	private Gameplay Game;
	
	// Use this for initialization
	void Start () {
		Game = (Gameplay)GameObject.FindGameObjectWithTag("MainCamera").GetComponent("Gameplay");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp()
	{
		Game._CardMenu.OpenBindMenu(gameObject.transform.position);
	}
	
	void OnMouseExit()
	{
		
	}
}
