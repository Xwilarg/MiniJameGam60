using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniJameGam.Menu
{
    public class MenuManager : MonoBehaviour
    {
        public void Play()
        {
            SceneManager.LoadScene("Main");
        }
    }
}
