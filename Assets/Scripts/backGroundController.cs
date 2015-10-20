using UnityEngine;
using System.Collections;

public class backGroundController : MonoBehaviour {
    public GameObject backGround;

	// Use this for initialization
	void Start () {
        //backGround = GameObject.Find("background");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("onTriggerEnter");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("onTriggerEnter");
        if(col.gameObject.tag == "backGround")
        {
            Debug.Log("backGround Enter");
            GameObject.Instantiate(backGround
                ,col.gameObject.transform.position+(new Vector3(((BoxCollider2D)col).size.x*col.gameObject.transform.localScale.x, 0f, 0f))
                ,col.transform.rotation);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "backGround")
        {
            Debug.Log("bacGround Exit");
            GameObject.Destroy(col.gameObject);
        }
    }
}
