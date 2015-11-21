using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class knob : MonoBehaviour {
	float speed = 100.0f;
	public float angle = 45.0f;
	public int song = 0;
	public AudioSource audio;
	public AudioMixerSnapshot[] songPlaying;

	private float m_TransitionIn; // time to fade to static
	private float m_TransitionOut; // time to fade to next song

	// Use this for initialization
	void Start () {
		m_TransitionIn = 2.0f;
		songPlaying[0].TransitionTo (m_TransitionIn); // transition to next song
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Horizontal2")) {
			transform.RotateAround(transform.position, Vector3.right, Input.GetAxisRaw("Horizontal2")*Time.deltaTime*speed);
			angle += Input.GetAxisRaw("Horizontal2")*70*Time.deltaTime;
		}
		angle = angle % 360;
		if (Mathf.Abs (angle) / 90 != song) { // if song needs to change
			song = (int) Mathf.Floor(Mathf.Abs (angle) / 90) % 2;
			songPlaying[song].TransitionTo (m_TransitionIn); // transition to next song

		}
	}

}
