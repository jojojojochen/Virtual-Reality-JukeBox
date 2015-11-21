using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

	public GameObject pausePanel; // our pause panel
	public bool isPaused; // our true/false check for pausing
	public Slider volume;
	public float currentVolume = -40.0f;
	public AudioMixer masterMixer;

	// Use this for initialization
	void Start () {
		isPaused = true;
		volume.value = currentVolume;
	}

	// Update is called once per frame
	void Update () {
		if (isPaused) {
			PauseGame (true);
		} else {
			PauseGame (false);
		}
		SetVolume (volume.value);
		if (Input.GetButtonDown ("Cancel")) { // default is escape
			SwitchPause();
		}
	}

	public void SetVolume(float volLevel) {
		currentVolume = volLevel;
		masterMixer.SetFloat ("masterVolume", currentVolume); // set the volume
	}

	void PauseGame(bool state) {
		if (state) {
			Time.timeScale = 0.0f; // stop time
		} else { // unpause the game
			Time.timeScale = 1.0f; // change based on game speed
		}
		pausePanel.SetActive (state); // set game paused state to true if true, pause if paused
	}

	public void SwitchPause() {
		isPaused = !isPaused; // Inverts state of pause
	}
}
