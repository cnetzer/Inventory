using System;
using CryoInventory;
using CryoInventory.Utility;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR

[CustomEditor(typeof(InventorySystem))]
public class InventorySystemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        InventorySystem inventorySystem = target as InventorySystem;
        if (!inventorySystem) return;
       
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Cryo Inventory", EditorHelper.HeadlineCenter);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Inventory System by @Christoph Netzer", EditorStyles.centeredGreyMiniLabel);
        EditorGUILayout.Space();
        EditorHelper.HorizontalLine();
        GUILayout.Space(15);

        if (inventorySystem.inventory.Slots == Array.Empty<InventorySlot>())
        {
            EditorGUILayout.LabelField("Create Inventory", EditorStyles.boldLabel);
            GUILayout.Space(7.5f);
            EditorGUILayout.LabelField("Settings", EditorStyles.miniLabel);

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Slots");
            inventorySystem.Slots = EditorGUILayout.IntSlider(inventorySystem.Slots, 1, 100);
            EditorGUILayout.EndHorizontal();
            
            GUILayout.Space(15);
            if (GUILayout.Button("Create Inventory", GUILayout.Height(35)))
            {
                inventorySystem.CreateInventory();
            }
        }
        else
        {
            foreach (var slot in inventorySystem.inventory.Slots)
            {
                if (slot.Empty())
                {
                    EditorGUILayout.LabelField("Empty Slot");
                }
                else
                {
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(slot.Item.Data.ItemName, EditorStyles.boldLabel);
                    EditorGUILayout.LabelField(slot.Stack.ToString());
                    EditorGUILayout.EndHorizontal();
                }
                
                GUILayout.Space(5);
            }
            
            GUILayout.Space(10);
            if (GUILayout.Button("Delete Inventory"))
            {
                inventorySystem.DeleteInventory();
            }
            
            base.OnInspectorGUI();
        }
    }
}

#endif