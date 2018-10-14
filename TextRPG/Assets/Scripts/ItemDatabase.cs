using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TextRPG
{
    public class ItemDatabase : MonoBehaviour
    {
        public List<string> Items { get; set; } = new List<string>();
        public static  ItemDatabase MyItemDatabase { get; private set; }

        private void Awake()
        {
            //Ensure singleton
            if (MyItemDatabase != null && MyItemDatabase != this)
                Destroy(this.gameObject);
            else
            {
                MyItemDatabase = this;
            }

            Items.Add("Sword");
            Items.Add("Gold Chalice");
            Items.Add("Rubber Chicken");
        }
    }
}
