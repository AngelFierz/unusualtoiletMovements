using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
	public float shakeMagnitude = 0.7f; // Magnitud del temblor
	public float shakeDuration = 0.5f; // Duración del temblor
	public float timeUntilShake = 10.0f; // Tiempo hasta que comience el temblor

	private Vector3 originalPosition; // Posición original de la cámara
	private bool isShaking = false; // Indicador de si la cámara está temblando
	private float shakeTimer = 0.0f; // Temporizador para el temblor
	private float timer = 0.0f; // Temporizador para iniciar el temblor

	void Start()
	{
		originalPosition = transform.localPosition; // Almacenar la posición original de la cámara
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
			transform.localPosition = originalPosition; // Restaurar la posición original de la cámara
			isShaking = false;
		}
	}
}
