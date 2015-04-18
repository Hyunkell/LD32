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

    protected override IEnumerable<NamedAction> CharismaOptions()
    {
        // Conditions go here
        // if( hasFlower )
        yield return new NamedAction( "Flower", Charisma_Flower );
    }


    protected override IEnumerable<NamedAction> IntimidationOptions()
    {
        yield return new NamedAction( "Punch", Intimidate_Punch );
    }

    protected override IEnumerable<NamedAction> IntelligenceOptions()
    {
        return Enumerable.Empty<NamedAction>();
    }

    protected override IEnumerable<NamedAction> ChatOptions()
    {
        return Enumerable.Empty<NamedAction>();
    }

    public void Charisma_Flower()
    {
        PlaySound( "Merkel_Charisma_Flower_Player" );
        Player.Say(
            "Hello Frau Merkel!",
            "I have bought you a flower. :D" );


        PlaySound( "Merkel_Charisma_Flower_Merkel" );
        Npc.Say(
            "Dude wtf, I hate flowers!" );
        Npc.ModifyAffinity( -10.0f );
    }

    public void Intimidate_Punch()
    {
        PlaySound( "Merkel_Intimidate_Punch_Player" );
        Player.Say(
            "Hello Frau Merkel!",
            "Joint my empire or I shall punch you the face!" );

        PlaySound( "Merkel_Intimidate_Punch_Merkel" );
        Npc.Say(
            "omg pls no :(",
            "Affinity -10" );
        Npc.ModifyAffinity( +10.0f );
    }
}