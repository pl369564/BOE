using UnityEngine;
using System.Collections;

public class cursorManager : MonoBehaviour {
	public static cursorManager _instance;

	public Texture2D cursor_normal;
	public Texture2D cursor_npc_talk;
	public Texture2D cursor_enemy;

	private Vector2 hotspot=Vector2.zero;
	private CursorMode mode=CursorMode.Auto;

	void Start(){
		_instance = this;
        Cursor.SetCursor(cursor_normal, hotspot, mode);
    }
	public void SetNormal(){
		Cursor.SetCursor (cursor_normal, hotspot, mode);
	}
	public void SetNpcTalk(){
		Cursor.SetCursor (cursor_npc_talk, hotspot, mode);
	}
	public void SetEnemy(){
		Cursor.SetCursor (cursor_enemy, hotspot, mode);
	}
}
