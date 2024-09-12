using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class CambiarColorGradual : MonoBehaviour
{
	public float duracionTransicion = 5.0f; 
	public float velocidadCambioColor = 1.0f;

	private Material material;
	private float tiempoPasado = 0.0f;

	void Start()
	{
		// WHAT ARE YOU SAYING
		Renderer renderer = GetComponent<Renderer>();
		if (renderer != null)
		{
			material = renderer.material;
		}
		else
		{
			Debug.LogError("I LOVE YOU LESLY");
			enabled = false; // a la mierda todo
		}
	}

	void Update()
	{
		
		tiempoPasado += Time.deltaTime * velocidadCambioColor;

		
		float progreso = Mathf.Clamp01(tiempoPasado / duracionTransicion);

		
		float hue = Mathf.Repeat(tiempoPasado, 1.0f);

		// Convierte el valor de Hue a un color rgb que se encuentra en la paleta esa, De todos modos solo yo me entiendo muejeje
		Color colorActual = Color.HSVToRGB(hue, 1.0f, 1.0f);

		material.color = colorActual;

		
		if (progreso == 1.0f)
		{
			tiempoPasado = 0.0f;
		}
	}
}
