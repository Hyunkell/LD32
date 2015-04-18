using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HBMDialog : Dialogue
{
    #region Npc Sound Files
    public string NpcGreeting = string.Empty;
    public string NpcOk = string.Empty;
	public string NpcThanks = string.Empty;
	public string NpcWonder = string.Empty;
	public string NpcMercedes = string.Empty;
    #endregion

    #region Player Sound Files
    public string PlayerIntimidateGreeting = string.Empty;
	public string PlayerCharismaGreeting = string.Empty;
	public string PlayerCharismaWonder = string.Empty;
	public string PlayerCharismaMercedes = string.Empty;
    #endregion

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
        yield return new DialogueAction("Shut up", IntimidateGreeting);
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
        yield return End();
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
