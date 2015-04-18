using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public abstract class Dialogue : MonoBehaviour
{
    public Actor Player;
    public Actor Npc;

    protected Coroutine End()
    {
        return StartCoroutine( WaitAndEnd() );
    }

    IEnumerator WaitAndEnd()
    {
        // TODO: Fix this clusterfuck
        yield return WaitForInput();
        yield return WaitForInput();
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

    //private Action primaryNode;
    //private List<NamedAction> charismaNodes = new List<NamedAction>();
    //private List<NamedAction> IntimidateNodes = new List<NamedAction>();
    //private List<NamedAction> IntelligenceNodes = new List<NamedAction>();
    //private List<NamedAction> ChatNodes = new List<NamedAction>();

    protected abstract void StartNode();

    void OnMouseDown()
    {
        BeginConversation();
    }

    void BeginConversation()
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
        Player.speechBubble.ShowButton( new DialogueAction( "Charisma", ShowCharismaOptions ) );
        Player.speechBubble.ShowButton( new DialogueAction( "Intimidate", ShowIntimidateOptions ) );
        Player.speechBubble.ShowButton( new DialogueAction( "Intelligence", ShowIntelligenceOptions ) );
        Player.speechBubble.ShowButton( new DialogueAction( "Chat", ShowChatOptions ) );
        yield break;
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

    protected abstract IEnumerable<DialogueAction> CharismaOptions();
    protected abstract IEnumerable<DialogueAction> IntimidationOptions();
    protected abstract IEnumerable<DialogueAction> IntelligenceOptions();
    protected abstract IEnumerable<DialogueAction> ChatOptions();
}

public class DialogueNode
{
    public string name;
    public Action action;
}