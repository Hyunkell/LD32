using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class FathersOfficeDialog : Dialogue {

	#region Npc soundfiles

	#region Greeting / Introduction

	public AudioClip NpcGreetingHaltNoEntry;
	public AudioClip NpcGreetingNotHappening;
	public AudioClip NpcGreetingThatWouldBe;
	public AudioClip NpcGreetingShyCoughing;

	#endregion

	#region Chat

	public AudioClip NpcChatWorriedWind;
	public AudioClip NpcChatSonPresident;
	public AudioClip NpcChatWorkingCloseToSon;
	public AudioClip NpcChatNameday;
	public AudioClip NpcChatBlasMusik;
	public AudioClip NpcChatShooting;

	#endregion

	#region Intimidate

	public AudioClip NpcIntimidateJessesMaria;
	public AudioClip NpcIntimidateTraditionalUniform;
	public AudioClip NpcIntimidateKruschperl;
	public AudioClip NpcIntimidateDontDrink;

	#endregion

	#region Smart

	public AudioClip NpcSmartBavarianShit;
	public AudioClip NpcSmartMorePower;
	public AudioClip NpcSmartTrachtenmaking;
	public AudioClip NpcSmartElfriede;

	#endregion

	#region Charme

	public AudioClip NpcCharmeBestBeard;
	public AudioClip NpcCharmeSchuetzenkoenig;
	public AudioClip NpcCharmeBrezn;
	public AudioClip NpcCharmeGamsbart;

	#endregion

	#endregion

	#region Player soundfiles

	#region Greeting

	public AudioClip PlayerGreetingOutOfMyWay;
	public AudioClip PlayerGreetingImportantBusiness;
	public AudioClip PlayerGreetingCompetent;

	#endregion

	#region Chat

	public AudioClip PlayerChatHowsWeather;
	public AudioClip PlayerChatWhatsUp;
	public AudioClip PlayerChatHowsWork;
	public AudioClip PlayerChatWeekend;
	public AudioClip PlayerChatSong;
	public AudioClip PlayerChatOlympic;

	#endregion

	#region Intimidate

	public AudioClip PlayerIntimidateGetToYourHouse;
	public AudioClip PlayerIntimidateShinyUniform;
	public AudioClip PlayerIntimidatePushAndRun;
	public AudioClip PlayerIntimidateWolpertinger;

	#endregion

	#region Smart

	public AudioClip PlayerSmartLuxembourgRules;
	public AudioClip PlayerSmartRuleLAndG;
	public AudioClip PlayerSmartTrachten;
	public AudioClip PlayerSmartWomen;

	#endregion

	#region Charme

	public AudioClip PlayerCharmeBeard;
	public AudioClip PlayerCharmeGun;
	public AudioClip PlayerCharmePretzel;
	public AudioClip PlayerCharmeNiceCap;

	#endregion

	#endregion

	#region Collections of dialog options

	private IList<DialogueAction> _intelligenceOptions;
	private IList<DialogueAction> _intimidateOptions;
	private IList<DialogueAction> _charismaOptions;
	private IList<DialogueAction> _chatOptions;

	#endregion

	#region Overrides

	protected override bool HasCharismaOptions { get { return true; } }
	protected override bool HasIntimidationOptions { get { return true; } }
	protected override bool HasIntelligenceOptions { get { return true; } }
	protected override bool HasChatOptions { get { return this.HasHappend(HappeningKeys.Greeting); } }

	protected override void OnStart()
	{
		PlaySound (this.NpcGreetingHaltNoEntry);
		Npc.Say ("Halt! No entry past this point");
	}

    protected override IEnumerator OnSuccess()
    {
        Npc.Say( "TODO: OnSuccess()" );
        yield return WaitForInput();
    }

	#region Menu
	protected override IEnumerable<DialogueAction> CharismaOptions()
	{
		if (!this.HasHappend (HappeningKeys.Greeting)) {
			yield return new DialogueAction ("You're so competent", CharmeGreeting);
		} else {
			yield return new DialogueAction("Nice beard", CharmeBeard);
			yield return new DialogueAction("Nice gun", CharmGun);
			yield return new DialogueAction("Have a pretzel", CharmPretzel);
			yield return new DialogueAction("Nice cap", CharmeCap);
		}
	}
	
	protected override IEnumerable<DialogueAction> IntimidationOptions()
	{
		if (!this.HasHappend (HappeningKeys.Greeting)) {
			yield return new DialogueAction("Out of my way!", IntimidateGreeting);
		} else {
			yield return new DialogueAction("Gonna get to your house", IntimidateYourHouse);
			yield return new DialogueAction("Coffee on your uniform", IntimidateShinyUniform);
			yield return new DialogueAction("Push and run", IntimidatePushAndRun);
			yield return new DialogueAction("There a Wolpertinger", IntimidateWolpertinger);
		}
	}
	
	protected override IEnumerable<DialogueAction> IntelligenceOptions()
	{
		if (!this.HasHappend (HappeningKeys.Greeting)) {
			yield return new DialogueAction("I've got business", SmartGreeting);
		} else {
			yield return new DialogueAction("Germany will be Bavaria", SmartLuxRules);
			yield return new DialogueAction("Rule both countries", SmartRuleLAndG);
			yield return new DialogueAction("We have nice clothes", SmartTrachten);
			yield return new DialogueAction("We have nice women", SmartWomen);
		}
	}
	
	protected override IEnumerable<DialogueAction> ChatOptions()
	{
		yield return new DialogueAction ("How's the weather?", ChatHowsWeather);
		yield return new DialogueAction ("What's up?", ChatWhatsUp);
		yield return new DialogueAction ("How's work?", ChatHowsWork);
		yield return new DialogueAction ("How was the weekend?", ChatLastWeekend);
		yield return new DialogueAction ("Your favourite song?", ChatFavSong);
		yield return new DialogueAction ("Your favourite sport?", ChatOlympic);
	}
	#endregion

	#endregion

	#region Menu

	#region ChatOptions

	private IEnumerator ChatHowsWeather()
	{
		PlaySound (this.PlayerChatHowsWeather);
		Player.Say ("How's the weather today?");

		yield return WaitForInput ();

		PlaySound (this.NpcChatWorriedWind);
		Npc.Say ("I'm worried about the wind. I hope there won't be any new leaves in my front yard when I get home. " +
			"I like to keep everything nice and tidy, especially with my critical neighbours.");

		yield return End ();
	}

	private IEnumerator ChatWhatsUp()
	{
		PlaySound (this.PlayerChatWhatsUp);
		Player.Say ("What's up?");

		yield return WaitForInput ();

		PlaySound (this.NpcChatSonPresident);
		Npc.Say ("My son is the president of the best country in the world, Bavaria ... I mean Germany. " +
			"I'm so proud of Hans");

		yield return End ();
	}

	private IEnumerator ChatHowsWork()
	{
		PlaySound (this.PlayerChatHowsWork);
		Player.Say ("How's your work doing?");

		yield return WaitForInput ();

		PlaySound (this.NpcChatSonPresident);
		Npc.Say ("I like working so close to my son the Bundeskanzler of Deutschland, but I have no time anymore " +
			"to care about my beautiful beard.");

		yield return End ();
	}

	private IEnumerator ChatLastWeekend()
	{
		PlaySound (this.PlayerChatWeekend);
		Player.Say ("What did you do last weekend?");

		yield return WaitForInput ();

		PlaySound (this.NpcChatNameday);
		Npc.Say ("I have been celebrating the nameday of Hans' second name. \" Hans Blitzkrieg Müller, Buneskanzler " +
			"of Germany\" has a nice ring to it, doesn't it?");

		yield return End ();
	}

	private IEnumerator ChatFavSong()
	{
		PlaySound (this.PlayerChatSong);
		Player.Say ("What's your favorite song");

		yield return WaitForInput ();

		PlaySound (this.NpcChatBlasMusik);
		Npc.Say ("Some zünftige Blasmusik! Can't beat that!");

		yield return End ();
	}

	private IEnumerator ChatOlympic()
	{
		PlaySound (this.PlayerChatOlympic);
		Player.Say ("What's your favourite Olympic sport");

		yield return WaitForInput ();

		PlaySound (this.NpcChatShooting);
		Npc.Say ("Shooting ... obviously. I got into it, because of the shiny Bavarian uniforms, " + 
		            "just like the one I'm wearing");

		yield return End ();
	}

	#endregion

	#region IntimidateOptions

	private IEnumerator IntimidateGreeting()
	{
		PlaySound (this.PlayerGreetingOutOfMyWay);
		Player.Say ("Get out of my way, man!");

		yield return WaitForInput ();

		PlaySound (this.NpcGreetingNotHappening);
		Npc.Say ("Not happening!");

		Npc.Happens (HappeningKeys.Greeting);

		yield return End ();
	}

	private IEnumerator IntimidateYourHouse()
	{
		PlaySound (this.PlayerIntimidateGetToYourHouse);
		Player.Say ("I'm gonna get to your house ... and then  I'll get to your trash ... " +
			"and then I'll take your trash ... and dump it all over your front yard! " +
			"And then everyone of your neighbours will see the mess!!! And then they'll " +
			"think \"Gosh, what an untidy household he has!\" AHAHHAHAHHHAHAH!");

		yield return WaitForInput ();

		PlaySound (this.NpcIntimidateJessesMaria);
		Npc.Say ("Jesses Maria! Everything but that!");

		yield return End ();
	}

	private IEnumerator IntimidateShinyUniform()
	{
		PlaySound (this.PlayerIntimidateShinyUniform);
		Player.Say ("Shiny uniform you're wearing there. I should be careful with my coffee around that. " +
		            "Would be a shame if it caught any stains ...");

		yield return WaitForInput ();

		PlaySound (this.NpcIntimidateTraditionalUniform);
		Npc.Say ("Oh no! My traditional Bavarian royal guard uniform! It's irreplaceable!");

		yield return End ();
	}

	private IEnumerator IntimidatePushAndRun()
	{
		PlaySound (this.PlayerIntimidatePushAndRun);
		Player.Say ("What if I just pushed you out of my way and ran through that door ...?");

		yield return WaitForInput ();

		PlaySound (this.NpcIntimidateKruschperl);
		Npc.Say ("You little Krüschperl will not be able to pass me.");

		yield return End ();
	}

	private IEnumerator IntimidateWolpertinger()
	{
		PlaySound (this.PlayerIntimidateWolpertinger);
		Player.Say ("Look! Over there!! A Wolpertinger handing out free beer!");

		yield return WaitForInput ();

		PlaySound (this.NpcIntimidateDontDrink);
		Npc.Say ("I don't drink on duty. You won't fool me!");

		yield return End ();
	}

	#endregion

	#region SmartOptions

	private IEnumerator SmartGreeting()
	{
		PlaySound (this.PlayerGreetingImportantBusiness);
		Player.Say ("Oh, but I have important business in there.");

		yield return WaitForInput ();

		PlaySound (this.NpcGreetingThatWouldBe);
		Npc.Say ("Oh, and that would be ... ?");

		Npc.Happens (HappeningKeys.Greeting);

		yield return End ();
	}

	private IEnumerator SmartLuxRules()
	{
		PlaySound (this.PlayerSmartLuxembourgRules);
		Player.Say ("As soon as Luxembourg rules the world, all of Germany will be made Bavarian, that's the " +
			"only thing the people know about Germany, anyway.");

		yield return WaitForInput ();

		PlaySound (this.NpcSmartBavarianShit);
		Npc.Say ("Dreamy Bavarian Shit!");

		yield return End ();
	}

	private IEnumerator SmartRuleLAndG()
	{
		PlaySound (this.PlayerSmartRuleLAndG);
		Player.Say ("I could help your son rule Luxembourg and Germany.");

		yield return WaitForInput ();

		PlaySound (this.NpcSmartMorePower);
		Npc.Say ("Ooooh the more power the better.");

		yield return End ();
	}

	private IEnumerator SmartTrachten()
	{
		PlaySound (this.PlayerSmartTrachten);
		Player.Say ("Luxembourg has a lot of beautiful Trachten-outfits.");

		yield return WaitForInput ();

		PlaySound (this.NpcSmartTrachtenmaking);
		Npc.Say ("Nothing can beat the traditional bavarian art of Trachtenmaking!");

		yield return End ();
	}

	private IEnumerator SmartWomen()
	{
		PlaySound (this.PlayerSmartWomen);
		Player.Say("Luxembourg has some of the most beautiful women in the world.");

		yield return WaitForInput ();

		PlaySound (this.NpcSmartElfriede);
		Npc.Say ("No, thanks. My beloved Elfriede is the only one for me!");

		yield return End ();
	}

	#endregion

	#region CharmeOptions

	private IEnumerator CharmeGreeting()
	{
		PlaySound (this.PlayerGreetingCompetent);
		Player.Say ("That's why you're such a competent guard. Stopping all the people ...");

		yield return WaitForInput ();

		PlaySound (this.NpcGreetingShyCoughing);
		Npc.Say ("*shy coughing*");

		Npc.Happens (HappeningKeys.Greeting);

		yield return End ();
	}

	private IEnumerator CharmeBeard()
	{
		PlaySound (this.PlayerCharmeBeard);
		Player.Say ("I really like your beard! You must have put a lot of effort into it!");

		yield return WaitForInput ();

		PlaySound (this.NpcCharmeBestBeard);
		Npc.Say ("Thank you! Last year, it won the \"best beard of the Oktoberfest\" award.");

		yield return End ();
	}

	private IEnumerator CharmGun()
	{
		PlaySound (this.PlayerCharmeGun);
		Player.Say ("I really like your gun! I bet you're a good shooter!");

		yield return WaitForInput ();

		PlaySound (this.NpcCharmeSchuetzenkoenig);
		Npc.Say ("Thanks, I've practiced a lot and was Schützenkönig of my home village 5 times in a row!");

		yield return End ();
	}

	private IEnumerator CharmPretzel()
	{
		PlaySound (this.PlayerCharmePretzel);
		Player.Say ("I brought a pretzel from Luxembourg. You want a bite?");

		yield return WaitForInput ();

		PlaySound (this.NpcCharmeBrezn);
		Npc.Say ("How dare you mock the traditional Brezn-making with your dry lump of dough?");

		yield return End ();
	}

	private IEnumerator CharmeCap()
	{
		PlaySound (this.PlayerCharmeNiceCap);
		Player.Say ("Hey, nice cap you've got there! And that fluffy cotton ball on top of it is really cute!");

		yield return WaitForInput ();

		PlaySound (this.NpcCharmeGamsbart);
		Npc.Say ("*gasp* That's traditional bavarian Trachtenhut with a Gamsbart, you lowly philistine!");

		yield return End ();
	}

	#endregion

	#endregion

	//TODO Put this in parent class or helper class and make this generic
	public static IList<DialogueAction> ShuffleCollection(IList<DialogueAction> dialogueOptions)
	{
		IList<DialogueAction> shuffeledList = new List<DialogueAction> ();

		while (dialogueOptions.Count > 0) 
		{
			var index = UnityEngine.Random.Range(0, dialogueOptions.Count-1);
			shuffeledList.Add(dialogueOptions[index]);
			dialogueOptions.RemoveAt(index);
		}

		return shuffeledList;
	}
	
}
