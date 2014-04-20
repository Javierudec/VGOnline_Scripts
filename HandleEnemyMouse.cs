using UnityEngine;
using System.Collections;

public class HandleEnemyMouse : MonoBehaviour {
	private Card OwnerCard = null;
	private Gameplay Game;
	public bool mouseOn = false;
	// Use this for initialization
	void Start () {
		//OwnerCard = (Card)gameObject.GetComponent("Card");
		Game = (Gameplay)GameObject.FindGameObjectWithTag("MainCamera").GetComponent("Gameplay");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void SetCard(Card card)
	{
		OwnerCard = card;	
	}
	
	void OnMouseUp()
	{
		if(OwnerCard != null)
		{
			//OwnerCard.BindAnim();
		}
	}
	
	void OnMouseOver()
	{
		if(OwnerCard != null)
		{	
			mouseOn = true;
			
			if(OwnerCard._Coord == CardCoord.ENEMY_HAND)
			{
				Game.LastEnemyHandSelected = OwnerCard;	
			}

			if(OwnerCard._Coord == CardCoord.ENEMY_DAMAGE)
			{
				Game.LastEnemyDamageCardSelected = OwnerCard;
			}
			
			if(Game._MouseHelper.GetAttachedCard() == null && (OwnerCard.IsFaceup() || OwnerCard._Coord == CardCoord.ENEMY_DAMAGE))
			{
				Game._CardMenuHelper.SetCard(OwnerCard.cardID);
			}
			
			if(OwnerCard._Coord == CardCoord.GUARD)
			{
				Game.LastGuardCardSelected = OwnerCard;	
			}
		}
	}
	
	void OnMouseExit()
	{
		mouseOn = false;	
	}
}
