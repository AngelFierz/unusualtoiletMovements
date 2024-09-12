using UnityEngine;
using UnityEngine.UI;

public class ToggleUIVisibility : MonoBehaviour
{
	public Button toggleButton; // El botón que será clickeado
	public GameObject targetObject; // El objeto que será mostrado/ocultado

	private bool isVisible = false; // Estado inicial de visibilidad del objeto

	void Start()
	{
		// Asegurarse de que el botón y el objeto objetivo están asignados
		if (toggleButton != null && targetObject != null)
		{
			toggleButton.onClick.AddListener(ToggleVisibility); // Añadir el listener al botón
		}
		else
		{
			Debug.LogError("ToggleButton or TargetObject is not assigned in the inspector.");
		}
	}

	// Función que se llamará al presionar el botón
	void ToggleVisibility()
	{
		isVisible = !isVisible; // Alternar el estado de visibilidad
		targetObject.SetActive(isVisible); // Establecer la visibilidad del objeto
	}
}
