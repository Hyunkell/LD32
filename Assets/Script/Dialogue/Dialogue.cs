using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public abstract class Dialogue : MonoBehaviour
{
    public Actor Player;
    public Actor Npc;

    protected abstract bool HasCharismaOptions { get; }
    protected abstract bool HasIntimidationOptions { get; }
    protected abstract bool HasIntelligenceOptions { get; }
    protected abstract bool HasChatOptions { get; }

    protected abstract void StartNode();
    protected abstract IEnumerable<DialogueAction> CharismaOptions();
    protected abstract IEnumerable<DialogueAction> IntimidationOptions();
    protected abstract IEnumerable<DialogueAction> IntelligenceOptions();
    protected abstract IEnumerable<DialogueAction> ChatOptions();

    protected Coroutine End()
    {
        return StartCoroutine( WaitAndEnd() );
    }

    IEnumerator WaitAndEnd()
    {
        // TODO: Fix this clusterfuck
        yield return WaitForInput();
        yield return WaitForInput();
        Npc.speechBubble.Clear();

        // Check if we need to move to the next scene
        if( Npc.affinity >= 50.0f )
        {
            GameObject.FindObjectOfType<SceneSelection>().LoadNextScene();
            Player.speechBubble.Clear();
            Player.speechBubble.Hide();
            Player.GetComponent<Movement>().enabled = true;
        }
        else
            ShowCategoryOptions().MoveNext();
    }

    protected Coroutine WaitForInput()
    {
        return StartCoroutine( WaitForSpaceKey() );
    }

    IEnumerator WaitForSpaceKey()
    {
        while( !( Input.GetKeyDown( KeyCode.Space ) || Input.GetMouseButtonDown( 0 ) ) )
            yield return null;
    }

    void OnMouseDown()
    {
        BeginDialogue();
    }

    public void BeginDialogue()
    {
        //Player.speechBubble.gameObject.SetActive( true );
        Npc.speechBubble.gameObject.SetActive( true );

        StartNode();
        ShowCategoryOptions().MoveNext();
    }

    protected IEnumerator ShowCategoryOptions()
    {
        Player.speechBubble.gameObject.SetActive( true );
        Player.speechBubble.Clear();
        if( HasCharismaOptions )
            ShowDialogueOption( "Charisma", ShowCharismaOptions );
        if( HasIntimidationOptions )
            ShowDialogueOption( "Intimidate", ShowIntimidateOptions );
        if( HasIntelligenceOptions )
            ShowDialogueOption( "Intelligence", ShowIntelligenceOptions );
        if( HasChatOptions )
            ShowDialogueOption( "Chat", ShowChatOptions );
        yield break;
    }

    protected void ClearPlayerDialogue()
    {
        Player.speechBubble.Clear();
    }

    protected void ShowDialogueOption( string name, Func<IEnumerator> action )
    {
        Player.speechBubble.ShowButton( new DialogueAction( name, action ) );
    }

    IEnumerator ShowCharismaOptions()
    {
        Player.speechBubble.gameObject.SetActive( true );
        Player.speechBubble.Clear();
        foreach( var option in CharismaOptions() )
            Player.speechBubble.ShowButton( option );
        Player.speechBubble.ShowButton( new DialogueAction( "Back", ShowCategoryOptions ) );
        yield break;
    }

    IEnumerator ShowIntimidateOptions()
    {
        Player.speechBubble.gameObject.SetActive( true );
        Player.speechBubble.Clear();
        foreach( var option in IntimidationOptions() )
            Player.speechBubble.ShowButton( option );
        Player.speechBubble.ShowButton( new DialogueAction( "Back", ShowCategoryOptions ) );
        yield break;
    }

    IEnumerator ShowIntelligenceOptions()
    {
        Player.speechBubble.gameObject.SetActive( true );
        Player.speechBubble.Clear();
        foreach( var option in IntelligenceOptions() )
            Player.speechBubble.ShowButton( option );
        Player.speechBubble.ShowButton( new DialogueAction( "Back", ShowCategoryOptions ) );
        yield break;
    }

    IEnumerator ShowChatOptions()
    {
        Player.speechBubble.gameObject.SetActive( true );
        Player.speechBubble.Clear();
        foreach( var option in ChatOptions() )
            Player.speechBubble.ShowButton( option );
        Player.speechBubble.ShowButton( new DialogueAction( "Back", ShowCategoryOptions ) );
        yield break;
    }

    protected void PlaySound( string fileName )
    {

    }

    protected bool HasHappend( string key )
    {
        return this.Npc.HasHappend( key ) || this.Player.HasHappend( key );
    }
}

public class DialogueNode
{
    public string name;
    public Action action;
}