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
            if (Instance != null && Instance != this)
                Destroy(this.gameObject);
            else
                Instance = this;
        }

        public void Log(string text)
        {
            logText.text += text + "\n";

        }
    }
}
