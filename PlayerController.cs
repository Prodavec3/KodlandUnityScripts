using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //gunAnim.SetTrigger("fire");
    [SerializeField] Text HpText;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject pauseUI;
    bool isPause = false;
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("playerX"))
        {
            float x = PlayerPrefs.GetFloat("playerX");
            float y = PlayerPrefs.GetFloat("playerY");
            float z = PlayerPrefs.GetFloat("playerZ");
            transform.position = new Vector3(x, y, z);
            ChangeHealth(PlayerPrefs.GetInt("health"));
        }
        else
        {
            ChangeHealth(100);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                isPause = false;
                GetComponent<PlayerLook>().enabled = true;
                GetComponent<PlayerMove>().enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                pauseUI.SetActive(false);
            }
            else
            {
                isPause = true;
                GetComponent<PlayerLook>().enabled = false;
                GetComponent<PlayerMove>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
                pauseUI.SetActive(true);
            }
        }
    }
    public void ChangeHealth(int count)
    {
        health = health + count;
        if (health > 100)
        {
            health = 100;
        }
        HpText.text = "Hp: " + health.ToString();
        if (health <= 0)
        {
            gameOver.SetActive(true);
            GetComponent<PlayerLook>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public int GetHealth()
    {
        return health;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "health")
        {
            Destroy(other.gameObject);
            ChangeHealth(50);
        }
    }
}
