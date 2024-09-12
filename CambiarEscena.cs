using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
	public int indiceDeEscena = 0; // Indice de la escena a la que quieres cambiar

	public void CambiarEscenaOnClick()
	{
		SceneManager.LoadScene(indiceDeEscena);
	}
}
