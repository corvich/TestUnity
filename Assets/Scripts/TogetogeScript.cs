using UnityEngine;
using System.Collections;

public class TogetogeScript : MonoBehaviour {

    public float rotateSpeed=0;
    public float speed = 0;

    Rigidbody2D player;
    GameManager gameManager;
    PlayerScript playerScript;
    bool setti = false;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (gameManager.isGameOver)
        {
            GetComponent<Rigidbody2D>().Sleep();
            return;
        }
        if (setti)
        {
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Togetoge Enter");
        if(col.gameObject.tag== "Player")
        {
            Vector3 temp = col.transform.position - transform.position;
            temp.Normalize();
            temp *= 40;
            player.AddForce(new Vector2(temp.x, temp.y));
            //playerScript.jumpFlag = false;
        }
        else if(col.gameObject.name == "Road")
        {
            setti = true;
        }
    }
}
