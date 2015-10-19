using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
    public bool isGameOver = false;
    public float delay = 2.0f;
    public GameObject prefab;
    public GameObject prefabs;
    public bool isDebug = false;

    Text gameOverText;
    Text continueText;
    Rigidbody2D player;

    float totalTime = 0;
	// Use this for initialization
	void Start () {
        (gameOverText = GameObject.Find("GameOverText").GetComponent<Text>()).enabled = false;
        (continueText = GameObject.Find("Text").GetComponent<Text>()).enabled = false;
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isGameOver)
        {
            gameOverText.enabled = true;
            continueText.enabled = true;
            player.Sleep();
            if (Input.GetButtonDown("Fire1"))
            {
                Application.LoadLevel(Application.loadedLevelName);
            }
            return;
        }

        if (!isDebug && totalTime > delay)
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
