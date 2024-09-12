using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
	public float timeUntilFadeOut = 60f; // Tiempo en segundos hasta el fade-out
	public float fadeDuration = 1.5f; // Duración del fade-out en segundos

	private bool startFadeOut = false;
	private float fadeTimer = 0f;

	void Update()
	{
		// Incrementa el temporizador
		fadeTimer += Time.deltaTime;

		// Si el tiempo alcanza el límite para el fade-out, inicia el fade-out
		if (fadeTimer >= timeUntilFadeOut && !startFadeOut)
		{
			startFadeOut = true;
			BeginFadeOut();
		}

		// Si se ha iniciado el fade-out, realiza el efecto de oscurecimiento
		if (startFadeOut)
		{
			// Calcula el alpha (transparencia) a medida que avanza el fade-out
			float alpha = Mathf.Clamp01(fadeTimer / fadeDuration);

			// Aplica el color negro con la transparencia calculada a toda la pantalla
			ApplyFadeOutEffect(alpha);
		}
	}

	void BeginFadeOut()
	{
		fadeTimer = 0f; // Restablece el temporizador al comenzar el fade-out
	}

	void ApplyFadeOutEffect(float alpha)
	{
		// Obtén la referencia al Canvas o crea un nuevo Canvas si no existe
		Canvas canvas = FindObjectOfType<Canvas>();
		if (canvas == null)
		{
			GameObject canvasObject = new GameObject("Canvas");
			canvas = canvasObject.AddComponent<Canvas>();
			canvas.renderMode = RenderMode.ScreenSpaceOverlay;
		}

		// Crea un objeto Image que cubra toda la pantalla
		GameObject fadePanel = new GameObject("FadePanel");
		fadePanel.transform.SetParent(canvas.transform, false);
		RectTransform rectTransform = fadePanel.AddComponent<RectTransform>();
		rectTransform.anchorMin = Vector2.zero;
		rectTransform.anchorMax = Vector2.one;
		rectTransform.sizeDelta = Vector2.zero;

		// Añade un componente Image al objeto y establece su color al negro con la transparencia calculada
		Image image = fadePanel.AddComponent<Image>();
		image.color = new Color(0f, 0f, 0f, alpha);

		// Si el fade-out ha alcanzado su duración máxima, destruye el objeto para limpiar la pantalla
		if (fadeTimer >= fadeDuration)
		{
			Destroy(fadePanel);
		}
	}
}
