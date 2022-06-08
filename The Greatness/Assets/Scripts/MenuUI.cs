using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            SceneManager.LoadScene("Game");
        }
    }
}
