using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneControllerSide : MonoBehaviour
{
    public PlayerControllerSide player;
    public Camera gameCamera;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameCamera.transform.position = new Vector3(player.transform.position.x, gameCamera.transform.position.y, gameCamera.transform.position.z);
    }
}
