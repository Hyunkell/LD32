using UnityEngine;
using System.Collections;

public class CateenDialouge : Dialogue
{
    #region Npc Sound Files
    public AudioClip NpcGreeting;
    private AudioClip PlayerGreetingSauerkraut;
    private AudioClip NpcGreetingSauerkraut;
    #endregion

    #region Player Sound Files

    #endregion

    protected override bool HasCharismaOptions { get { return this.HasHappend(HappeningKeys.Greeting); } }

    protected override bool HasIntimidationOptions { get { return this.HasHappend(HappeningKeys.Greeting); } }

    protected override bool HasIntelligenceOptions { get { return this.HasHappend(HappeningKeys.Greeting); } }

    protected override bool HasChatOptions { get { return true; } }

    protected override void StartNode()
    {
        PlaySound(this.NpcGreeting);
        Npc.Say("Bretzel? Weiswurst? Sauerkraut?");
    }

    protected override System.Collections.Generic.IEnumerable<DialogueAction> CharismaOptions()
    {
        throw new System.NotImplementedException();
    }

    protected override System.Collections.Generic.IEnumerable<DialogueAction> IntimidationOptions()
    {
        throw new System.NotImplementedException();
    }

    protected override System.Collections.Generic.IEnumerable<DialogueAction> IntelligenceOptions()
    {
        throw new System.NotImplementedException();
    }

    protected override System.Collections.Generic.IEnumerable<DialogueAction> ChatOptions()
    {
        if (!this.HasHappend(HappeningKeys.Greeting))
        {
            yield return new DialogueAction("Bretzel", GreetingPretzel);
            yield return new DialogueAction("Weißwurst", GreetingWeißwurst);
            yield return new DialogueAction("Sauerkraut", GreetingSauerkraut);
        }
        else
        {

        }
    }

    #region Greeting actions
    private IEnumerator GreetingSauerkraut()
    {
        PlaySound(this.PlayerGreetingSauerkraut);
        Player.Say("Sauerkraut.");
        yield return WaitForInput();

        PlaySound(this.NpcGreetingSauerkraut);
        Npc.Say("Still not sauer enough, that could take a bit.");
        yield return End();
    }

    private IEnumerator GreetingPretzel()
    {
        throw new System.NotImplementedException();
    }

    private IEnumerator GreetingWeißwurst()
    {
        throw new System.NotImplementedException();
    }
    #endregion
}
