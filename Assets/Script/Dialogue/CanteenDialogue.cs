using UnityEngine;
using System.Collections;

public class CanteenDialogue : Dialogue
{
    #region Npc Sound Files
    public AudioClip NpcGreeting;
    public AudioClip NpcGreetingSauerkraut;
    public AudioClip NpcGreetingPretzel;
    public AudioClip NpcGreetingWeißwurst;
    public AudioClip NpcCharismaHairnet;
    public AudioClip NpcCharismaLove;
    public AudioClip NpcCharismaPartner;
    public AudioClip NpcCharismaHandsome;
    public AudioClip NpcIntelligenceSauerkraut;
    public AudioClip NpcIntelligencWomen;
    public AudioClip NpcIntelligenceBeauty;
    public AudioClip NpcIntelligenceMen;
    public AudioClip NpcIntimidateBretzel;
    public AudioClip NpcIntimidateHair;
    public AudioClip NpcIntimidateRelationship;
    public AudioClip NpcIntimidateSauerkraut;
    public AudioClip NpcChatFavSport;
    public AudioClip NpcChatFavSong;
    public AudioClip NpcChatBeergarden;
    public AudioClip NpcChatLastWeekend;
    public AudioClip NpcChatWhatsUp;
    public AudioClip NpcChatWeather;
    public AudioClip NpcChatHowIsWork;
    public AudioClip NpcConversationEnd;
    #endregion

    #region Player Sound Files
    public AudioClip PlayerGreetingSauerkraut;
    public AudioClip PlayerGreetingPretzel;
    public AudioClip PlayerGreetingWeißwurst;
    public AudioClip PlayerCharismaHairnet;
    public AudioClip PlayerCharismaLove;
    public AudioClip PlayerCharismaPartner;
    public AudioClip PlayerCharismaHandsome;
    public AudioClip PlayerIntelligenceSauerkraut;
    public AudioClip PlayerIntelligenceWomen;
    public AudioClip PlayerIntelligenceBeauty;
    public AudioClip PlayerIntelligenceMen;
    public AudioClip PlayerIntimidateBretzel;
    public AudioClip PlayerIntimidateHair;
    public AudioClip PlayerIntimidateRelationship;
    public AudioClip PlayerIntimidateSauerkraut;
    public AudioClip PlayerChatFavSport;
    public AudioClip PlayerChatFavSong;
    public AudioClip PlayerChatBeergarden;
    public AudioClip PlayerChatLastWeekend;
    public AudioClip PlayerChatHowIsWork;
    public AudioClip PlayerChatWhatsUp;
    public AudioClip PlayerChatWeather;
    #endregion

    private float _negativeResponse = -4;

    private float _positiveResponse = 5;

    protected override bool HasCharismaOptions { get { return this.HasHappend(HappeningKeys.Greeting); } }

    protected override bool HasIntimidationOptions { get { return this.HasHappend(HappeningKeys.Greeting); } }

    protected override bool HasIntelligenceOptions { get { return this.HasHappend(HappeningKeys.Greeting); } }

    protected override bool HasChatOptions { get { return true; } }

    protected override void OnStart()
    {
        PlaySound(this.NpcGreeting);
        Npc.Say("Bretzel? Weisswurst? Sauerkraut?");
    }

    protected override IEnumerator OnSuccess()
    {
        PlaySound(this.NpcConversationEnd);
        Npc.Say("Your meal is ready, enjoy it.");
        yield return WaitForInput();
    }

    protected override System.Collections.Generic.IEnumerable<DialogueAction> CharismaOptions()
    {
        if (this.HasHappend(HappeningKeys.Greeting))
        {
            yield return new DialogueAction("You're handsome", CharismaHandsome);
            yield return new DialogueAction("You've got a fine partner", CharismaPartner);
            yield return new DialogueAction("Let's make love", CharismaLove);
            yield return new DialogueAction("Nice hairnet", CharismaHairnet);
        }
    }

    protected override System.Collections.Generic.IEnumerable<DialogueAction> IntimidationOptions()
    {
        if (this.HasHappend(HappeningKeys.Greeting))
        {
            yield return new DialogueAction("Pee in Sauerkraut", IntimidateSauerkraut);
            yield return new DialogueAction("Bust relationship", IntimidateRelationship);
            yield return new DialogueAction("Ruin hair", IntimidateHair);
            yield return new DialogueAction("Ruin Bretzels", IntimidateBretzel);
        }
    }

