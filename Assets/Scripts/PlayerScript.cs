using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    public float jump = 0;
    public GameObject box;
    public float speed = 0;

    public bool jumpFlag = false;
    public bool setti = true;
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
        if (Input.GetButtonDown("Fire1") && (jumpFlag || setti))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jump));
            Debug.Log("Jump!!");
        }
        if (box != null)
        {
            //transform.Translate(box.GetComponent<BoxScript>().speed * Time.deltaTime, 0.0f, 0.0f);
            transform.Translate((box.GetComponent<BoxScript>().speed+speed) * Time.deltaTime, 0.0f, 0.0f);
        }
	}

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Box" || col.gameObject.name == "Road")
        {
            jumpFlag = false;
        }
        if (col.gameObject.tag == "Box")
        {
            box = null;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        
        if (col.gameObject.tag == "Box")
        {
            jumpFlag = true;
            Debug.Log("Player Box Enter");
            box = col.gameObject;
        }
        else if(col.gameObject.name == "Road")
        {
            jumpFlag = true;
            Debug.Log("Road Enter");
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        else if(col.gameObject.tag == "Togetoge")
        {
            jumpFlag = false;
            Debug.Log("Togetoge Enter");
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "GameOver")
        {
            gameManager.isGameOver = true;
            //Application.LoadLevel(Application.loadedLevelName);
        }
        else if(col.gameObject.name == "Road" || col.gameObject.tag == "Box")
        {
            setti = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.name == "Road" || col.gameObject.tag == "Box")
        {
            setti = false;
        }
    }
}
