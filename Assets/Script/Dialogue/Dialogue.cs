﻿using UnityEngine;
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

    protected abstract void OnStart();
    protected abstract IEnumerator OnSuccess();
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
        yield return WaitForInput();

        // Check if we need to move to the next scene
        if( Npc.affinity >= 10.0f )
        {
            yield return StartCoroutine( OnSuccess() );
            LoadNextScene();
        }
        else if( Npc.affinity <= -10.0f )
        {
            ShowFailOverlay();
            LoadNextScene();


            // Old loss of ability code
            /*
            // The player will loose one of his abilities
            // Choose ability
            Player.speechBubble.Clear();
            if( Player.hasCharismaAbility )
                ShowCategoryOption( Player.speechBubble._iconCharismaPrefab, DisableCharmAbility );
            if( Player.hasIntimidateAbility )
                ShowCategoryOption( Player.speechBubble._iconIntimidatePrefab, DisableIntimidateAbility );
            if( Player.hasIntelligenceAbility )
                ShowCategoryOption( Player.speechBubble._iconIntelligencePrefab, DisableIntelligenceAblility );

            // TODO: the player needs to know that he is loosing an ability
            // Just tint the buttons red for now
            foreach( Transform child in Player.speechBubble.iconMode.transform )
            {
                var icon = child.GetComponent<UnityEngine.UI.Image>();
                icon.color = Color.red;
            }
            */
        }
        else
            ShowCategoryOptions().MoveNext();
    }

    bool isSuccess = false;
    protected void ShowSuccessOverlay()
    {
        isSuccess = true;
    }

    bool isFail = false;
    protected void ShowFailOverlay()
    {
        isFail = true;
    }

    void LoadNextScene()
    {
        Player.speechBubble.Clear();
        Player.speechBubble.Hide();
        DialogueAction.Reset();

        if( isSuccess )
        {
            GameObject.FindObjectOfType<SceneSelection>().LoadWinOverlay();
            Npc.speechBubble.Hide();
        }
        else if( isFail )
        {
            GameObject.FindObjectOfType<SceneSelection>().LoadFailOverlay();
            Npc.speechBubble.Hide();
        }
        else
        {
            GameObject.FindObjectOfType<SceneSelection>().LoadNextScene();
            Player.GetComponent<Movement>().enabled = true;
        }
    }

    void ReloadScene()
    {
        // Make sure the player still has abilities, otherwise it's game over
        if( Player.hasCharismaAbility || Player.hasIntimidateAbility || Player.hasIntelligenceAbility )
        {
            GameObject.FindObjectOfType<SceneSelection>().LoadCurrentScene();
            DialogueAction.Reset();
            Npc.Reset();
            Npc.speechBubble.Clear();
            Npc.speechBubble.Hide();
            Player.speechBubble.Clear();
            Player.speechBubble.Hide();
            Player.GetComponent<Movement>().enabled = true;
        }
        else
        {
            //GameObject.FindObjectOfType<SceneSelection>().ResetGame();
            GameObject.FindObjectOfType<SceneSelection>().LoadGameOverPage();
        }
    }

    private IEnumerator DisableCharmAbility()
    {
        Player.hasCharismaAbility = false;
        ReloadScene();
        yield break;
    }

    private IEnumerator DisableIntimidateAbility()
    {
        Player.hasIntimidateAbility = false;
        ReloadScene();
        yield break;
    }

    private IEnumerator DisableIntelligenceAblility()
    {
        Player.hasIntelligenceAbility = false;
        ReloadScene();
        yield break;
    }

    //     private IEnumerator DisableChatAbility()
    //     {
    //         Player.hasChatAbility = false;
    //         LoadNextScene();
    //         yield break;
    //     }

    protected Coroutine WaitForInput()
    {
        return StartCoroutine( WaitForInputEnumerator() );
    }

    // Fix for WaitForInput() being able to trigger twice per frame
    bool wasInputHandled = false;
    void Update() { wasInputHandled = false; }

    IEnumerator WaitForInputEnumerator()
    {
        while( wasInputHandled || !( Input.GetKeyDown( KeyCode.Space ) || Input.GetMouseButtonDown( 0 ) ) )
            yield return null;

        // Fix for WaitForInput() being able to trigger twice per frame
        wasInputHandled = true;
    }

    public void BeginDialogue()
    {
        //Player.speechBubble.gameObject.SetActive( true );
        Npc.speechBubble.gameObject.SetActive( true );

        OnStart();
        ShowCategoryOptions().MoveNext();
    }

    protected IEnumerator ShowCategoryOptions()
    {
        Player.speechBubble.gameObject.SetActive( true );
        Player.speechBubble.Clear();
        if( HasCharismaOptions && Player.hasCharismaAbility )
            ShowCategoryOption( Player.speechBubble._iconCharismaPrefab, ShowCharismaOptions );
        if( HasIntimidationOptions && Player.hasIntimidateAbility )
            ShowCategoryOption( Player.speechBubble._iconIntimidatePrefab, ShowIntimidateOptions );
        if( HasIntelligenceOptions && Player.hasIntelligenceAbility )
            ShowCategoryOption( Player.speechBubble._iconIntelligencePrefab, ShowIntelligenceOptions );
        if( HasChatOptions && Player.hasChatAbility )
            ShowCategoryOption( Player.speechBubble._iconChatPrefab, ShowChatOptions );
        yield break;
    }

    protected void ClearPlayerDialogue()
    {
        Player.speechBubble.Clear();
    }

    protected void ShowCategoryOption( GameObject iconPrefab, Func<IEnumerator> action )
    {
        Player.speechBubble.ShowIcon( iconPrefab, new DialogueAction( "icon", action ) );
    }

    protected void ShowDialogueOption( string name, Func<IEnumerator> action )
    {
        if( !DialogueAction.IsDone( name ) )
            Player.speechBubble.ShowButton( new DialogueAction( name, action ) );
    }

    protected void ShowDialogueOption<ParamType>( string name, Func<ParamType, IEnumerator> action, ParamType parameter )
    {
        Player.speechBubble.ShowButton( new DialogueParameterAction<ParamType>( name, action, parameter ) );
    }

    IEnumerator ShowCharismaOptions()
    {
        Player.speechBubble.gameObject.SetActive( true );
        Player.speechBubble.Clear();
        foreach( var option in CharismaOptions() )
            if( !DialogueAction.IsDone( option.text ) )
                Player.speechBubble.ShowButton( option );
        Player.speechBubble.ShowButton( new DialogueAction( "Back", ShowCategoryOptions ) );
        yield break;
    }

    IEnumerator ShowIntimidateOptions()
    {
        Player.speechBubble.gameObject.SetActive( true );
        Player.speechBubble.Clear();
        foreach( var option in IntimidationOptions() )
            if( !DialogueAction.IsDone( option.text ) )
                Player.speechBubble.ShowButton( option );
        Player.speechBubble.ShowButton( new DialogueAction( "Back", ShowCategoryOptions ) );
        yield break;
    }

    IEnumerator ShowIntelligenceOptions()
    {
        Player.speechBubble.gameObject.SetActive( true );
        Player.speechBubble.Clear();
        foreach( var option in IntelligenceOptions() )
            if( !DialogueAction.IsDone( option.text ) )
                Player.speechBubble.ShowButton( option );
        Player.speechBubble.ShowButton( new DialogueAction( "Back", ShowCategoryOptions ) );
        yield break;
    }

    IEnumerator ShowChatOptions()
    {
        Player.speechBubble.gameObject.SetActive( true );
        Player.speechBubble.Clear();
        foreach( var option in ChatOptions() )
            if( !DialogueAction.IsDone( option.text ) )
                Player.speechBubble.ShowButton( option );
        Player.speechBubble.ShowButton( new DialogueAction( "Back", ShowCategoryOptions ) );
        yield break;
    }

    protected void PlaySound( AudioClip clip )
    {
        Audio.PlaySound( clip );
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