    protected override System.Collections.Generic.IEnumerable<DialogueAction> IntelligenceOptions()
    {
        if (this.HasHappend(HappeningKeys.Greeting))
        {
            yield return new DialogueAction("Cheap beauty products", IntelligenceBeauty);
            yield return new DialogueAction("Sauerkraut monopoly", IntelligenceSauerkraut);
            yield return new DialogueAction("Beautiful woman", IntelligenceWomen);
            yield return new DialogueAction("Rich man", IntelligenceMen);
        }
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
            yield return new DialogueAction("How is the weather", ChatWeather);
            yield return new DialogueAction("What's up", ChatWhatsUp);
            yield return new DialogueAction("How is work", ChatHowIsWork);
            yield return new DialogueAction("How was weekend", ChatWeekend);
            yield return new DialogueAction("Favourite song", ChatFavSong);
            yield return new DialogueAction("Favourite olympic sport", ChatFavSport);
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
        Npc.Happens(HappeningKeys.Greeting);
        yield return End();
    }

    private IEnumerator GreetingPretzel()
    {
        PlaySound(this.PlayerGreetingPretzel);
        Player.Say("Bretzel.");
        yield return WaitForInput();

        PlaySound(this.NpcGreetingPretzel);
        Npc.Say("I have to find the salt first.");
        Npc.Happens(HappeningKeys.Greeting);
        yield return End();
    }

    private IEnumerator GreetingWeißwurst()
    {
        PlaySound(this.PlayerGreetingWeißwurst);
        Player.Say("Weisswurst.");
        yield return WaitForInput();

        PlaySound(this.NpcGreetingWeißwurst);
        Npc.Say("I will cook one for you.");
        Npc.Happens(HappeningKeys.Greeting);
        yield return End();
    }
    #endregion

    #region Charisma actions
    private IEnumerator CharismaHairnet()
    {
        PlaySound(this.PlayerCharismaHairnet);
        Player.Say("I really dig your hairnet.");
        yield return WaitForInput();

        PlaySound(this.NpcCharismaHairnet);
        Npc.Say("C'mon even I won't fall for that.");
        Npc.ModifyAffinity(_negativeResponse);
        yield return End();
    }

    private IEnumerator CharismaLove()
    {
        PlaySound(this.PlayerCharismaLove);
        Player.Say("Let's make funky love!");
        yield return WaitForInput();

        PlaySound(this.NpcCharismaLove);
        Npc.Say("Ewww I have a boyfriend and he is way hotter than you!");
        Npc.ModifyAffinity(_negativeResponse);
        yield return End();
    }

    private IEnumerator CharismaPartner()
    {
        PlaySound(this.PlayerCharismaPartner);
        Player.Say("You have chosen a fine young man for yourself.");
        yield return WaitForInput();

        PlaySound(this.NpcCharismaPartner);
        Npc.Say("He is the best! I like my men how I like my Sauerkraut. Simple, Unromantic and Unfunky.");
        Npc.ModifyAffinity(_positiveResponse);
        yield return End();
    }

    private IEnumerator CharismaHandsome()
    {
        PlaySound(this.PlayerCharismaHandsome);
        Player.Say("You look very handsome. Shiny hair, beautiful eyes, you're the whole package!");
        yield return WaitForInput();

        PlaySound(this.NpcCharismaHandsome);
        Npc.Say("Yes, yes. But that's something I already know.");
        Npc.ModifyAffinity(_positiveResponse);
        yield return End();
    }
    #endregion

    #region Intelligence actions
    private IEnumerator IntelligenceMen()
    {
        PlaySound(this.PlayerIntelligenceMen);
        Player.Say("With your beauty and the money of the men in Luxembourg you will have everything.");
        yield return WaitForInput();

        PlaySound(this.NpcIntelligenceMen);
        Npc.Say("But my boyfriend is the Bundeskanzler...");
        Npc.ModifyAffinity(_negativeResponse);
        yield return End();
    }

    private IEnumerator IntelligenceWomen()
    {
        PlaySound(this.PlayerIntelligenceWomen);
        Player.Say("Luxembourg has the most beautiful women in the world.");
        yield return WaitForInput();

        PlaySound(this.NpcIntelligencWomen);
        Npc.Say("What? I AM the most beautiful woman in the world!");
        Npc.ModifyAffinity(_negativeResponse);
        yield return End();
    }

    private IEnumerator IntelligenceSauerkraut()
    {
        PlaySound(this.PlayerIntelligenceSauerkraut);
        Player.Say("There is no Sauerkraut in Luxembourg... you could have the monopoly.");
        yield return WaitForInput();

        PlaySound(this.NpcIntelligenceSauerkraut);
        Npc.Say("SAUERKRAUT FOR EVERYONE, I am going to make it... big.");
        Npc.ModifyAffinity(_positiveResponse);
        yield return End();
    }

    private IEnumerator IntelligenceBeauty()
    {
        PlaySound(this.PlayerIntelligenceBeauty);
        Player.Say("Beauty produts are really, REALLY cheap in Luxembourg.");
        yield return WaitForInput();

        PlaySound(this.NpcIntelligenceBeauty);
        Npc.Say("You mean, I can be even MORE beautiful?");
        Npc.ModifyAffinity(_positiveResponse);
        yield return End();
    }
    #endregion

