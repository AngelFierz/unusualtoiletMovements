using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
	public float shakeMagnitude = 0.7f; // This shit is broken, i dont know why tho, You will get it when you use it on your camera at Unity
	public float shakeDuration = 0.5f; 
	public float timeUntilShake = 10.0f; 

	private Vector3 originalPosition; 
	private bool isShaking = false; 
	private float shakeTimer = 0.0f; 
	private float timer = 0.0f; 

	void Start()
	{
		originalPosition = transform.localPosition; // Almacena la posicion local
	}

	void Update()
	{
		timer += Time.deltaTime;

		if (!isShaking && timer >= timeUntilShake)
		{
			StartShake();
		}

		if (isShaking)
		{
			ShakeCamera();
		}
	}

	void StartShake()
	{
		isShaking = true;
		shakeTimer = shakeDuration;
	}

	void ShakeCamera()
	{
		if (shakeTimer > 0)
		{
			float offsetX = Random.Range(-shakeMagnitude, shakeMagnitude);
			float offsetY = Random.Range(-shakeMagnitude, shakeMagnitude);
			float offsetZ = Random.Range(-shakeMagnitude, shakeMagnitude);
			transform.localPosition = originalPosition + new Vector3(offsetX, offsetY, offsetZ);
			shakeTimer -= Time.deltaTime;
		}
		else
		{
			transform.localPosition = originalPosition; // Restaurar la posición original de la cámara, lo cual no funciona como tenia en mente.
			isShaking = false;
		}
	}
}
