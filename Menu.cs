using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject player;
    public void Save()
    {
        Vector3 vector = player.transform.position;
        int health = player.GetComponent<PlayerController>().GetHealth();
        int crystal = player.GetComponent<PlayerMove>().GetCrystal();
        //float time = 
        if (health > 0)
        {
            PlayerPrefs.SetFloat("playerX", vector.x);
            PlayerPrefs.SetFloat("playerY", vector.y);
            PlayerPrefs.SetFloat("playerZ", vector.z);
            PlayerPrefs.SetInt("health", health);
            PlayerPrefs.SetInt("crystal", crystal);
            PlayerPrefs.Save();
        }
    }
    public void Reset()
    {
        Vector3 vector = new Vector3(271, 2.31f, 296.572f);
        PlayerPrefs.SetFloat("playerX", vector.x);
        PlayerPrefs.SetFloat("playerY", vector.y);
        PlayerPrefs.SetFloat("playerZ", vector.z);
        PlayerPrefs.SetInt("health", 100);
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        player.GetComponent<PlayerController>().ChangeHealth(PlayerPrefs.GetInt("health"));
    }
    public void Load()
    {
        if (PlayerPrefs.HasKey("playerX"))
        {
            float x = PlayerPrefs.GetFloat("playerX");
            float y = PlayerPrefs.GetFloat("playerY");
            float z = PlayerPrefs.GetFloat("playerZ");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            transform.position = new Vector3(x, y, z);
            player.GetComponent<PlayerController>().ChangeHealth(PlayerPrefs.GetInt("health"));
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ObAuthor()
    {
        SceneManager.LoadScene(2);
    }
}
