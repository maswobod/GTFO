using UnityEngine;
using System.Collections;

public class minimapCameraScript : MonoBehaviour {

    public GameObject targetToFollow;
    public GameObject enemy1;
    //public GameObject enemy2;
    public Camera minimapCamera;
    public Texture2D texturePlayer;
    public Texture2D textureEnemy;
    private float angleView;
    private float sizeTexture;
    private Vector2 centerPlayer;
    private Vector2 centerEnemy;
    private Vector3 offset;
    private Vector3 objPosition;
    private Vector3 positionEnemy1;

    void Start() {
        offset.y = 50;
        sizeTexture = 45;
    }
	
	// Update is called once per frame
	void Update () {

        // allways position Kamera above palyer
        transform.position = targetToFollow.transform.position + offset;
    }

    void OnGUI() {

        // get position of player on viewport of minimapcamera
        objPosition = minimapCamera.WorldToViewportPoint(transform.position);

        // get viewing angle of player
        angleView = targetToFollow.transform.eulerAngles.y - 90;
        Matrix4x4 guiRot = GUI.matrix;

        positionEnemy1 = minimapCamera.WorldToViewportPoint(enemy1.transform.position);
        centerEnemy.x = Screen.width * (minimapCamera.rect.x + (positionEnemy1.x * minimapCamera.rect.width)); 
        centerEnemy.y = Screen.height * (1 - (minimapCamera.rect.y + (positionEnemy1.y * minimapCamera.rect.height))); 
        
        if((positionEnemy1.x < 1 && positionEnemy1.x > 0) && (positionEnemy1.y < 1 && positionEnemy1.y > 0))
            GUI.DrawTexture(new Rect(centerEnemy.x, centerEnemy.y, 15, 15), textureEnemy);


        // get the center position of the player to place texture and rotate the texture later 
        centerPlayer.x = Screen.width * (minimapCamera.rect.x + (objPosition.x * minimapCamera.rect.width)) + 5;
        centerPlayer.y = Screen.height * (1 - (minimapCamera.rect.y + (objPosition.y * minimapCamera.rect.height)));

        GUIUtility.RotateAroundPivot(angleView, centerPlayer);

        // position the texture of player on minimap 
        float xMini = (float)(Screen.width * (minimapCamera.rect.x + (objPosition.x * minimapCamera.rect.width)) - 7.5);
        float yMini = (float)(Screen.height * (1 - (minimapCamera.rect.y + (objPosition.y * minimapCamera.rect.height))) - 7.5);
        GUI.DrawTexture(new Rect(xMini, yMini, 45, 45), texturePlayer);
        
        //GUI.matrix = guiRot;
        //onwillrenderobject
    }
}


