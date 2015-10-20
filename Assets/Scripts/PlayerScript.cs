using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    public float jump = 0;
    public GameObject box;
    public float speed = 0;

    bool jumpFlag = false;
    bool onBox = false;

    GameManager gameManager = null;
    Animator animator = null;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        animator = GameObject.Find("Player").GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (gameManager.isGameOver)
        {
            animator.Stop();
            return;
        }
        if (Input.GetButtonDown("Fire1") && jumpFlag)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jump));
        }
        if (box != null)
        {
            //transform.Translate(box.GetComponent<BoxScript>().speed * Time.deltaTime, 0.0f, 0.0f);
            transform.Translate((box.GetComponent<BoxScript>().speed+speed) * Time.deltaTime, 0.0f, 0.0f);
        }
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        jumpFlag = true;
        if (col.gameObject.tag == "Box")
        {
            box = col.gameObject;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        jumpFlag = false;
        if (col.gameObject.tag == "Box")
        {
            box = null;
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "GameOver")
        {
            gameManager.isGameOver = true;
            //Application.LoadLevel(Application.loadedLevelName);
        }
    }
}
