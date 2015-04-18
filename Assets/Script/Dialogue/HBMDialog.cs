using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HBMDialog : Dialogue
{
    #region Npc Sound Files
    public string NpcGreeting = string.Empty;
    private string NpcOk = string.Empty;
    #endregion

    #region Player Sound Files
    public string PlayerIntimidateGreeting = string.Empty;
    #endregion

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
}
