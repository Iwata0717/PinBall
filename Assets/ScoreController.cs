using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
	//ターゲットのスコア
	private int score = 0;

	//合計スコア
	private static int totalScore = 0;

	//合計スコアを表示するテキスト
	private static Text totalScoreText;

	// Start is called before the first frame update
	void Start()
	{
		totalScoreText = GameObject.Find("Value").GetComponent<Text>();
		totalScoreText.text = "" + totalScore;

		// タグで得られるスコアを変える
		if (tag == "SmallStarTag")
		{
			score = 10;
		}
		else if (tag == "LargeStarTag")
		{
			score = 20;
		}
		else if (tag == "SmallCloudTag")
		{
			score = 30;
		}
		else if (tag == "LargeCloudTag")
		{
			score = 40;
		}
	}

	//衝突時に呼ばれる関数
	void OnCollisionEnter(Collision other)
	{
		// ボール以外だったら抜ける
		if (other.transform.tag != "BallTag") return;

		totalScore += score;
		totalScoreText.text = "" + totalScore;
	}
}
