using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public static class SerializedPropertyExtensions
{
    public static void EXT_AddToObjectArray<T> (this SerializedProperty arrayProperty, T elementToAdd)
        where T : Object
    {
        if (!arrayProperty.isArray)
            throw new UnityException("SerializedProperty " + arrayProperty.name + " is not an array.");

        arrayProperty.serializedObject.Update();

        arrayProperty.InsertArrayElementAtIndex(arrayProperty.arraySize);
        arrayProperty.GetArrayElementAtIndex(arrayProperty.arraySize - 1).objectReferenceValue = elementToAdd;
        arrayProperty.serializedObject.ApplyModifiedProperties();
    }

    public static void EXT_AddToStringArray(this SerializedProperty arrayProperty, string textToAdd)
    {
        if (!arrayProperty.isArray)
            throw new UnityException("SerializedProperty " + arrayProperty.name + " is not an array.");

        arrayProperty.serializedObject.Update();
        arrayProperty.InsertArrayElementAtIndex(arrayProperty.arraySize);
        arrayProperty.GetArrayElementAtIndex(arrayProperty.arraySize - 1).stringValue = textToAdd;
        arrayProperty.serializedObject.ApplyModifiedProperties();
    }


    public static void EXT_RemoveFromObjectArrayAt (this SerializedProperty arrayProperty, int index)
    {
        if(index < 0)
            throw new UnityException("SerializedProperty " + arrayProperty.name + " cannot have negative elements removed.");

        if (!arrayProperty.isArray)
            throw new UnityException("SerializedProperty " + arrayProperty.name + " is not an array.");

        arrayProperty.serializedObject.Update();

        if (index > arrayProperty.arraySize - 1)
            throw new UnityException("SerializedProperty " + arrayProperty.name + " has only " + arrayProperty.arraySize + " elements so element " + index + " cannot be removed.");

        if (arrayProperty.GetArrayElementAtIndex(index).objectReferenceValue)
            arrayProperty.DeleteArrayElementAtIndex(index);
        arrayProperty.DeleteArrayElementAtIndex(index);
        arrayProperty.serializedObject.ApplyModifiedProperties();
    }


    public static void EXT_RemoveFromObjectArray<T> (this SerializedProperty arrayProperty, T elementToRemove)
        where T : Object
    {
        if (!arrayProperty.isArray)
            throw new UnityException("SerializedProperty " + arrayProperty.name + " is not an array.");

        if(!elementToRemove)
            throw new UnityException("Removing a null element is not supported using this method.");

        arrayProperty.serializedObject.Update();

        for (int i = 0; i < arrayProperty.arraySize; i++)
        {
            SerializedProperty elementProperty = arrayProperty.GetArrayElementAtIndex(i);

            if (elementProperty.objectReferenceValue == elementToRemove)
            {
                arrayProperty.EXT_RemoveFromObjectArrayAt (i);
                return;
            }
        }

        throw new UnityException("Element " + elementToRemove.name + "was not found in property " + arrayProperty.name);
    }

    public static IEnumerable<SerializedProperty> EXT_GetChildren(this SerializedProperty property)
    {
        property = property.Copy();
        var nextElement = property.Copy();
        bool hasNextElement = nextElement.NextVisible(false);
        if (!hasNextElement)
        {
            nextElement = null;
        }

        property.NextVisible(true);
        while (true)
        {
            if ((SerializedProperty.EqualContents(property, nextElement)))
            {
                yield break;
            }

            yield return property;

            bool hasNext = property.NextVisible(false);
            if (!hasNext)
            {
                break;
            }
        }
    }
}
