using UnityEngine;
using System.Collections;

public class CardAnimationManager {
	Card cardOwner = null; //Card that will be affected by this manager.
	CardAnimation currentAnimation = null;

	public CardAnimationManager(Card c)
	{
		cardOwner = c;
	}

	public void Update()
	{
		if(currentAnimation != null)
		{
			if(!currentAnimation.NextUpdate())
			{
				currentAnimation = null;
			}
		}
	}

	public bool IsActive()
	{
		return currentAnimation != null;
	}

	public void AddAnimation(CardAnimation newAnim)
	{
		//if(currentAnimation == null)
		//{
			currentAnimation = newAnim;
		//}
	}
}
