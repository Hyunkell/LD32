using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class MerkelDialogue : Dialogue
{
    protected override void StartNode()
    {
        PlaySound( "TEST_SOUND" );
        Npc.Say(
            "Hi!",
            "I am ze Fräulein Merkel.",
            "Welcome to ze Germany" );
    }

    protected override IEnumerable<DialogueAction> CharismaOptions()
    {
        // Conditions go here
        // if( hasFlower )
        yield return new DialogueAction( "Flower", Charisma_Flower );
    }

    protected override IEnumerable<DialogueAction> IntimidationOptions()
    {
        yield return new DialogueAction( "Punch", Intimidate_Punch );
    }

    protected override IEnumerable<DialogueAction> IntelligenceOptions()
    {
        return Enumerable.Empty<DialogueAction>();
    }

    protected override IEnumerable<DialogueAction> ChatOptions()
    {
        return Enumerable.Empty<DialogueAction>();
    }

    public IEnumerator Charisma_Flower()
    {
        PlaySound( "Merkel_Charisma_Flower_Player" );
        Player.Say(
            "Hello Frau Merkel!",
            "I have bought you a flower. :D" );

        yield return WaitForInput();

        PlaySound( "Merkel_Charisma_Flower_Merkel" );
        Npc.Say(
            "Dude wtf, I hate flowers!",
            "Affinity -10");
        Npc.ModifyAffinity( -10.0f );

        yield return End();
    }

    public IEnumerator Intimidate_Punch()
    {
        PlaySound( "Merkel_Intimidate_Punch_Player" );
        Player.Say(
            "Hello Frau Merkel!",
            "Joint my empire or I shall punch you the face!" );

        yield return WaitForInput();

        PlaySound( "Merkel_Intimidate_Punch_Merkel" );
        Npc.Say(
            "omg pls no :(",
            "Affinity +10" );
        Npc.ModifyAffinity( +10.0f );

        yield return End();
    }
}