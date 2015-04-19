using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class HBMDialog : Dialogue
{
    #region Npc Sound Files
    public AudioClip NpcGreeting;
    public AudioClip NpcOk;

    public AudioClip NpcCharismaGreetingThanks;
    public AudioClip NpcCharismaWonder;
    public AudioClip NpcCharismaMercedes;
    public AudioClip NpcCharismaLoveYou;
    public AudioClip NpcCharismaPanzerGeneral;

    public AudioClip NpcChatWeatherMercedes;
    public AudioClip NpcChatMotionOfNoConfidence;
    public AudioClip NpcChatWarForDummies;
    public AudioClip NpcChatBeerGarden;
    public AudioClip NpcChatMoney;
    public AudioClip NpcChatOlympic;
    public AudioClip NpcChatFather;

    public AudioClip NpcIntimidateRevealB;
    public AudioClip NpcIntimidateBUnknown;
    public AudioClip NpcIntimidateScratchCar;
    public AudioClip NpcIntimidateHurtFather;
    public AudioClip NpcIntimidateBWrong;
    public AudioClip NpcIntimidateFeedDog;

    public AudioClip NpcIntelligenceGreetingHow;
    public AudioClip NpcIntelligenceTaxSystem;
    public AudioClip NpcIntelligenceMilitary;
    public AudioClip NpcIntelligenceMilitarySmall;
    public AudioClip NpcIntelligenceWomen;
    public AudioClip NpcIntelligenceWorldLeader;
    #endregion

    #region Player Sound Files
    public AudioClip PlayerIntimidateGreeting;

    public AudioClip PlayerCharismaGreeting;
    public AudioClip PlayerCharismaWonder;
    public AudioClip PlayerCharismaMercedes;
    public AudioClip PlayerCharismaLoveYou;
    public AudioClip PlayerCharismaPanzerGeneral;

    public AudioClip PlayerChatWeather;
    public AudioClip PlayerChatWhatsUp;
    public AudioClip PlayerChatHowIsWork;
    public AudioClip PlayerChatLastWeekend;
    public AudioClip PlayerChatFavSong;
    public AudioClip PlayerChatFavSport;
    public AudioClip PlayerChatFather;

    public AudioClip PlayerIntimidateRevealB;
    public AudioClip PlayerIntimidateScratchCar;
    public AudioClip PlayerIntimidateHurtFather;
    public AudioClip PlayerIntimidateFeedDog;

    public AudioClip PlayerIntelligenceGreeting;
    public AudioClip PlayerIntelligenceTaxSystem;
    public AudioClip PlayerIntelligenceMilitary;
    public AudioClip PlayerIntelligenceMilitarySmall;
    public AudioClip PlayerIntelligenceWomen;
    public AudioClip PlayerIntelligenceWorldLeader;
    public AudioClip PlayerIntimidateRevealBWrongNames;


    #endregion

    private string[] mercedesMonolog = new string[] {
        "blabla"
    };

    private string[] Names { get { return new string[] { "Bambi?", "Bärbel?", "Belzebub?", "Bernd?", "Brokkoli?" }; } }

    protected override bool HasCharismaOptions { get { return true; } }
    protected override bool HasIntimidationOptions { get { return true; } }
    protected override bool HasIntelligenceOptions { get { return true; } }
    protected override bool HasChatOptions { get { return this.HasHappend(HappeningKeys.Greeting); } }

    protected override void OnStart()
    {
        PlaySound(this.NpcGreeting);
        Npc.Say(
            "How did you get here?");
    }

    protected override IEnumerator OnSuccess()
    {
        Npc.Say( "TODO: OnSuccess()" );
        yield return WaitForInput();
    }

    #region Menu
    protected override IEnumerable<DialogueAction> CharismaOptions()
    {
        if (!this.HasHappend(HappeningKeys.Greeting))
        {
            yield return new DialogueAction("Praise", CharismaGreeting);
        }
        else
        {
            yield return new DialogueAction("Like Mercedes?", CharismaMercedes);
            yield return new DialogueAction("Good work", CharismaWonder);
            yield return new DialogueAction("I love you", CharismaLoveYou);
            yield return new DialogueAction("Panzer general", CharismaPanzerGeneral);
        }
    }

    protected override IEnumerable<DialogueAction> IntimidationOptions()
    {
        if (!this.HasHappend(HappeningKeys.Greeting))
        {
            yield return new DialogueAction("Shut up", IntimidateGreeting);
        }
        else
        {
            yield return new DialogueAction("Reveal the B", IntimidateRevealB);
            yield return new DialogueAction("Scratch car", IntimidateScratchCar);
            yield return new DialogueAction("Hurt father", IntimidateHurtFather);
            yield return new DialogueAction("Feed dog", IntimidateFeedDog);
        }
    }

    protected override IEnumerable<DialogueAction> IntelligenceOptions()
    {
        if (!this.HasHappend(HappeningKeys.Greeting))
        {
            yield return new DialogueAction("Help him", IntelligenceGreeting);
        }
        else
        {
            yield return new DialogueAction("Tax system", IntelligenceTaxSystem);
            yield return new DialogueAction("military", IntelligenceMilitary);
            yield return new DialogueAction("Hot women", IntelligenceWoman);
            yield return new DialogueAction("World leader", IntelligenceWorldLeader);
        }
    }

    protected override IEnumerable<DialogueAction> ChatOptions()
    {
        yield return new DialogueAction("How is the weather", ChatWeather);
        yield return new DialogueAction("What's up", ChatWhatsUp);
        yield return new DialogueAction("How is work", ChatHowIsWork);
        yield return new DialogueAction("How was weekend", ChatWeekend);
        yield return new DialogueAction("Favourite song", ChatFavSong);
        yield return new DialogueAction("Favourite olympic sport", ChatFavSport);
        yield return new DialogueAction("Met father", ChatFather);
    }
    #endregion

    #region Intelligence Options
    private IEnumerator IntelligenceGreeting()
    {
        PlaySound(this.PlayerIntelligenceGreeting);
        Player.Say("I am qualified to help you.");
        yield return WaitForInput();

        PlaySound(this.NpcIntelligenceGreetingHow);
        Npc.Say("But, but, how?... And with what?");
        Npc.Happens(HappeningKeys.Greeting);
        yield return End();
    }

    private IEnumerator IntelligenceTaxSystem()
    {
        PlaySound(this.PlayerIntelligenceTaxSystem);
        Player.Say("Ok so you ever heard about the",
            "\"Dynamic Tax System\" we use in Luxembourgh?",
            "We practically take from the poor and",
            "give it to rich people like you");
        yield return WaitForInput();

        PlaySound(this.NpcIntelligenceTaxSystem);
        Npc.Say("That sounds awesome, I tried",
            "to change the german tax system for years");
        Npc.ModifyAffinity(10f);

        yield return End();
    }

    private IEnumerator IntelligenceMilitary()
    {
        PlaySound(this.PlayerIntelligenceMilitary);
        Player.Say("So, you're struggeling with",
            "the management of your military?");
        yield return WaitForInput();

        PlaySound(this.NpcIntelligenceMilitary);
        Npc.Say("Tactics are way to complicated,",
            "I thought war should be fun.",
            "But there are sooo many tanks",
            "that need attention.");
        yield return WaitForInput();

        PlaySound(this.PlayerIntelligenceMilitarySmall);
        Player.Say("Brother, well I have a treat for you:",
            "Luxembourg only has one single tank!");
        yield return WaitForInput();

        PlaySound(this.NpcIntelligenceMilitarySmall);
        Npc.Say("That sounds like something even I",
            "can manage.");
        Npc.ModifyAffinity(10f);
        yield return End();
    }

    private IEnumerator IntelligenceWorldLeader()
    {
        PlaySound(this.PlayerIntelligenceWorldLeader);
        Player.Say("How about: You could be the new",
            "world leader and order around",
            "every tank on this planet!");
        yield return WaitForInput();

        PlaySound(this.NpcIntelligenceWorldLeader);
        Npc.Say("More tanks? Nooooooooooo");
        Npc.ModifyAffinity(-20f);
        yield return End();
    }

    private IEnumerator IntelligenceWoman()
    {
        PlaySound(this.PlayerIntelligenceWomen);
        Player.Say("So, you look like a man who has great taste in women.",
            "And Luxemburg has the most beautiful",
            "women in the world.");
        yield return WaitForInput();

        PlaySound(this.NpcIntelligenceWomen);
        Npc.Say("No thanks, I already got the best girlfriend.");
        Npc.ModifyAffinity(-10f);
        yield return End();
    }
    #endregion

    #region Intimidate Options
    public IEnumerator IntimidateGreeting()
    {
        PlaySound(this.PlayerIntimidateGreeting);
        Player.Say("Shut up, it doesn't matter.");
        yield return WaitForInput();

        PlaySound(this.NpcOk);
        Npc.Say("Ok");
        Npc.Happens(HappeningKeys.Greeting);
        yield return End();
    }

    public IEnumerator IntimidateRevealB()
    {
        PlaySound(this.PlayerIntimidateRevealB);
        Player.Say("Hey brother! I know what the \"B\"",
            "in your name stands for");
        yield return WaitForInput();

        if (this.Player.HasHappend(HappeningKeys.SecondName))
        {
            PlaySound(this.NpcIntimidateRevealB);
            Npc.Say(
                "Oh, please don't tell anyone!",
                "They will know about my heritage!");
            Npc.ModifyAffinity(20f);
            yield return End();
        }
        else if (!this.HasHappend(HappeningKeys.SaidWrongName))
        {
            PlaySound(this.NpcIntimidateBUnknown);
            Npc.Say("No, NO, that can't be true, how would you know");
            yield return WaitForInput();

            PlaySound(this.PlayerIntimidateRevealBWrongNames);
            Player.Say("I think it's Bambi!",
                "Oh, no, no no: Bärbel!",
                "It MUST be Beelzebub!",
                "BERND! I'm sure, it's Bernd.",
                "...or... Broccoli?");
            Npc.Happens(HappeningKeys.SaidWrongName);
            yield return WaitForInput();

            PlaySound(this.NpcIntimidateBWrong);
            Npc.Say("Mmmnnnyeaaaah... thats not it.");
            Npc.ModifyAffinity(-20f);
            yield return End();
        }
    }
    
    public IEnumerator IntimidateScratchCar()
    {
        PlaySound(this.PlayerIntimidateScratchCar);
        Player.Say(
            "Shiny Mercedes you got out there, ",
            "would be a shame if something were to happen to it...");

        yield return WaitForInput();

        PlaySound(this.NpcIntimidateScratchCar);
        Npc.Say("Oh no! Please don't hurt it!");
        Npc.ModifyAffinity(10f);

        yield return End();
    }

    public IEnumerator IntimidateHurtFather()
    {
        PlaySound(this.PlayerIntimidateHurtFather);
        Player.Say("I will hurt your father ... bad!",
            "Real bad! Mhhhh...");

        yield return WaitForInput();

        PlaySound(this.NpcIntimidateHurtFather);
        Npc.Say("You can't hurt him, ",
            "he was Schützenmeister five years in a row!",
            "And I don't... even... like him.");
        Npc.ModifyAffinity(-10f);

        yield return End();
    }

    public IEnumerator IntimidateFeedDog()
    {
        PlaySound(this.PlayerIntimidateFeedDog);
        Player.Say("I will give your dog treats, until",
            "he is the fattest dog in the world!");
        yield return WaitForInput();

        PlaySound(this.NpcIntimidateFeedDog);
        Npc.Say("Ahm... I... don't... have a dog.");
        Npc.ModifyAffinity(-10f);
        yield return End();
    }
    #endregion

    #region Charisma Options
    public IEnumerator CharismaGreeting()
    {
        PlaySound(this.PlayerCharismaGreeting);
        Player.Say("I wanted to thank you for doing such an amazing job, ruling Germany.");
        yield return WaitForInput();

        PlaySound(this.NpcCharismaGreetingThanks);
        Npc.Say("Thank you... I guess?");
        Npc.Happens(HappeningKeys.Greeting);

        yield return End();
    }

    public IEnumerator CharismaWonder()
    {
        PlaySound(this.PlayerCharismaWonder);
        Player.Say("Having started the Wirtschaftswunder proves your capability as a leader!");
        yield return WaitForInput();

        PlaySound(this.NpcCharismaWonder);
        Npc.Say("You seem to be the only one who can remember that.");

        yield return End();
    }

    public IEnumerator CharismaMercedes()
    {
        PlaySound(this.PlayerCharismaMercedes);
        Player.Say("So you like Mercedes cars? I like them too!");
        yield return WaitForInput();

        PlaySound(this.NpcCharismaMercedes);
        Npc.Say(this.mercedesMonolog);

        yield return End();
    }

    public IEnumerator CharismaLoveYou()
    {
        PlaySound(this.PlayerCharismaLoveYou);
        Player.Say("You gimme the funk, brother!",
            "How about some hot man on man action?",
            "Mmmh, I would like that...");
        yield return WaitForInput();

        PlaySound(this.NpcCharismaLoveYou);
        Npc.Say("First of, you are way to funky,",
            "secondly I got a Girlfriend.");
        Npc.ModifyAffinity(-20f);
        yield return End();
    }

    public IEnumerator CharismaPanzerGeneral()
    {
        PlaySound(this.PlayerCharismaPanzerGeneral);
        Player.Say("You seem to be a fine panzer general.");
        yield return WaitForInput();

        PlaySound(this.NpcCharismaPanzerGeneral);
        Npc.Say("Straight up lie!");
        Npc.ModifyAffinity(-10f);
        yield return End();
    }
    #endregion

    #region Chat Options

    public IEnumerator ChatWeather()
    {
        PlaySound(this.PlayerChatWeather);
        Player.Say("How's the weather today?");
        yield return WaitForInput();

        PlaySound(this.NpcChatWeatherMercedes);
        Npc.Say("It's great. Finally I can drive my awesome mercedes again!");
        yield return WaitForInput();

        PlaySound(this.NpcCharismaMercedes);
        Npc.Say(this.mercedesMonolog);

        yield return End();
    }

    public IEnumerator ChatWhatsUp()
    {
        PlaySound(this.PlayerChatWhatsUp);
        Player.Say("What's up?");
        yield return WaitForInput();

        PlaySound(this.NpcChatMotionOfNoConfidence);
        Npc.Say("I'm a bit worried about the",
            "motion of no confidence.",
            "Maybe I'll loose my position",
            "soon... It's an age thing.");

        yield return End();
    }

    public IEnumerator ChatHowIsWork()
    {
        PlaySound(this.PlayerChatHowIsWork);
        Player.Say("How's your work doing?");
        yield return WaitForInput();

        PlaySound(this.NpcChatWarForDummies);
        Npc.Say("I'm trying to read \"War for Dummies\".",
            "Those military stategies are really complicated!",
            "Did you know that Germany has more than 1500 Tanks,",
            "and they all want to be commanded.");

        yield return End();
    }

    public IEnumerator ChatWeekend()
    {
        PlaySound(this.PlayerChatLastWeekend);
        Player.Say("What were you doing last weekend?");
        yield return WaitForInput();

        PlaySound(this.NpcChatBeerGarden);
        Npc.Say("I've visited the beer garden",
            "with my girlfriend. We had Weißwurst and Sauerkraut.");

        yield return End();
    }

    public IEnumerator ChatFavSong()
    {
        PlaySound(this.PlayerChatFavSong);
        Player.Say("Whats your favourit song?");
        yield return WaitForInput();

        PlaySound(this.NpcChatMoney);
        Npc.Say("Money, Money, Money!");

        yield return End();
    }

    public IEnumerator ChatFavSport()
    {
        PlaySound(this.PlayerChatFavSport);
        Player.Say("Whats your favorite Olympic sport?");
        yield return WaitForInput();

        PlaySound(this.NpcChatOlympic);
        Npc.Say("I don't like the Olympic Games,",
            "they're so expensive.",
            "I'm already paying such a huge amount",
            "of taxes and all is going to these useless sports!",
            "Did you know, that the more money you have,",
            "the more you have to give to the tax office?",
            "Even I, as president...");

        yield return End();
    }

    public IEnumerator ChatFather()
    {
        PlaySound(this.PlayerChatFather);
        Player.Say("I met your dad.");
        yield return WaitForInput();

        PlaySound(this.NpcChatFather);
        Npc.Say("Mwuhaha I made him my little bodyguard,",
            "I never liked him, he was never there when",
            "I needed him. Always at the Schützenverein!",
            "Suddenly, when I was voted Bundeskanzler,",
            "he wanted to be there for me.");
        yield return End();
    }

    #endregion

}
