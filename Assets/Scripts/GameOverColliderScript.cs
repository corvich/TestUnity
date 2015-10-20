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
            Debug.Log("Box trigger");
            GameObject.Destroy(col.gameObject.transform.root.gameObject);
            GameObject.Destroy(col.gameObject);
        }
    }
}
