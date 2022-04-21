using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiplayerLoad : MonoBehaviour
{
  void Awake()
  {
    SceneManager.LoadScene("Loading");
  }
}
