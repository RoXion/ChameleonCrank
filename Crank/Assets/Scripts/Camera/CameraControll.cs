using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour {


    private bool lockedonPlayer;
	private Vector3 offset;

    public GameObject player;

	// Use this for initialization
	void Start () {
        lockedonPlayer = false;
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {

        if (!lockedonPlayer)
        {
            offset = transform.position - player.transform.position;

            if (offset.x >0 -0.1f && offset.x <= 0.1f)
            {
                lockedonPlayer = true;
            }
        }
        else
        {
            moveCamera();
        }
	}

    void moveCamera()
    {
        gameObject.transform.position = new Vector3(player.gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }
}
