using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HBMDialog : Dialogue
{
    #region Npc Sound Files
    public string NpcGreeting = string.Empty;
    public string NpcOk = string.Empty;

	public string NpcCharismaGreetingThanks = string.Empty;
	public string NpcCharismaWonder = string.Empty;
	public string NpcCharismaMercedes = string.Empty;

    public string NpcIntimidateRevealB = string.Empty;

	public string NpcChatWeatherMercedes = string.Empty;
	public string NpcChatMotionOfNoConfidence = string.Empty;
	public string NpcChatWarForDummies = string.Empty;
	public string NpcChatBeerGarden = string.Empty;
	public string NpcChatMoney = string.Empty;
	public string NpcChatOlympic = string.Empty;
    #endregion

    #region Player Sound Files
    public string PlayerIntimidateGreeting = string.Empty;
	public string PlayerCharismaGreeting = string.Empty;
	public string PlayerCharismaWonder = string.Empty;
	public string PlayerCharismaMercedes = string.Empty;

    public string PlayerIntimidateRevealB = string.Empty;

	public string PlayerChatWeather = string.Empty;
	public string PlayerChatWhatsUp = string.Empty;
	public string PlayerChatHowIsWork = string.Empty;
	public string PlayerChatLastWeekend = string.Empty;
	public string PlayerChatFavSong = string.Empty;
	public string PlayerChatFavSport = string.Empty;
    #endregion

    private bool isGreetingPhase = true;

    protected override bool HasCharismaOptions { get { return true; } }
    protected override bool HasIntimidationOptions { get { return true; } }
    protected override bool HasIntelligenceOptions { get { return true; } }
    protected override bool HasChatOptions { get { return !isGreetingPhase; } }

    protected override void StartNode()
    {
        PlaySound(this.NpcGreeting);
        Npc.Say(
            "How did you get here?");
    }

    protected override IEnumerable<DialogueAction> CharismaOptions()
    {
		if (this.isGreetingPhase) 
		{
			yield return new DialogueAction ("Thank you", CharismaGreeting);
		} 
		else 
		{
			yield return new DialogueAction("Like Mercedes?", CharismaMercedes);
			if(this.Player.HasHappend("charismaGreeting"))
			{
				yield return new DialogueAction("Good work", CharismaWonder);
			}
		}
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
		yield return new DialogueAction ("How is the weather", ChatWeather);
		yield return new DialogueAction ("What's up", ChatWhatsUp);
		yield return new DialogueAction ("How is work", ChatHowIsWork);
		yield return new DialogueAction ("How was weekend", ChatWeekend);
		yield return new DialogueAction ("Favourite song", ChatFavSong);
		yield return new DialogueAction ("Favourite olympic sport", ChatFavSport);
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

		PlaySound (this.NpcCharismaGreetingThanks);
		Npc.Say ("Thank you... I guess?");

		yield return End ();
	}

	public IEnumerator CharismaWonder()
	{
		PlaySound (this.PlayerCharismaWonder);
		Player.Say ("Having started the Wirtschaftswunder proves your capability as a leader!");
		yield return WaitForInput ();

		PlaySound (this.NpcCharismaWonder);
		Npc.Say ("The Wirtschawhat? Ah yes, yes I am often amazed at myself");

		yield return End ();
	}

	public IEnumerator CharismaMercedes()
	{
		PlaySound (this.PlayerCharismaMercedes);
		Player.Say ("So you like Mercedes cars? I like them too! <3");
		yield return WaitForInput ();

		PlaySound (this.NpcCharismaMercedes);
		Npc.Say ("(Mercedes monologue)");

		yield return End ();
	}

	#endregion

	#region Chat Options

	public IEnumerator ChatWeather()
	{
		PlaySound (this.PlayerChatWeather);
		Player.Say ("How's the weather today?");
		yield return WaitForInput();

		PlaySound (this.NpcChatWeatherMercedes);
		Npc.Say ("It's great. Finally I can drive my awesome mercedes again!");
		yield return WaitForInput ();

		PlaySound (this.NpcCharismaMercedes);
		Npc.Say ("(Mercedes monologue)");

		yield return End ();
	}

	public IEnumerator ChatWhatsUp()
	{
		PlaySound (this.PlayerChatWhatsUp);
		Player.Say ("What's up?");
		yield return WaitForInput ();

		PlaySound (this.NpcChatMotionOfNoConfidence);
		Player.Say ("I'm a bit worried about the motion of no confidence. Maybe I'll loose my position soon...");

		yield return End ();
	}

	public IEnumerator ChatHowIsWork()
	{
		PlaySound (this.ChatHowIsWork);
		Player.Say ("How's your work doing?");
		yield return WaitForInput ();
		
		PlaySound (this.NpcChatWarForDummies);
		Player.Say ("I'm trying to Read War for Dummies. Those military stategies are realy complicated!" + 
		            "Did you know that Germany has more than 1500 Tanks, and they all want to be commanded");
		
		yield return End ();
	}

	public IEnumerator ChatWeekend()
	{
		PlaySound (this.ChatWeekend);
		Player.Say ("What were you doing last weekend?");
		yield return WaitForInput ();
		
		PlaySound (this.NpcChatBeerGarden);
		Player.Say ("I've visited the beer garden with my father. We had Weiswurst and Sauerkraut");
		
		yield return End ();
	}

	public IEnumerator ChatFavSong()
	{
		PlaySound (this.PlayerChatFavSong);
		Player.Say ("Whats your favourit song?");
		yield return WaitForInput ();
		
		PlaySound (this.NpcChatMoney);
		Player.Say ("Money, Money, Money!");
		
		yield return End ();
	}

	public IEnumerator ChatFavSport()
	{
		PlaySound (this.PlayerChatFavSport);
		Player.Say ("Whats your favorite Olympic sport?");
		yield return WaitForInput ();
		
		PlaySound (this.NpcChatOlympic);
		Player.Say ("I don't like the Olympic Games, they're so expensive." + 
		            "I'm allready paying such a hugh amount of taxes and all" +
		            " is going to this useless sports! Did you know, that the" +
		            " more money you have, the more money you have to give to the tax office, even I, as president.");
		
		yield return End ();
	}

	#endregion
}
