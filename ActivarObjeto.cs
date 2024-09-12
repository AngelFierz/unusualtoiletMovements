using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarObjeto : MonoBehaviour
{

	public GameObject objetoAActivar;


	public float tiempoDeEspera = 5f;

	void Start()
	{
		
		Invoke("Activar", tiempoDeEspera);
	}

	void Activar()
	{
		
		objetoAActivar.SetActive(true);
	}
}
// I DONT WANNA BE, I DONT WANNA BE ME, I DONT WANNA BE, ME ANYMORE, 1 2 3 4
