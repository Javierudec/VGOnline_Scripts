using UnityEngine;
using System.Collections;

public class Util {
	public static bool IsPlayerFieldPosition(fieldPositions pos)
	{
		if(pos == fieldPositions.VANGUARD_CIRCLE || pos == fieldPositions.REAR_GUARD_LEFT ||
		   pos == fieldPositions.REAR_GUARD_RIGHT || pos == fieldPositions.REAR_GUARD_CENTER ||
		   pos == fieldPositions.FRONT_GUARD_LEFT || pos == fieldPositions.FRONT_GUARD_RIGHT)
		{
			return true;	
		}
		
		return false;
	}
	
	public static bool MouseOn(float boxX, float boxY, float boxW, float boxH, Vector3 mousePosition)
	{
		float mX = mousePosition.x;
		float mY = Screen.height - mousePosition.y;
		
		if(mX > boxX && mY > boxY && mX < (boxX + boxW) && mY < (boxY + boxH))
		{
			return true;
		}
		
		return false;
	}
	
	public static fieldPositions GetMousePosition()
	{
		if(Util.CheckPosition(fieldPositions.FRONT_GUARD_LEFT))
		{
			return fieldPositions.FRONT_GUARD_LEFT;	
		}
		
		if(Util.CheckPosition(fieldPositions.FRONT_GUARD_RIGHT))
		{
			return fieldPositions.FRONT_GUARD_RIGHT;	
		}
		
		if(Util.CheckPosition(fieldPositions.VANGUARD_CIRCLE))
		{
			return fieldPositions.VANGUARD_CIRCLE;	
		}
		
		if(Util.CheckPosition(fieldPositions.REAR_GUARD_LEFT))
		{
			return fieldPositions.REAR_GUARD_LEFT;	
		}
		
		if(Util.CheckPosition(fieldPositions.REAR_GUARD_RIGHT))
		{
			return fieldPositions.REAR_GUARD_RIGHT;	
		}
		
		if(Util.CheckPosition(fieldPositions.REAR_GUARD_CENTER))
		{
			return fieldPositions.REAR_GUARD_CENTER;	
		}
		
		if(Util.CheckPosition(fieldPositions.ENEMY_FRONT_LEFT))
		{
			return fieldPositions.ENEMY_FRONT_LEFT;	
		}
		
		if(Util.CheckPosition(fieldPositions.ENEMY_FRONT_RIGHT))
		{
			return fieldPositions.ENEMY_FRONT_RIGHT;	
		}
		
		if(Util.CheckPosition(fieldPositions.ENEMY_REAR_CENTER))
		{
			return fieldPositions.ENEMY_REAR_CENTER;	
		}
		
		if(Util.CheckPosition(fieldPositions.ENEMY_REAR_LEFT))
		{
			return fieldPositions.ENEMY_REAR_LEFT;	
		}
		
		if(Util.CheckPosition(fieldPositions.ENEMY_REAR_RIGHT))
		{
			return fieldPositions.ENEMY_REAR_RIGHT;	
		}
		
		if(Util.CheckPosition(fieldPositions.ENEMY_VANGUARD))
		{
			return fieldPositions.ENEMY_VANGUARD;	
		}
		
		return fieldPositions.DECK_ZONE;
	}
	
	public static bool IsEnemyPosition(fieldPositions pos)
	{
		if(pos == fieldPositions.ENEMY_FRONT_LEFT ||
			pos == fieldPositions.ENEMY_FRONT_RIGHT ||
			pos == fieldPositions.ENEMY_REAR_CENTER ||
			pos == fieldPositions.ENEMY_REAR_LEFT ||
			pos == fieldPositions.ENEMY_REAR_RIGHT ||
			pos == fieldPositions.ENEMY_VANGUARD)
		{
			return true;	
		}
		
		return false;
	}	
	
	public static bool IsFrontRow(fieldPositions pos)
	{
		if(pos == fieldPositions.ENEMY_FRONT_LEFT ||
			pos == fieldPositions.ENEMY_FRONT_RIGHT ||
			pos == fieldPositions.ENEMY_VANGUARD)
		{
			return true;	
		}
		
		return false;		
	}
	
	public static bool IsBackRow(fieldPositions pos)
	{
		if(pos == fieldPositions.ENEMY_REAR_CENTER ||
			pos == fieldPositions.ENEMY_REAR_LEFT ||
	 		pos == fieldPositions.ENEMY_REAR_RIGHT)
		{
			return true;	
		}
		
		return false;		
	}
	
