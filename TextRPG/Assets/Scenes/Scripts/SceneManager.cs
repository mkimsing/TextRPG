using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextRPG;

public class SceneManager : MonoBehaviour
{

    //Manager for variables and references to commonly accessed objects in the game

    public Player player;
    public JournalMessages messages;


    public static SceneManager Instance { get; private set; }
    private void Awake()
    {
        //Ensure singleton
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
        {
            Instance = this;
        }

        // Cache references to variables
        GameObject ThePlayer = GameObject.Find("Player");

        player = ThePlayer.GetComponent<Player>();
        messages = ThePlayer.GetComponent<JournalMessages>();
    }
}
