using UnityEngine;
using System.Collections;

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

	#region Overrides

	protected override bool HasCharismaOptions { get { return true; } }
	protected override bool HasIntimidationOptions { get { return true; } }
	protected override bool HasIntelligenceOptions { get { return true; } }
	protected override bool HasChatOptions { get { return this.HasHappend(HappeningKeys.Greeting); } }

	protected override void StartNode()
	{
		PlaySound (this.NpcGreetingHaltNoEntry);
		Npc.Say ("Halt! No entry past this point");
	}

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
		Player.Say ("My son is the president of the best country in the world, Bavaria ... I mean Germany. " +
			"I'm so proud of Hans");

		yield return End ();
	}

	private IEnumerator ChatHowsWork()
	{
		PlaySound (this.PlayerChatHowsWork);
		Player.Say ("How's your work doing?");

		yield return WaitForInput ();

		PlaySound (this.NpcChatSonPresident);
		Player.Say ("I like working so close to my son the Bundeskanzler of Deutschland, but I have no time anymore " +
			"to care about my beautiful beard.");

		yield return End ();
	}

	private IEnumerator ChatLastWeekend()
	{
		PlaySound (this.PlayerChatWeekend);
		Player.Say ("What did you do last weekend?");

		yield return WaitForInput ();

		PlaySound (this.NpcChatNameday);
		Player.Say ("I have been celebrating the nameday of Hans' second name. \" Hans Blitzkrieg Müller, Buneskanzler " +
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
		Player.Say ("Shooting ... obviously. I got into it, because of the shiny Bavarian uniforms, " + 
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
		Player.Say ("You little Krüschperl will not be able to pass me.");

		yield return End ();
	}

	private IEnumerator IntimidateWolpertinger()
	{
		PlaySound (this.PlayerIntimidateWolpertinger);
		Player.Say ("Look! Over there!! A Wolpertinger handing out free beer!");

		yield return WaitForInput ();

		PlaySound (this.NpcIntimidateDontDrink);
		Player.Say ("I don't drink on duty. You won't fool me!");

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
		Player.Say ("Oh, and that would be ... ?");

		Npc.Happens (HappeningKeys.Greeting);

		yield return End ();
	}

	#endregion

	#region CharmeOptions

	private IEnumerable CharmeGreeting()
	{
		PlaySound (this.PlayerGreetingCompetent);
		Player.Say ("That's why you're such a competent guard. Stopping all the people ...");

		yield return WaitForInput ();

		PlaySound (this.NpcGreetingShyCoughing);
		Npc.Say ("*shy coughing*");

		Npc.Happens (HappeningKeys.Greeting);

		yield return End ();
	}

	#endregion

	#endregion

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
