using UnityEngine;
using System.Collections;

public class GUICrosshair : MonoBehaviour {

	public Texture2D crosshairImage;
	public int textureWidth = 32;
	public int textureHeight = 32;

	void OnGUI()
	{
    float xMin = (Screen.width / 2) - (textureWidth / 2);
    float yMin = (Screen.height / 2) - (textureHeight / 2);
    GUI.DrawTexture(new Rect(xMin, yMin, textureWidth, textureHeight), crosshairImage);
	}
}
