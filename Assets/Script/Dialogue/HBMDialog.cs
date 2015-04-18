﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HBMDialog : Dialogue
{
    #region Npc Sound Files
    public string NpcGreeting = string.Empty;
<<<<<<< HEAD
    public string NpcOk = string.Empty;
	public string NpcThanks = string.Empty;
	public string NpcWonder = string.Empty;
	public string NpcMercedes = string.Empty;
=======
    private string NpcOk = string.Empty;
    public string NpcIntimidateRevealB = string.Empty;
>>>>>>> 920737fde900070265d7f0a56068d8957df532d9
    #endregion

    #region Player Sound Files
    public string PlayerIntimidateGreeting = string.Empty;
<<<<<<< HEAD
	public string PlayerCharismaGreeting = string.Empty;
	public string PlayerCharismaWonder = string.Empty;
	public string PlayerCharismaMercedes = string.Empty;
=======
    public string PlayerIntimidateRevealB = string.Empty;
>>>>>>> 920737fde900070265d7f0a56068d8957df532d9
    #endregion

    private bool isGreetingPhase = true;

    protected override bool HasCharismaOptions { get { return false; } }
    protected override bool HasIntimidationOptions { get { return true; } }
    protected override bool HasIntelligenceOptions { get { return false; } }
    protected override bool HasChatOptions { get { return false; } }

    protected override void StartNode()
    {
        PlaySound(this.NpcGreeting);
        Npc.Say(
            "How did you get here?");
    }

    protected override IEnumerable<DialogueAction> CharismaOptions()
    {
        yield break;
    }

    protected override IEnumerable<DialogueAction> IntimidationOptions()
    {
        if (this.isGreetingPhase)
        {
        yield return new DialogueAction("Shut up", IntimidateGreeting);
    }
        else
        {
            yield return new DialogueAction("reveal the B", IntimidateRevealB);
        }
    }

    protected override IEnumerable<DialogueAction> IntelligenceOptions()
    {
        yield break;
    }

    protected override IEnumerable<DialogueAction> ChatOptions()
    {
        yield break;
    }

    #region Intimidate Options
    public IEnumerator IntimidateGreeting()
    {
        PlaySound(this.PlayerIntimidateGreeting);
        Player.Say("Shut up, it doesn't matter.");
        yield return WaitForInput();

        PlaySound(this.NpcOk);
        Npc.Say("Ok");
        yield return End();
    }

    public IEnumerator IntimidateRevealB()
    {
        PlaySound(this.PlayerIntimidateRevealB);
        Player.Say("I know what the \"B\" Stands for");
        yield return WaitForInput();

        if (this.Player.HasHappend("abc"))
        {
            PlaySound(this.NpcIntimidateRevealB);
            Npc.Say("Oh, please don't tell anyone! They will know that Im a Nazi");
        yield return End();
    }
    }
    #endregion

	#region Charisma Options
	public IEnumerator CharismaGreeting()
	{
		PlaySound (this.PlayerCharismaGreeting);
		Player.Say ("I just wanted to thank you for doing an amazing job, ruling Germany.");
		yield return WaitForInput ();

		PlaySound (this.NpcThanks);
		Npc.Say ("Thank you... I guess?");

		yield return End ();
	}

	public IEnumerator CharismaWonder()
	{
		PlaySound (this.PlayerCharismaWonder);
		Player.Say ("Having started the Wirtschaftswunder proves your capability as a leader!");
		yield return WaitForInput ();

		PlaySound (this.NpcWonder);
		Npc.Say ("The Wirtschawhat? Ah yes, yes I am often amazed at myself");

		yield return End ();
	}

	public IEnumerator CharismaMercedes()
	{
		PlaySound (this.PlayerCharismaMercedes);
		Player.Say ("So you like Mercedes cars? I like them too! <3");
		yield return WaitForInput ();

		PlaySound (this.NpcMercedes);
		Npc.Say ("(Mercedes Monolog)");

		yield return End ();
	}

	#endregion
}
