using UnityEngine;
using System.Collections;

public class BoxScript : MonoBehaviour {
    public float speed = 0;
    bool setti = false;
    GameObject node;
    GameManager gameManager = null;
    //Rigidbody2D rigidbody2D;

    // Use this for initialization
    void Start () {
        node = null;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (gameManager.isGameOver)
        {
            return;
        }
        if (setti)
        {
            transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f);
        }
        else if (node != null)
        {
            //transform.position = new Vector3(node.transform.position.x, transform.position.y, 0.0f);
            //transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f);
            transform.Translate(node.GetComponent<BoxScript>().speed * Time.deltaTime, 0.0f, 0.0f);
        }
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("<Box> Enter");
        if (col.gameObject.name == "Road")
        {
            setti = true;
            node = null;
        }
        else if (col.gameObject.tag == "Box")
        {
            Debug.Log("node");
            node = col.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("Collision Exit Box!!"+ col.gameObject.name);
        if (col.gameObject.name == "GameOverCollider")
        {
            Debug.Log("Destroy Box");
            //GameObject.Destroy(this);
        }   
    }
}
