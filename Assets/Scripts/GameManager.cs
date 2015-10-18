using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public bool isGameOver = false;
    public float delay = 2.0f;
    public GameObject prefab;
    public GameObject prefabs;

    float totalTime = 0;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (totalTime > delay)
        {
            if (Random.Range(0, 3) == 1)
            {
                Instantiate(prefabs, transform.position, transform.rotation);
            }
            else
            {
                // プレハブからインスタンスを生成
                Instantiate(prefab, transform.position, transform.rotation);
            }
            totalTime = 0;
            Debug.Log("Box Create!!");
            delay = Random.Range(1, 4);
        }
        else
        {
            totalTime += Time.deltaTime;
        }
	}
}
