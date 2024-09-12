using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
	public float timeUntilFadeOut = 60f; 
	public float fadeDuration = 1.5f; 

	private bool startFadeOut = false;
	private float fadeTimer = 0f;

	void Update()
	{
		
		fadeTimer += Time.deltaTime;

		if (fadeTimer >= timeUntilFadeOut && !startFadeOut)
		{
			startFadeOut = true;
			BeginFadeOut();
		}

		
		if (startFadeOut)
		{
		
			float alpha = Mathf.Clamp01(fadeTimer / fadeDuration);

			ApplyFadeOutEffect(alpha);
		}
	}

	void BeginFadeOut()
	{
		fadeTimer = 0f; 
	}

	void ApplyFadeOutEffect(float alpha)
	{
		
		Canvas canvas = FindObjectOfType<Canvas>();
		if (canvas == null)
		{
			GameObject canvasObject = new GameObject("Canvas");
			canvas = canvasObject.AddComponent<Canvas>();
			canvas.renderMode = RenderMode.ScreenSpaceOverlay;
		}

		
		GameObject fadePanel = new GameObject("FadePanel");
		fadePanel.transform.SetParent(canvas.transform, false);
		RectTransform rectTransform = fadePanel.AddComponent<RectTransform>();
		rectTransform.anchorMin = Vector2.zero;
		rectTransform.anchorMax = Vector2.one;
		rectTransform.sizeDelta = Vector2.zero;

		
		Image image = fadePanel.AddComponent<Image>();
		image.color = new Color(0f, 0f, 0f, alpha);

		
		if (fadeTimer >= fadeDuration)
		{
			Destroy(fadePanel);
		}
	}
}
