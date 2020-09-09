using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Sound menuSound;


    void Start()
    {
        AudioManager.Instance.PlaySound(menuSound);
    }
}
