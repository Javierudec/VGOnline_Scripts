using UnityEngine;
using System.Collections;

public class DummyCard : MonoBehaviour {
	private Gameplay Game;
	public fieldPositions pos;
	public bool mouseOn = false;

	void Start () {
		Game = (Gameplay)GameObject.FindGameObjectWithTag("MainCamera").GetComponent("Gameplay");

		//Game.GameChat.AddChatMessage("ADMIN2", "Setting Pos: " + pos);
		//gameObject.transform.position = Game.field.fieldInfo.GetPosition((int)pos);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseUp()
	{

	}
	
	void OnMouseOver()
	{
		mouseOn = true;
		Game.LastOpenRC = pos;
		Game.GameChat.AddChatMessage("ADMIN2", "" + pos);
	}
	
	void OnMouseExit()
	{
		mouseOn = false;	
		Game.LastOpenRC = fieldPositions.DECK_ZONE;
	}
}
