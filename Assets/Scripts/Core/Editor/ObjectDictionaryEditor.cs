using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

    public abstract class ObjectDictionaryEditor<TKey, TValue> : UnityEditor.Editor
        where TKey : UnityEngine.Object
        where TValue : UnityEngine.Object
    {
        ObjectDictionary<TKey, TValue> store;

        TKey newKey;
        TValue newValue;

        SerializedProperty keysProperty;
        SerializedProperty valuesProperty;

        protected const int buttonWidth = 20;

        void OnEnable()
        {
            store = (ObjectDictionary<TKey, TValue>)target;

            keysProperty = serializedObject.FindProperty("keys");
            valuesProperty = serializedObject.FindProperty("values");
        }

        public override void OnInspectorGUI()
        {
            bool added = false;
            bool removed = false;
            serializedObject.Update();
            removed = ListDictionary();
            added   = DrawAddField();
            serializedObject.ApplyModifiedProperties();

            if (added || removed)
            {
                store.Dirty();
            }
        }

        private bool ListDictionary()
        {
            bool removed = false;
            EditorGUILayout.BeginVertical(GUI.skin.box);
            GUILayout.Label("Pairs: " + keysProperty.arraySize, EditorStyles.boldLabel);
            DrawKeyValueHeader();
            for (int i = 0; i < keysProperty.arraySize; i++)
            {
                removed = (removed || DrawKeyValuePair(keysProperty.GetArrayElementAtIndex(i), valuesProperty.GetArrayElementAtIndex(i), i));
            }

            EditorGUILayout.EndVertical();

            return removed;
        }

        protected virtual void DrawKeyValueHeader()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Key");
            GUILayout.Label("Value");
            GUILayout.Space(buttonWidth);
            EditorGUILayout.EndHorizontal();
        }

        protected virtual bool DrawKeyValuePair(SerializedProperty key, SerializedProperty value, int idx)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(key, new GUIContent(), GUILayout.ExpandWidth(true));
            EditorGUILayout.PropertyField(value, new GUIContent(), GUILayout.ExpandWidth(true));
            bool removed = DrawRemoveButton(idx);
            EditorGUILayout.EndHorizontal();

            return removed;
        }

        protected bool DrawRemoveButton(int idx)
        {
            if (GUILayout.Button("-", GUILayout.Width(buttonWidth), GUILayout.Height(15)))
            {
                keysProperty.EXT_RemoveFromObjectArrayAt(idx);
                valuesProperty.EXT_RemoveFromObjectArrayAt(idx);
                return true;
            }

            return false;
        }

        private bool DrawAddField()
        {
            bool added = false;
            EditorGUILayout.BeginVertical(GUI.skin.box);
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Key");
            GUILayout.Label("Value");
            GUILayout.Space(buttonWidth);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            newKey = (TKey)EditorGUILayout.ObjectField(newKey, typeof(TKey), false, GUILayout.ExpandWidth(true));
            newValue = (TValue)EditorGUILayout.ObjectField(newValue, typeof(TValue), false, GUILayout.ExpandWidth(true));

            if (GUILayout.Button("+", GUILayout.Width(buttonWidth), GUILayout.Height(15)))
            {
                if (newKey && newValue)
                {
                    if (store.ContainsKey(newKey))
                        Debug.LogError("Dictionary contains already a key with value " + newKey);
                    else
                    {
                        keysProperty.EXT_AddToObjectArray<TKey>(newKey);
                        valuesProperty.EXT_AddToObjectArray<TValue>(newValue);
                        added = true;
                    }
                }
            }

            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();
            return added;
        }
    }