    #region Intimidation actions
    private IEnumerator IntimidateSauerkraut()
    {
        PlaySound(this.PlayerIntimidateSauerkraut);
        Player.Say("I will pee in your Sauerkraut.");
        yield return WaitForInput();

        PlaySound(this.NpcIntimidateSauerkraut);
        Npc.Say("nonononononononono my beautiful, sour Sauerkraut.");
        Npc.ModifyAffinity(_positiveResponse);
        yield return End();
    }

    private IEnumerator IntimidateRelationship()
    {
        PlaySound(this.PlayerIntimidateRelationship);
        Player.Say("I will tell Franz Josef about your relationship with his son and you don't want that, do you?");
        yield return WaitForInput();

        PlaySound(this.NpcIntimidateRelationship);
        Npc.Say("But, but it's not my fault that I am a Berliner.");
        Npc.ModifyAffinity(_positiveResponse);
        yield return End();
    }

    private IEnumerator IntimidateHair()
    {
        PlaySound(this.PlayerIntimidateHair);
        Player.Say("I will throw Sauerkraut in your hair!");
        yield return WaitForInput();

        PlaySound(this.NpcIntimidateHair);
        Npc.Say("You would help me with that today? The Sauerkraut makes my hair look shiny and gives it the volume.");
        Npc.ModifyAffinity(_negativeResponse);
        yield return End();
    }

    private IEnumerator IntimidateBretzel()
    {
        PlaySound(this.PlayerIntimidateBretzel);
        Player.Say("I will set your Bretzeloven to vulcanic temperatures.");
        yield return WaitForInput();

        PlaySound(this.NpcIntimidateBretzel);
        Npc.Say("I like my Bretzels how I like my coffee. Black and salty.");
        Npc.ModifyAffinity(_negativeResponse);
        yield return End();
    }
    #endregion

    #region Chat Options

    public IEnumerator ChatWeather()
    {
        PlaySound(this.PlayerChatWeather);
        Player.Say("How's the weather today?");
        yield return WaitForInput();

        PlaySound(this.NpcChatWeather);
        Npc.Say("Weisswurst weather!");
        yield return End();
    }

    public IEnumerator ChatWhatsUp()
    {
        PlaySound(this.PlayerChatWhatsUp);
        Player.Say("What's up?");
        yield return WaitForInput();

        PlaySound(this.NpcChatWhatsUp);
        Npc.Say("Just making the best and sourest Sauerkraut in the world.");
        yield return End();
    }

    public IEnumerator ChatHowIsWork()
    {
        PlaySound(this.PlayerChatHowIsWork);
        Player.Say("How's your work doing?");
        yield return WaitForInput();

        PlaySound(this.NpcChatHowIsWork);
        Npc.Say("Not much, not much, I just saw my reflection in the kitchen sink, and I have to say, I ... am.... gorgeous. I spend hours at home to look as stunning as I do.");
        yield return End();
    }

    public IEnumerator ChatWeekend()
    {
        PlaySound(this.PlayerChatLastWeekend);
        Player.Say("What were you doing last weekend?");
        yield return WaitForInput();

        PlaySound(this.NpcChatLastWeekend);
        Npc.Say("I was in the Biergarten with Hans, It wasn't fun though, his mind is occupied with worries. He Isn't sure if he is a good president. A lot of people think, that he is to young. But during his puperty it was his love for Kuckuksuhren that started the Wirtschaftswunder!");
        yield return WaitForInput();

        PlaySound(this.PlayerChatBeergarden);
        Player.Say("What is it like, being the girlfriend of the Bundeskanzler?");
        yield return WaitForInput();

        PlaySound(this.NpcChatBeergarden);
        Npc.Say("Please don't tell Franz Josef about the relationship, he wants to have a BAVARIAN girlfriend for his son, but I am from Berlin.");
        yield return End();
    }

    public IEnumerator ChatFavSong()
    {
        PlaySound(this.PlayerChatFavSong);
        Player.Say("Whats your favourit song?");
        yield return WaitForInput();

        PlaySound(this.NpcChatFavSong);
        Npc.Say("Money, Money, Money! My man, the Bundeskanzler, likes that song. He is the best man in the world, so it has to be the best song in the world.");
        yield return End();
    }

    public IEnumerator ChatFavSport()
    {
        PlaySound(this.PlayerChatFavSport);
        Player.Say("Whats your favorite Olympic sport?");
        yield return WaitForInput();

        PlaySound(this.NpcChatFavSport);
        Npc.Say("Wrestling! Sweaty Men fighting other sweaty man.");
        yield return End();
    }
    #endregion
}
