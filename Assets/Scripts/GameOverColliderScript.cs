using UnityEngine;
using System.Collections;

public class GameOverColliderScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("Col Collider " + col.gameObject.name);
        if (col.gameObject.tag == "Box")
        {
            Debug.Log("Col trigger");
            GameObject.Destroy(col.gameObject);
        }
        else if(col.gameObject.tag == "Boxs")
        {
            GameObject.Destroy(col.gameObject);
        }
    }
}