	public static bool CheckPosition(fieldPositions _pos)
	{
		Camera _Camera = (Camera)GameObject.FindGameObjectWithTag("MainCamera").GetComponent("Camera");
		Vector3 pos;
		
		if(!Util.IsEnemyPosition(_pos))
		{
			pos = _Camera.WorldToScreenPoint(Gameplay.fieldInfo.GetPosition((int)_pos));	
		}
		else
		{
			pos = _Camera.WorldToScreenPoint(Gameplay.EnemyFieldInfo.GetPosition((int)Util.TransformToEquivalentEnemyPosition(_pos)));	
		}
		
		float _x = pos.x;
		float _y = Camera.main.pixelHeight - pos.y;
		
		if(Util.MouseOn(_x - 40.0f, _y - 80, 80.0f, 120, Input.mousePosition))
		{
			return true;
		}	
		
		return false;
	}
	
	public static EnemyFieldPosition TransformToEquivalentEnemyPosition(fieldPositions pos)
	{
		if(pos == fieldPositions.ENEMY_VANGUARD)
		{
			return EnemyFieldPosition.VANGUARD;	
		}
		else if(pos == fieldPositions.ENEMY_FRONT_LEFT)
		{
			return EnemyFieldPosition.FRONT_LEFT;	
		}
		else if(pos == fieldPositions.ENEMY_FRONT_RIGHT)
		{
			return EnemyFieldPosition.FRONT_RIGHT;		
		}		
		else if(pos == fieldPositions.ENEMY_REAR_CENTER)
		{
			return EnemyFieldPosition.REAR_CENTER;	
		}
		else if(pos == fieldPositions.ENEMY_REAR_LEFT)
		{
			return EnemyFieldPosition.REAR_LEFT;	
		}
		else if(pos == fieldPositions.ENEMY_REAR_RIGHT)
		{
			return EnemyFieldPosition.REAR_RIGHT; 	
		}
		
		return EnemyFieldPosition.DECK;
	}
	
	public static EnemyFieldPosition TranformToEnemyPosition(fieldPositions pos)
	{
		if(pos == fieldPositions.FRONT_GUARD_LEFT)
			return EnemyFieldPosition.FRONT_LEFT;
		
		if(pos == fieldPositions.FRONT_GUARD_RIGHT)
			return EnemyFieldPosition.FRONT_RIGHT;
		
		if(pos == fieldPositions.REAR_GUARD_CENTER)
			return EnemyFieldPosition.REAR_CENTER;
		
		if(pos == fieldPositions.REAR_GUARD_LEFT)
			return EnemyFieldPosition.REAR_LEFT;
		
		if(pos == fieldPositions.REAR_GUARD_RIGHT)
			return EnemyFieldPosition.REAR_RIGHT;
		
		if(pos == fieldPositions.VANGUARD_CIRCLE)
			return EnemyFieldPosition.VANGUARD;
		
		return EnemyFieldPosition.DECK;
	}

	public static fieldPositions EnemyToFieldPosition(EnemyFieldPosition p)
	{
		if(p == EnemyFieldPosition.FRONT_LEFT) return fieldPositions.ENEMY_FRONT_LEFT;
		if(p == EnemyFieldPosition.FRONT_RIGHT) return fieldPositions.ENEMY_FRONT_RIGHT;
		if(p == EnemyFieldPosition.REAR_CENTER) return fieldPositions.ENEMY_REAR_CENTER;
		if(p == EnemyFieldPosition.REAR_RIGHT) return fieldPositions.ENEMY_REAR_RIGHT;
		if(p == EnemyFieldPosition.REAR_LEFT) return fieldPositions.ENEMY_REAR_LEFT;
		return fieldPositions.DECK_ZONE;
	}
	
	public static fieldPositions TransformToPlayerField(fieldPositions pos)
	{
		if(pos == fieldPositions.ENEMY_VANGUARD)
			return fieldPositions.VANGUARD_CIRCLE;
		
		if(pos == fieldPositions.ENEMY_FRONT_LEFT)
			return fieldPositions.FRONT_GUARD_LEFT;
		
		if(pos == fieldPositions.ENEMY_FRONT_RIGHT)
			return fieldPositions.FRONT_GUARD_RIGHT;
		
		if(pos == fieldPositions.ENEMY_REAR_CENTER)
		{
			return fieldPositions.REAR_GUARD_CENTER;	
		}
		
		if(pos == fieldPositions.ENEMY_REAR_RIGHT)
		{
			return fieldPositions.REAR_GUARD_RIGHT;	
		}
		
		if(pos == fieldPositions.ENEMY_REAR_LEFT)
		{
			return fieldPositions.REAR_GUARD_LEFT;	
		}
		
		return fieldPositions.DECK_ZONE;
	}
}
