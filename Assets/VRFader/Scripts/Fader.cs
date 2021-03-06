﻿using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour {

	[SerializeField]
	private GameObject FaderObject;

	[HideInInspector]
	public Fade Fade;

	public bool IsFading {
		get {
			return Fade.IsFading;
		}
	}

	private GameObject m_FaderObjectInstance;

	// Use this for initialization
	void Awake () {
		Debug.Log("Awake a fader.");

		Setup();
	}

	void Setup() {
		Debug.Log("Fader set up.");

		m_FaderObjectInstance = Instantiate(FaderObject, gameObject.transform.position, Quaternion.identity) as GameObject;
		m_FaderObjectInstance.transform.parent = gameObject.transform;
		m_FaderObjectInstance.SetActive(false);
		Fade = m_FaderObjectInstance.GetComponent<Fade>();
		Fade.OnFadeEnd += fadeEndHandler;
	}

	public void FadeIn() {
		Debug.Log("Start fade in.");

		m_FaderObjectInstance.SetActive(true);
		Fade.FadeIn();
	}

	public void FadeOut() {
		Debug.Log("Start fade out.");

		m_FaderObjectInstance.SetActive(true);
		Fade.FadeOut();
	}
	
	void fadeEndHandler() {
		Debug.Log("Perfrom fade end handler.");

		m_FaderObjectInstance.SetActive(false);
	}
}
