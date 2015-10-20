using UnityEngine;
using System.Collections;

public class backGroundScript : MonoBehaviour {
    public float speed = 0f;
    GameManager gameManager = null;
    // Use this for initialization
    void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (gameManager.isGameOver)
        {
            return;
        }
        transform.Translate(Time.deltaTime * speed, 0f, 0f);
	}
}
