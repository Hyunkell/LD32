using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class MerkelDialogue : Dialogue
{

    protected override bool HasCharismaOptions { get { return true; } }
    protected override bool HasIntimidationOptions { get { return true; } }
    protected override bool HasIntelligenceOptions { get { return false; } }
    protected override bool HasChatOptions { get { return false; } }

    protected override void StartNode()
    {
        PlaySound("TEST_SOUND");
        Npc.Say(
            "Hi!",
            "I am ze Fräulein Merkel.",
            "Welcome to ze Germany");
    }

    protected override IEnumerable<DialogueAction> CharismaOptions()
    {
        // Conditions go here
        // if( hasFlower )
        yield return new DialogueAction("Flower", Charisma_Flower);
    }

    protected override IEnumerable<DialogueAction> IntimidationOptions()
    {
        yield return new DialogueAction("Punch", Intimidate_Punch);
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
        PlaySound("Merkel_Charisma_Flower_Player");
        Player.Say(
            "Hello Frau Merkel!",
            "I have bought you a flower. :D");

        yield return WaitForInput();

        PlaySound("Merkel_Charisma_Flower_Merkel");
        Npc.Say(
            "Dude wtf, I hate flowers!",
            "Affinity -10");
        Npc.ModifyAffinity(-10.0f);


        // Dialogue branching test
        yield return WaitForInput();
        ClearPlayerDialogue();
        bool test = true;
        if (test)
        {
            ShowDialogueOption("Test1", DialogBranchTest1);
            ShowDialogueOption("Test2", DialogBranchTest2);
        }

        //Say some bad stuff
        //modify affinity
        yield return End();
    }

    public IEnumerator DialogBranchTest1()
    {
        Player.Say("Test1 Player");
        Npc.Say("Test1 Npc");
        yield return End();
    }

    public IEnumerator DialogBranchTest2()
    {
        Player.Say("Test2 Player");
        Npc.Say("Test2 Npc");
        yield return End();
    }

    public IEnumerator Intimidate_Punch()
    {
        PlaySound("Merkel_Intimidate_Punch_Player");
        Player.Say(
            "Hello Frau Merkel!",
            "Joint my empire or I shall punch you the face!");

        yield return WaitForInput();

        PlaySound("Merkel_Intimidate_Punch_Merkel");
        Npc.Say(
            "omg pls no :(",
            "Affinity +10");
        Npc.ModifyAffinity(+10.0f);

        yield return End();
    }
}