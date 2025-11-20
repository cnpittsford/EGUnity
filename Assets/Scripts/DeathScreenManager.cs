using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenManager : MonoBehaviour
{
    public void Replay() {
        SceneManager.LoadScene("Play");
    }

    public void Menu() {
        SceneManager.LoadScene("Menu");
    }
}
