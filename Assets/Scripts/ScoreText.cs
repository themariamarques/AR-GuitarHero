using UnityEngine;
using System.Collections;

public class ScoreText : MonoBehaviour {
    
    public GameObject score;
    public int score_value;

    void Start ()
    {
        score_value = 0;
    }

	public void AddScore()
    {
        score_value += 10;
    }
	
	// Update is called once per frame
	void Update () {
        score.GetComponent<TextMesh>().text = score_value.ToString();
	}
}
