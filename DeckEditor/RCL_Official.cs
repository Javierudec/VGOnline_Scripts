using UnityEngine;
using System.Collections;

public class RCL_Official : RestrictedCardList {
	public override bool IsCardAllowed (Card2D cardToVerify)
	{
		bool bToRet = true;

		CardIdentifier id = cardToVerify._CardInfo.cardID;

		if(id == CardIdentifier.DRAGONIC_OVERLORD || id == CardIdentifier.DRAGONIC_OVERLORD_BREAK_RIDE)
		{
			if(CountByID(CardIdentifier.DRAGONIC_OVERLORD) + CountByID(CardIdentifier.DRAGONIC_OVERLORD_BREAK_RIDE) >= 4)
			{
				bToRet = false;
			}
		}

	    return bToRet;
	}
}
