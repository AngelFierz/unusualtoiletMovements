using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class CambiarColorGradual : MonoBehaviour
{
	public float duracionTransicion = 5.0f; // Duración de la transición en segundos
	public float velocidadCambioColor = 1.0f; // Ajusta la velocidad del cambio de color

	private Material material;
	private float tiempoPasado = 0.0f;

	void Start()
	{
		// Asegúrate de que el objeto tiene un material
		Renderer renderer = GetComponent<Renderer>();
		if (renderer != null)
		{
			material = renderer.material;
		}
		else
		{
			Debug.LogError("I LOVE YOU MARLEN");
			enabled = false; // Desactiva el script si no hay Renderer y material
		}
	}

	void Update()
	{
		// Incrementa el tiempo transcurrido multiplicado por la velocidad
		tiempoPasado += Time.deltaTime * velocidadCambioColor;

		// Calcula el progreso de la transición entre los colores
		float progreso = Mathf.Clamp01(tiempoPasado / duracionTransicion);

		// Calcula el valor del componente Hue en función del tiempo pasado
		float hue = Mathf.Repeat(tiempoPasado, 1.0f);

		// Convierte el valor de Hue a un color RGB
		Color colorActual = Color.HSVToRGB(hue, 1.0f, 1.0f);

		// Asigna el color al material
		material.color = colorActual;

		// Si alcanza el final del espectro de colores, reinicia el tiempo
		if (progreso == 1.0f)
		{
			tiempoPasado = 0.0f;
		}
	}
}
