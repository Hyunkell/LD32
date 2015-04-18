using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public abstract class Dialogue : MonoBehaviour
{
    public Actor Player;
    public Actor Npc;

    //private Action primaryNode;
    //private List<NamedAction> charismaNodes = new List<NamedAction>();
    //private List<NamedAction> IntimidateNodes = new List<NamedAction>();
    //private List<NamedAction> IntelligenceNodes = new List<NamedAction>();
    //private List<NamedAction> ChatNodes = new List<NamedAction>();

    protected abstract void StartNode();

    void Start()
    {
        
    }

    void OnMouseDown()
    {
        BeginConversation();
    }

    void BeginConversation()
    {
        //Player.speechBubble.gameObject.SetActive( true );
        Npc.speechBubble.gameObject.SetActive( true );

        StartNode();
        ShowCategoryOptions();
    }

    void ShowCategoryOptions()
    {
        Player.speechBubble.gameObject.SetActive( true );
        Player.speechBubble.Clear();
        Player.speechBubble.ShowButton( new NamedAction( "Charisma", ShowCharismaOptions ) );
        Player.speechBubble.ShowButton( new NamedAction( "Intimidate", ShowIntimidateOptions ) );
        Player.speechBubble.ShowButton( new NamedAction( "Intelligence", ShowIntelligenceOptions ) );
        Player.speechBubble.ShowButton( new NamedAction( "Chat", ShowChatOptions ) );
    }

    void ShowCharismaOptions()
    {
        Player.speechBubble.gameObject.SetActive( true );
        Player.speechBubble.Clear();
        foreach( var option in CharismaOptions() )
            Player.speechBubble.ShowButton( option );
        Player.speechBubble.ShowButton( new NamedAction( "Back", ShowCategoryOptions ) );
    }

    void ShowIntimidateOptions()
    {
        Player.speechBubble.gameObject.SetActive( true );
        Player.speechBubble.Clear();
        foreach( var option in IntimidationOptions() )
            Player.speechBubble.ShowButton( option );
        Player.speechBubble.ShowButton( new NamedAction( "Back", ShowCategoryOptions ) );
    }

    void ShowIntelligenceOptions()
    {
        Player.speechBubble.gameObject.SetActive( true );
        Player.speechBubble.Clear();
        foreach( var option in IntelligenceOptions() )
            Player.speechBubble.ShowButton( option );
        Player.speechBubble.ShowButton( new NamedAction( "Back", ShowCategoryOptions ) );
    }

    void ShowChatOptions()
    {
        Player.speechBubble.gameObject.SetActive( true );
        Player.speechBubble.Clear();
        foreach( var option in ChatOptions() )
            Player.speechBubble.ShowButton( option );
        Player.speechBubble.ShowButton( new NamedAction( "Back", ShowCategoryOptions ) );
    }

    protected void PlaySound( string fileName )
    {

    }

    protected abstract IEnumerable<NamedAction> CharismaOptions();
    protected abstract IEnumerable<NamedAction> IntimidationOptions();
    protected abstract IEnumerable<NamedAction> IntelligenceOptions();
    protected abstract IEnumerable<NamedAction> ChatOptions();
}

public class DialogueNode
{
    public string name;
    public Action action;
}