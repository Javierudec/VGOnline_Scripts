using UnityEngine;
using System.Collections;

public class MouseHelper {
	private Card _CardAttached = null;
	private Gameplay _Game = null;
	private FieldInformation _FieldInfo = null;
	private Camera _Camera = null;
	
	public MouseHelper(Gameplay game)
	{
		_Game = game;
		_FieldInfo = new FieldInformation();
		_Camera = (Camera)GameObject.FindGameObjectWithTag("MainCamera").GetComponent("Camera");
	}
	
	// Update is called once per frame
	public void Update () {
		if(_CardAttached != null)
		{
			CheckPosition(fieldPositions.FRONT_GUARD_LEFT);	
			CheckPosition(fieldPositions.FRONT_GUARD_RIGHT);
			CheckPosition(fieldPositions.REAR_GUARD_LEFT);
			CheckPosition(fieldPositions.REAR_GUARD_RIGHT);
			CheckPosition(fieldPositions.REAR_GUARD_CENTER);
		}
	}
	
	public Card GetAttachedCard()
	{
		return _CardAttached;	
	}
	
	public void UnattachCard()
	{
		_CardAttached = null;	
	}
	
	private void CheckPosition(fieldPositions _pos)
	{
		Vector3 pos = _Camera.WorldToScreenPoint(_FieldInfo.GetPosition((int)_pos));
		float _x = pos.x;
		float _y = Camera.main.pixelHeight - pos.y;
		
		if(Util.MouseOn(_x - 40.0f, _y - 40, 80.0f, 140.0f, Input.mousePosition))
		{
			_CardAttached.GetGameObject().transform.position = _FieldInfo.GetPosition((int)_pos);
			_CardAttached.pos = _pos;
		}	
	}
	
	public void AttachCard(Card card)
	{
		_CardAttached = card;	
		_CardAttached.GetGameObject().transform.position = _FieldInfo.GetPosition((int)GetEmptyRearPosition());
		_CardAttached.GetGameObject().transform.eulerAngles = _FieldInfo.GetCardRotation();
		_Game._CardMenuHelper.SetCard(card.cardID);
	}
	
	private fieldPositions GetEmptyRearPosition()
	{
		if(_Game.field.GetCardAt(fieldPositions.FRONT_GUARD_LEFT) == null)
		{
			return fieldPositions.FRONT_GUARD_LEFT;	
		}
		
		if(_Game.field.GetCardAt(fieldPositions.FRONT_GUARD_RIGHT) == null)
		{
			return fieldPositions.FRONT_GUARD_RIGHT;	
		}
		
		if(_Game.field.GetCardAt(fieldPositions.REAR_GUARD_LEFT) == null)
		{
			return fieldPositions.REAR_GUARD_LEFT;	
		}
		
		if(_Game.field.GetCardAt(fieldPositions.REAR_GUARD_RIGHT) == null)
		{
			return fieldPositions.REAR_GUARD_RIGHT;	
		}
		
		if(_Game.field.GetCardAt(fieldPositions.REAR_GUARD_CENTER) == null)
		{
			return fieldPositions.REAR_GUARD_CENTER;	
		}
		
		return fieldPositions.REAR_GUARD_CENTER;
	}
}
