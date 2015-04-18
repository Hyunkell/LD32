using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HBMDialog : Dialogue
{
    #region Npc Sound Files
    public string NpcGreeting = string.Empty;
    private string NpcOk = string.Empty;
    public string NpcIntimidateRevealB = string.Empty;
    #endregion

    #region Player Sound Files
    public string PlayerIntimidateGreeting = string.Empty;
    public string PlayerIntimidateRevealB = string.Empty;
    #endregion

    private bool isGreetingPhase = true;

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
}
