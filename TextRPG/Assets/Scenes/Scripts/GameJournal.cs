using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TextRPG
{
    public class GameJournal : MonoBehaviour
    {
        [SerializeField] Text logText;
    
        public static GameJournal Instance { get; set; }

        void Awake()
        {
            //Ensure singleton
            if (Instance != null && Instance != this)
                Destroy(this.gameObject);
            else
                Instance = this;

            logText.supportRichText = true;
        }

        // Functions to print out the text data
        public void Log(string text)
        {
            logText.text += text + "\n";

        }

    }
}
