using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
    public bool isGameOver = false;
    public float delay = 2.0f;
    public GameObject prefab;
    public GameObject prefabs;
    public GameObject togetoge;
    public bool isDebug = false;

    float score = 0f;

    Text gameOverText;
    Text continueText;
    Text scoreText;
    Rigidbody2D player;
    PlayerScript playerScript;

    float totalTime = 0;
	// Use this for initialization
	void Start () {
        (gameOverText = GameObject.Find("GameOverText").GetComponent<Text>()).enabled = false;
        (continueText = GameObject.Find("Text").GetComponent<Text>()).enabled = false;
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
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
        score += playerScript.speed * Time.deltaTime;
        scoreText.text = "Score " + (int)score + " m";

        if (!isDebug && totalTime > delay)
        {
            int ram = Random.Range(0, 3);
            if (ram == 1)
            {
                Instantiate(prefabs, transform.position, transform.rotation);
            }
            else if(ram == 2)
            {
                Instantiate(togetoge, transform.position, transform.rotation);
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
