using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mono.Data.Sqlite;
using System.Data;

public class DBConnection : MonoBehaviour
{
    
    private void Start()
    {
        SQLiteConnection sqlite = new SQLiteConnection();
        
        string sql = "SELECT * FROM tbl_items";

        IDataReader reader = sqlite.ExecuteReader(sql);

        while (reader.Read())
        {
            int itemId = reader.GetInt32(0);
            int itemTypeId = reader.GetInt32(1);
            string itemName = reader.GetString(2);
            string itemImg = reader.GetString(3);
            int itemMaxStack = reader.GetInt16(4);
            int itemAttackUp = reader.GetInt16(5);
            int itemDefUp = reader.GetInt16(6);
            int itemHpUp = reader.GetInt16(7);
            int itemManaUp = reader.GetInt16(8);

            Debug.Log("Item ID: " + itemId +
                " Item Type ID: " + itemTypeId +
                " Item Name: " + itemName +
                " Item Image: " + itemImg +
                " Item Max Stack: " + itemMaxStack +
                " Item Attack Up: " + itemAttackUp +
                " Item Def Up: " + itemDefUp +
                " Item HP Up: " + itemHpUp +
                " Item Mana Up: " + itemManaUp);

        }

        sqlite.CloseReader(reader);
        sqlite.CloseDBConnection();
    }

    
}
