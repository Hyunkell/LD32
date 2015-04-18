using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class NamedAction
{
    public string text;
    public Action action;

    public NamedAction( string buttonText, Action buttonAction )
    {
        this.text = buttonText;
        this.action = buttonAction;
    }
}

public class SpeechBubble : MonoBehaviour
{
    public GameObject textMode;
    public GameObject buttonMode;
    public UnityEngine.UI.Text uiText;

    public void ShowText( params string[] text )
    {
        textMode.SetActive( true );
        buttonMode.SetActive( false );

        var sb = new System.Text.StringBuilder();
        //sb.AppendLine( name + ":" );
        foreach( var line in text )
            sb.AppendLine( line );
        uiText.text = sb.ToString();
    }

    public void Clear()
    {
        for( int i = 0; i < buttonMode.transform.childCount; i++ )
        {
            GameObject.Destroy( buttonMode.transform.GetChild( i ).gameObject );
        }
    }

    public void ShowButton( NamedAction namedAction )
    {
        textMode.SetActive( false );
        buttonMode.SetActive( true );

        var button = Prefab.CreateInstance( "DialogueButton", buttonMode );
        var buttonText = button.GetComponentInChildren<UnityEngine.UI.Text>();
        Debug.Log( button );
        Debug.Log( buttonText );
        buttonText.text = namedAction.text;
        button.GetComponent<UnityEngine.UI.Button>().onClick.AddListener( () => namedAction.action() );
    }

    /*
    public void ShowButtons( List<NamedAction> buttons )
    {
        textMode.SetActive( false );
        buttonMode.SetActive( true );

        // Clear existing buttons
        for( int i = 0; i < buttonMode.transform.childCount; i++ )
        {
            GameObject.Destroy( buttonMode.transform.GetChild( i ).gameObject );
        }

        // Create new buttons
        foreach( var buttonAction in buttons )
        {
            var button = Prefab.CreateInstance( "DialogueButton", buttonMode );
            var buttonText = button.GetComponentInChildren<UnityEngine.UI.Text>();
            var captureButtonAction = buttonAction;
            buttonText.text = buttonAction.text;
            button.GetComponent<UnityEngine.UI.Button>().onClick.AddListener( () => captureButtonAction.action() );
        }
    }
    */
    public void Hide()
    {
        textMode.SetActive( false );
        buttonMode.SetActive( false );
    }
}

