using UnityEngine;
using System.Collections;

public class CardAnimation {
	private Vector3 newPosition;
	private Vector3 newAngle;
	private Card card = null;

	public CardAnimation(Card c, Vector3 newPosition, Vector3 newAngle)
	{
		this.card = c;
		this.newPosition = newPosition;
		this.newAngle = newAngle;
	}

	public CardAnimation(Card c, Vector3 newPosition)
	{
		this.card = c;
		this.newPosition = newPosition;
	}

	public CardAnimation(Card c)
	{
		this.card = c;
	}

	public virtual bool NextUpdate()
	{
		return false;
	}

	public Card GetCard()
	{
		return card;
	}

	public Vector3 GetFinalPosition()
	{
		return newPosition;
	}

	public Transform GetModel()
	{
		return card.GetGameObject().transform;
	}
}
