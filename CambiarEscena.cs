using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
	public int indiceDeEscena = 0; 

	public void CambiarEscenaOnClick()
	{
		SceneManager.LoadScene(indiceDeEscena);
	}
}

//I did this thing when listening to Monolith - Twin Tribes
