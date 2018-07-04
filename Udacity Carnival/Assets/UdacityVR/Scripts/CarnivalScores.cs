using System;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CarnivalScores : MonoBehaviour {

	[SerializeField]
	private int TeddyBearPointsMin = 2000;

	[SerializeField]
	private GameObject TeddyBear;

	[SerializeField]
	private TextMeshPro plinkoScore;
	[SerializeField]
	private TextMeshPro wheelScore;
	[SerializeField]
	private TextMeshPro coinScore;

	public static CarnivalScores Instance;

	private int plinkoPoints;
	private int wheelPoints;
	private int coinPoints;

	void Awake() {
		if (Instance == null)
			Instance = this;

		TeddyBear.SetActive(false);
	}

	void OnDestroy() {
		if (Instance = this)
			Instance = null;
	}

	// Update is called once per frame
	void Update () {
		plinkoScore.text = "Plinko: " + plinkoPoints.ToString("0000");
		wheelScore.text = "Wheel: " + wheelPoints.ToString("0000");
		coinScore.text = "Coins: " + coinPoints.ToString("0000");

		if (plinkoPoints + wheelPoints + coinPoints >= TeddyBearPointsMin) {
			TeddyBear.SetActive(true);
			//OsamaNsr:: starting the coroutine
			StartCoroutine(ReloadTheCurrentScene());
		}
	}

	public void IncrementPlinkoScore(float points) {
		plinkoPoints += (int) points;
	}

	public void IncrementWheelScore(float points) {
		wheelPoints += (int) points;
	}

	public void IncrementCoinScore() {
		coinPoints += 1000;
	}

	// edit starts
	//OsamaNsr:: this part makes the level reload after 5 seconds from wining the game
	//           it's called directly after showing the Teddy Bear 
	private WaitForSeconds delay = new WaitForSeconds(5f);

	private IEnumerator ReloadTheCurrentScene() {
		yield return delay;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	// edit ends
}
