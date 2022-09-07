using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Colisiones : MonoBehaviour {
	public GameObject Puntuaciones;
	private int puntos=0;
	public AudioClip SonidoCoin;

	void OnTriggerEnter(Collider objeto){
		if (objeto.gameObject.tag== "Rubi") {
			Debug.Log ("Toque Rubi");
			gameObject.GetComponent<AudioSource> ().PlayOneShot (SonidoCoin, 0.7f);
			Destroy (objeto.gameObject);
			puntos++;
			Puntuaciones.GetComponent<Text>().text=puntos.ToString();
		}
	}
}
