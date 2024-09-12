using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarObjeto : MonoBehaviour
{
	// Objeto que se activará
	public GameObject objetoAActivar;

	// Tiempo en segundos para activar el objeto
	public float tiempoDeEspera = 5f;

	void Start()
	{
		// Inicia el temporizador para activar el objeto después de cierto tiempo
		Invoke("Activar", tiempoDeEspera);
	}

	void Activar()
	{
		// Activa el objeto especificado
		objetoAActivar.SetActive(true);
	}
}
