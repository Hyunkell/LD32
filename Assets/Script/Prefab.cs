using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public static class Prefab
{
    static Dictionary<string, GameObject> prefabs;

    static void LoadAll()
    {
        prefabs = new Dictionary<string, GameObject>();
        foreach( var prefab in Resources.LoadAll<GameObject>( "Prefab" ) )
        {
            prefabs.Add( prefab.name, prefab );
        }
    }

    public static GameObject CreateInstance( string prefabName, Vector3 position )
    {
        var instance = GameObject.Instantiate( prefabs[prefabName] );
        instance.transform.position = position;
        return instance;
    }

    public static GameObject CreateInstance( string prefabName, GameObject parent )
    {
        return CreateInstance( prefabs[prefabName], parent );
    }

    public static GameObject CreateInstance( GameObject prefab, GameObject parent )
    {
        if( prefabs == null )
            LoadAll();

        var instance = GameObject.Instantiate( prefab );
        instance.transform.SetParent( parent.transform, false );
        instance.transform.localScale = new Vector3( 1, 1, 1 );
        return instance;
    }
}