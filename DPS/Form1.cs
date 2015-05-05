using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DPS
{   
    public enum EClassType
        {
            ShadowDancer, //melee, magic
            Scorcher, // ranged, magic
            CyberEnforcer, // melee, tech
            Bulletmancer, // ranged, tech
            Kraken, // Kraken
            Spawn // Kraken Baby
        }

    public partial class Form1 : Form
    {
        PlayerCharacter player;
        PlayerCharacter guy1;
        PlayerCharacter guy2;
        PlayerCharacter guy3;

        Random rand;

        public Form1()
        {
            rand = new Random();
            InitializeComponent();
        }

        #region Scene 1 - Character Creation

        private int character = 0;

        #region Button Clicks

        private void nameAcceptButton_Click(object sender, EventArgs e)
        {
            nameInput.Enabled = false;
            nameAcceptButton.Enabled = false;
            story2.Show();
            story3.Show();
            melee.Show();
            ranged.Show();
            story2.Text = "Ah, so you\'re name\'s " + nameInput.Text + "...\r\nThat explains so much...\r\nI feel so sorry for you...";
            story3.Text = "But enough of that. Tell me about yourself, " + nameInput.Text + "...";
        }

        private void melee_Click(object sender, EventArgs e)
        {
            melee.Enabled = false;
            ranged.Hide();
            magic.Show();
            technology.Show();
        }

        private void ranged_Click(object sender, EventArgs e)
        {
            character += 1;
            ranged.Enabled = false;
            melee.Hide();
            magic.Show();
            technology.Show();
        }

        private void magic_Click(object sender, EventArgs e)
        {
            magic.Enabled = false;
            technology.Hide();
            SetClass(character);
            story4.Text = "Ah... " + player.Name + ", the " + player.ClassName + "... Very well.";
            story5.Text = "Thus, we begin our story with " + player.Name + ", the " + player.ClassName + ", on a quest to destroy Balof, the Kraken, who destroyed " + player.Name + "'s hometown.  A few months into this quest, " + player.Name + " hears a rumor in a tavern one night... Apparently a psy-comet crashed down in a nearby forest just an hour ago... Upon collision with the ground, the comets are said to shatter into millions of tiny shards which bless any living things they touch with improved health. - It isn't unheard of for a blind man to regain his sight after drinking a potion containing refined psy-dust.  Occasionally psy-comets will break into larger chunks containing more power.  Upon shattering, the psy-crystal bestows this power unto the nearest sentient being in a five meter radius.  Expecting fierce competition, " + player.Name + " heads in that direction in the hopes of acquiring a crystal.  The young " + player.ClassName + " comes across a group of three individuals already fighting for two psy-crystals.  " + player.Name + " leaps into the fray, hoping to ally with one of them and split the psy-crystals between them...";
            story4.Show();
            story5.Show();
            stage1Advance.Show();
        }

        private void technology_Click(object sender, EventArgs e)
        {
            character += 2;
            technology.Enabled = false;
            magic.Hide();
            SetClass(character);
            story4.Text = "Ah... " + player.Name + ", the " + player.ClassName + "... Very well.";
            story5.Text = "Thus, we begin our story with " + player.Name + ", the " + player.ClassName + ", on a quest to destroy Balof, the Kraken, who destroyed " + player.Name + "'s hometown.  A few months into this quest, " + player.Name + " hears a rumor in a tavern one night... Apparently a psy-comet crashed down in a nearby forest just an hour ago... Upon collision with the ground, the comets are said to shatter into millions of tiny shards which bless any living things they touch with improved health. - It isn't unheard of for a blind man to regain his sight after drinking a potion containing refined psy-dust.  Occasionally psy-comets will break into larger chunks containing more power.  Upon shattering, the psy-crystal bestows this power unto the nearest sentient being in a five meter radius.  Expecting fierce competition, " + player.Name + " heads in that direction in the hopes of acquiring a crystal.  The young " + player.ClassName + " comes across a group of three individuals already fighting for two psy-crystals.  " + player.Name + " leaps into the fray, hoping to ally with one of them and split the psy-crystals between them...";
            story4.Show();
            story5.Show();
            stage1Advance.Show();
        }

        private void light_Click(object sender, EventArgs e) // unimplemented
        {
            light.Enabled = false;
            SetClass(character);
            heavy.Hide();
            story4.Show();
            story5.Show();
            stage1Advance.Show();
        }

        private void heavy_Click(object sender, EventArgs e) // unimplemented
        {
            character += 4;
            heavy.Enabled = false;
            light.Hide();
            story4.Show();
            story5.Show();
            stage1Advance.Show();
        }

        private void startButton1_Click(object sender, EventArgs e)
        {
            stage1.Hide();
            stageCombat.Show();
            SetupCombatStage();
            Next();
        }

        #endregion

        private void SetClass(int classNo)
        {
            switch (classNo)
            {
                case 0:
                    player = new ShadowDancer(rand, nameInput.Text);
                    ally.Add(player);
                    guy1 = new Scorcher(rand);
                    enemy.Add(guy1);
                    guy2 = new CyberEnforcer(rand);
                    enemy.Add(guy2);
                    guy3 = new Bulletmancer(rand);
                    enemy.Add(guy3);
                    break;
                case 1:
                    player = new Scorcher(rand, nameInput.Text);
                    ally.Add(player);
                    guy1 = new ShadowDancer(rand);
                    enemy.Add(guy1);
                    guy2 = new CyberEnforcer(rand);
                    enemy.Add(guy2);
                    guy3 = new Bulletmancer(rand);
                    enemy.Add(guy3);
                    break;
                case 2:
                    player = new CyberEnforcer(rand, nameInput.Text);
                    ally.Add(player);
                    guy1 = new ShadowDancer(rand);
                    enemy.Add(guy1);
                    guy2 = new Scorcher(rand);
                    enemy.Add(guy2);
                    guy3 = new Bulletmancer(rand);
                    enemy.Add(guy3);
                    break;
                case 3:
                    player = new Bulletmancer(rand, nameInput.Text);
                    ally.Add(player);
                    guy1 = new ShadowDancer(rand);
                    enemy.Add(guy1);
                    guy2 = new Scorcher(rand);
                    enemy.Add(guy2);
                    guy3 = new CyberEnforcer(rand);
                    enemy.Add(guy3);
                    break;
            }
        }

        #endregion

        #region Scene 2 - First Battle

        #region Methods

        private void Scene3()
        {
            if (enemy[0] is PlayerCharacter)
            {
                ally.Add((PlayerCharacter)enemy[0]);
                enemy.Remove(enemy[0]);
                SetupCombatStage();
                log.Text = "Combat Log:\r\n";
                stageCombat.Hide();
                SetScene3Story();
                stage3.Show();
            }
        }

        private void SetScene3Story()
        {
            scene3Story.Text = "The remaining combatant falls to the ground and kneels, breathing heavily.\r\n" +
                "\"Thanks, stranger,\" the " + ally[1].ClassName + " says.  \"Those two were tough...\r\n" +
                "Who knows what woulda\' happened without you around?\"\r\n\r\n" +

                "After each of you catch your breath, the " + ally[1].ClassName + " looks up at you.  \"My name's " + ally[1].Name + ".\"\r\n" +
                "You also introduce yourself.  \"" + player.Name + ", huh?  That's a nice name... Well met!\"\r\n" +
                "\"I assume you came for a psy-crystal, right?  You saved my life; I certainly don't mind splitting these two.\"\r\n\r\n" +

                "You both shatter a crystal, and you smile as a warmth fills your entire body.\r\n" +
                "You feel as if you could walk for a week and still not be tired.\r\n" +
                "\"Wow!\" " + ally[1].Name + " says. \"That felt AMAZING!\"\r\n\r\n" +

                "After a moment, " + ally[1].Name + " turns to you and asks you about why you're here.\r\n" +
                "You decide to explain your story to your newfound friend.\r\n" +

                "\"WOW!  A Kraken!  I thought they would stay in the deeper waters,\r\n" +
                "but it seems like coastal villages just aren't safe from them...\"\r\n" +
                "A smirk appears on " + ally[1].Name + "'s face.  \"Ya know... She's probably still there...\r\n" +
                "What do ya say we go show it who's boss?\"\r\n\r\n" +

                "You agree that it would be no match for the two of you with your new powers.\r\n" +
                "After convincing the local navy to aid you, the two of you set out for the ruins of your hometown in a galley.\r\n" +
                "A few days later...  Balof emerges from the water right beside your ship...\r\n" +
                "You brace prepare yourself and prepare to take your revenge.";
        }

        #endregion

        #endregion

        #region Scene 3 - Story

        #region Button Clicks

        private void stage3Advance_Click(object sender, EventArgs e)
        {
            stage3.Hide();
            Kraken balof = new Kraken(rand);
            enemy.Add(balof);
            ally[0].LevelUp();
            ally[1].LevelUp();
            battle2 = true;
            SetupCombatStage();
            ability2.Show();
            stageCombat.Show();
            Next();
        }

        #endregion

        #endregion

        #region Scene 4 - Boss Battle

        private void Win()
        {
            stageCombat.Hide();
            if (ally.Count == 2)
                winStory2.Show();
            winScreen.Show();
        }

        private void Lose()
        {
            stageCombat.Hide();
            loseScreen.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loseExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region Combat Stage

        #region Fields

        private string action; // Sets an action to be carried out on a button click. "attack" "ability1" or "ability2"
        private string targetable; // Sets what characters are targetable. "allies" "enemies" "both" "allAllies" "allEnemies" or "all"

        private List<PlayerCharacter> ally = new List<PlayerCharacter>();
        private List<BaseCharacter> enemy = new List<BaseCharacter>();

        private bool battle2 = false;
        private bool playerTurn = false; // Whether or not it is the player's turn
        private int turn = 5; // which player character's turn it is - default to 5 (0 is first character, 1 is second)

        #endregion

        #region Methods

        /// <summary>
        /// Initiates next round.
        /// </summary>
        private void Next()
        {
            if (!battle2 && enemy.Count == 1) // If conditions are met to move to Scene 3, do so.
            {
                Scene3();
            }
            else if (battle2 && enemy.Count == 0) // If conditions are met to move to Scene 5, do so.
            {
                Win();
            }
            else if (battle2 && !ally.Contains(player))
            {
                Lose();
            }
            else // Carry out round.
            {
                bool active = false; // Set as true if an ally or enemy has a counter >= 100.

                for (int x = ally.Count - 1; x >= 0; x--) // If there is a dead ally, remove it.
                {
                    if (ally[x].IsDead())
                    {
                        AddLogText(ally[x].Name + " has died.");
                        ally.Remove(ally[x]);
                    }
                }

                for (int x = enemy.Count - 1; x >= 0; x--) // If there is a dead enemy, remove it.
                {
                    if (enemy[x].IsDead())
                    {
                        AddLogText(enemy[x].Name + " has died.");
                        enemy.Remove(enemy[x]);
                    }
                }

                SetupCombatStage();

                SetHealth(); // Update health bars.

                BaseCharacter[] order = new BaseCharacter[ally.Count + enemy.Count]; // temporary array of characters to store all combatants
                float[] ranks = new float[ally.Count + enemy.Count]; // temporary array of floats to store rank values. ranks can be negative. lowest rank goes first. rank is counter value until turn / speed

                foreach (PlayerCharacter ally_1 in ally)
                {
                    if (ally_1.Counter >= 100)
                        active = true;
                }

                foreach (BaseCharacter enemy_1 in enemy)
                {
                    if (enemy_1.Counter >= 100)
                        active = true;
                }

                if (!battle2 && enemy.Count == 1) // If it's the first battle and there is one enemy, do not activate a turn.
                    active = false;

                if (active) // Calculate whose turn it is.
                {
                    foreach (PlayerCharacter ally_1 in ally) // For each ally
                    {
                        order[ally.IndexOf(ally_1)] = ally_1; // Add ally to order array
                    }

                    foreach (BaseCharacter enemy_1 in enemy) // For each enemy
                    {
                        order[enemy.IndexOf(enemy_1) + ally.Count] = enemy_1; // Add enemy to order array
                    }

                    for (int x = 0; x < order.Count(); x++) // x is index in order array. for each member of order array
                    {
                        ranks[x] = ((float)100 - (float)order[x].Counter) / (float)order[x].Speed; // Calculate rank
                    }

                    int lowestRank = 0; // storage for index of character with lowest rank

                    for (int y = 0; y < order.Count(); y++) // for each combatant - y is index of combatant
                    {
                        if (ranks[y] < ranks[lowestRank]) // If rank of combatant is lower than rank of current soonest combatant
                            lowestRank = y; // Replace old index with index of that combatant
                    }

                    if (lowestRank < ally.Count) // If combatant with the lowest rank is an ally
                    {
                        playerTurn = true;
                        turn = lowestRank; // Sets turn to the ally
                        ability1.Text = ally[turn].Ability1Name;
                        ability2.Text = ally[turn].Ability2Name;
                        ally[turn].Ability1Timer -= 1;
                        ally[turn].Ability2Timer -= 1;
                        AddLogText("It is now " + ally[turn].Name + "\'s turn.");
                    }
                    else // If combatant is an enemy
                    {
                        enemy[lowestRank - ally.Count].Ability1Timer -= 1;
                        enemy[lowestRank - ally.Count].Ability2Timer -= 1;
                        AddLogText(enemy[lowestRank - ally.Count].Attack(ally, enemy));
                        Next();
                    }
                }

                if (!active) // If no counter is >= 100
                {
                    foreach (PlayerCharacter ally_1 in ally) // Add each ally's speed to it's counter
                    {
                        ally_1.Counter += ally_1.Speed;
                        if (ally_1.Slowed)
                        {
                            ally_1.SlowCounter -= 1;
                            if (ally_1.SlowCounter == 0)
                            {
                                ally_1.Slowed = false;
                                ally_1.Speed = ally_1.BaseSpeed;
                                AddLogText(ally_1.Name + " is no longer slowed.");
                            }
                        }
                        if (ally_1.Burned)
                        {
                            ally_1.Hp -= 1;
                            ally_1.BurnCounter -= 1;
                            if (ally_1.BurnCounter == 0)
                            {
                                ally_1.Burned = false;
                                AddLogText(ally_1.Name + " is no longer burned.");
                            }
                        }
                        if (ally_1.Bleed)
                        {
                            ally_1.Hp -= 1;
                            ally_1.BleedCounter -= 1;
                            if (ally_1.BleedCounter == 0)
                            {
                                ally_1.Bleed = false;
                                AddLogText(ally_1.Name + " is no longer bleeding.");
                            }
                        }
                    }

                    foreach (BaseCharacter enemy_1 in enemy) // Add each enemy's speed to it's counter
                    {
                        enemy_1.Counter += enemy_1.Speed;
                        if (enemy_1.Slowed)
                        {
                            enemy_1.SlowCounter -= 1;
                            if (enemy_1.SlowCounter == 0)
                            {
                                enemy_1.Slowed = false;
                                enemy_1.Speed = enemy_1.BaseSpeed;
                                AddLogText(enemy_1.Name + " is no longer slowed.");
                            }
                        }
                        if (enemy_1.Burned)
                        {
                            enemy_1.Hp -= 1;
                            enemy_1.BurnCounter -= 1;
                            if (enemy_1.BurnCounter == 0)
                            {
                                enemy_1.Burned = false;
                                AddLogText(enemy_1.Name + " is no longer burned.");
                            }
                        }
                        if (enemy_1.Bleed)
                        {
                            enemy_1.Hp -= 1;
                            enemy_1.BleedCounter -= 1;
                            if (enemy_1.BleedCounter == 0)
                            {
                                enemy_1.Bleed = false;
                                AddLogText(enemy_1.Name + " is no longer bleeding.");
                            }
                        }
                    }
                }

                Order();
                SetIndicators();

                if (!active) // If no counter is >= 100, repeat automatically.
                    Next();
            }
        }

        private void AdjustImage(EClassType classType, int number)
        {
            switch (number)
            {
                case 1:
                    switch (classType)
                    {
                        case EClassType.ShadowDancer:
                            order1.Image = global::DPS.Properties.Resources.ShadowDancer_Mini;
                            break;
                        case EClassType.Scorcher:
                            order1.Image = global::DPS.Properties.Resources.Scorcher_Mini;
                            break;
                        case EClassType.CyberEnforcer:
                            order1.Image = global::DPS.Properties.Resources.CyberEnforcer_Mini;
                            break;
                        case EClassType.Bulletmancer:
                            order1.Image = global::DPS.Properties.Resources.Bulletmancer_Mini_temp;
                            break;
                        case EClassType.Kraken:
                            order1.Image = global::DPS.Properties.Resources.Kraken_Mini;
                            break;
                        case EClassType.Spawn:
                            order1.Image = global::DPS.Properties.Resources.Spawn_Mini;
                            break;
                    }
                    break;
                case 2:
                    switch (classType)
                    {
                        case EClassType.ShadowDancer:
                            order2.Image = global::DPS.Properties.Resources.ShadowDancer_Mini;
                            break;
                        case EClassType.Scorcher:
                            order2.Image = global::DPS.Properties.Resources.Scorcher_Mini;
                            break;
                        case EClassType.CyberEnforcer:
                            order2.Image = global::DPS.Properties.Resources.CyberEnforcer_Mini;
                            break;
                        case EClassType.Bulletmancer:
                            order2.Image = global::DPS.Properties.Resources.Bulletmancer_Mini_temp;
                            break;
                        case EClassType.Kraken:
                            order2.Image = global::DPS.Properties.Resources.Kraken_Mini;
                            break;
                        case EClassType.Spawn:
                            order2.Image = global::DPS.Properties.Resources.Spawn_Mini;
                            break;
                    }
                    break;
                case 3:
                    switch (classType)
                    {
                        case EClassType.ShadowDancer:
                            order3.Image = global::DPS.Properties.Resources.ShadowDancer_Mini;
                            break;
                        case EClassType.Scorcher:
                            order3.Image = global::DPS.Properties.Resources.Scorcher_Mini;
                            break;
                        case EClassType.CyberEnforcer:
                            order3.Image = global::DPS.Properties.Resources.CyberEnforcer_Mini;
                            break;
                        case EClassType.Bulletmancer:
                            order3.Image = global::DPS.Properties.Resources.Bulletmancer_Mini_temp;
                            break;
                        case EClassType.Kraken:
                            order3.Image = global::DPS.Properties.Resources.Kraken_Mini;
                            break;
                        case EClassType.Spawn:
                            order3.Image = global::DPS.Properties.Resources.Spawn_Mini;
                            break;
                    }
                    break;
                case 4:
                    switch (classType)
                    {
                        case EClassType.ShadowDancer:
                            order4.Image = global::DPS.Properties.Resources.ShadowDancer_Mini;
                            break;
                        case EClassType.Scorcher:
                            order4.Image = global::DPS.Properties.Resources.Scorcher_Mini;
                            break;
                        case EClassType.CyberEnforcer:
                            order4.Image = global::DPS.Properties.Resources.CyberEnforcer_Mini;
                            break;
                        case EClassType.Bulletmancer:
                            order4.Image = global::DPS.Properties.Resources.Bulletmancer_Mini_temp;
                            break;
                        case EClassType.Kraken:
                            order4.Image = global::DPS.Properties.Resources.Kraken_Mini;
                            break;
                        case EClassType.Spawn:
                            order4.Image = global::DPS.Properties.Resources.Spawn_Mini;
                            break;
                    }
                    break;
                case 5:
                    switch (classType)
                    {
                        case EClassType.ShadowDancer:
                            order5.Image = global::DPS.Properties.Resources.ShadowDancer_Mini;
                            break;
                        case EClassType.Scorcher:
                            order5.Image = global::DPS.Properties.Resources.Scorcher_Mini;
                            break;
                        case EClassType.CyberEnforcer:
                            order5.Image = global::DPS.Properties.Resources.CyberEnforcer_Mini;
                            break;
                        case EClassType.Bulletmancer:
                            order5.Image = global::DPS.Properties.Resources.Bulletmancer_Mini_temp;
                            break;
                        case EClassType.Kraken:
                            order5.Image = global::DPS.Properties.Resources.Kraken_Mini;
                            break;
                        case EClassType.Spawn:
                            order5.Image = global::DPS.Properties.Resources.Spawn_Mini;
                            break;
                    }
                    break;
                case 6:
                    switch (classType)
                    {
                        case EClassType.ShadowDancer:
                            order6.Image = global::DPS.Properties.Resources.ShadowDancer_Mini;
                            break;
                        case EClassType.Scorcher:
                            order6.Image = global::DPS.Properties.Resources.Scorcher_Mini;
                            break;
                        case EClassType.CyberEnforcer:
                            order6.Image = global::DPS.Properties.Resources.CyberEnforcer_Mini;
                            break;
                        case EClassType.Bulletmancer:
                            order6.Image = global::DPS.Properties.Resources.Bulletmancer_Mini_temp;
                            break;
                        case EClassType.Kraken:
                            order6.Image = global::DPS.Properties.Resources.Kraken_Mini;
                            break;
                        case EClassType.Spawn:
                            order6.Image = global::DPS.Properties.Resources.Spawn_Mini;
                            break;
                    }
                    break;
                case 7:
                    switch (classType)
                    {
                        case EClassType.ShadowDancer:
                            order7.Image = global::DPS.Properties.Resources.ShadowDancer_Mini;
                            break;
                        case EClassType.Scorcher:
                            order7.Image = global::DPS.Properties.Resources.Scorcher_Mini;
                            break;
                        case EClassType.CyberEnforcer:
                            order7.Image = global::DPS.Properties.Resources.CyberEnforcer_Mini;
                            break;
                        case EClassType.Bulletmancer:
                            order7.Image = global::DPS.Properties.Resources.Bulletmancer_Mini_temp;
                            break;
                        case EClassType.Kraken:
                            order7.Image = global::DPS.Properties.Resources.Kraken_Mini;
                            break;
                        case EClassType.Spawn:
                            order7.Image = global::DPS.Properties.Resources.Spawn_Mini;
                            break;
                    }
                    break;
                case 8:
                    switch (classType)
                    {
                        case EClassType.ShadowDancer:
                            order8.Image = global::DPS.Properties.Resources.ShadowDancer_Mini;
                            break;
                        case EClassType.Scorcher:
                            order8.Image = global::DPS.Properties.Resources.Scorcher_Mini;
                            break;
                        case EClassType.CyberEnforcer:
                            order8.Image = global::DPS.Properties.Resources.CyberEnforcer_Mini;
                            break;
                        case EClassType.Bulletmancer:
                            order8.Image = global::DPS.Properties.Resources.Bulletmancer_Mini_temp;
                            break;
                        case EClassType.Kraken:
                            order8.Image = global::DPS.Properties.Resources.Kraken_Mini;
                            break;
                        case EClassType.Spawn:
                            order8.Image = global::DPS.Properties.Resources.Spawn_Mini;
                            break;
                    }
                    break;
                case 9:
                    switch (classType)
                    {
                        case EClassType.ShadowDancer:
                            order9.Image = global::DPS.Properties.Resources.ShadowDancer_Mini;
                            break;
                        case EClassType.Scorcher:
                            order9.Image = global::DPS.Properties.Resources.Scorcher_Mini;
                            break;
                        case EClassType.CyberEnforcer:
                            order9.Image = global::DPS.Properties.Resources.CyberEnforcer_Mini;
                            break;
                        case EClassType.Bulletmancer:
                            order9.Image = global::DPS.Properties.Resources.Bulletmancer_Mini_temp;
                            break;
                        case EClassType.Kraken:
                            order9.Image = global::DPS.Properties.Resources.Kraken_Mini;
                            break;
                        case EClassType.Spawn:
                            order9.Image = global::DPS.Properties.Resources.Spawn_Mini;
                            break;
                    }
                    break;
                case 10:
                    switch (classType)
                    {
                        case EClassType.ShadowDancer:
                            order10.Image = global::DPS.Properties.Resources.ShadowDancer_Mini;
                            break;
                        case EClassType.Scorcher:
                            order10.Image = global::DPS.Properties.Resources.Scorcher_Mini;
                            break;
                        case EClassType.CyberEnforcer:
                            order10.Image = global::DPS.Properties.Resources.CyberEnforcer_Mini;
                            break;
                        case EClassType.Bulletmancer:
                            order10.Image = global::DPS.Properties.Resources.Bulletmancer_Mini_temp;
                            break;
                        case EClassType.Kraken:
                            order10.Image = global::DPS.Properties.Resources.Kraken_Mini;
                            break;
                        case EClassType.Spawn:
                            order10.Image = global::DPS.Properties.Resources.Spawn_Mini;
                            break;
                    }
                    break;
            }
        }

        private void Order()
        {
            BaseCharacter[] order = new BaseCharacter[ally.Count + enemy.Count]; // temporary array of characters to store all combatants
            int[] times = new int[ally.Count + enemy.Count]; // temporary array of ints to store # of times each combatant has gone in simulation
            float[] ranks = new float[ally.Count + enemy.Count]; // temporary array of floats to store rank values. ranks can be negative. lowest rank goes first. rank is (counter value until turn + turns taken in simulation) / speed

            foreach (PlayerCharacter ally_1 in ally) // For each ally
            {
                order[ally.IndexOf(ally_1)] = ally_1; // Add ally to order array
            }

            foreach (BaseCharacter enemy_1 in enemy) // For each enemy
            {
                order[enemy.IndexOf(enemy_1) + ally.Count] = enemy_1; // Add enemy to order array
            }

            for (int x = 0; x < order.Count(); x++) // x is index in order array. for each member of order array
            {
                times[x] = 0; // Set times gone as 0
                ranks[x] = ((float)100 - (float)order[x].Counter + (float)(times[x] * 100)) / (float)order[x].Speed; // Calculate rank
            }

            for (int x = 1; x <= 10; x++) // for each x image holder
            {
                int lowestRank = 0; // storage for index of character with lowest rank

                for (int y = 0; y < order.Count(); y++) // for each combatant - y is index of combatant
                {
                    if (ranks[y] < ranks[lowestRank]) // If rank of combatant is lower than rank of current soonest combatant
                        lowestRank = y; // Replace old index with index of that combatant
                }

                AdjustImage(order[lowestRank].ClassType, x); // Adust Image to display class image of combatant with lowest rank in image holder x
                times[lowestRank]++; // Add one time gone to lowest rank combatant
                ranks[lowestRank] = ((float)100 - (float)order[lowestRank].Counter + (float)(times[lowestRank] * 100)) / (float)order[lowestRank].Speed; // recalculate combatant's rank
            }
        }

        private void SetIndicators()
        {
            switch (turn)
            {
                case 0:
                    turnIndicator0.Show();
                    turnIndicator1.Hide();
                    break;
                case 1:
                    turnIndicator0.Hide();
                    turnIndicator1.Show();
                    break;
                default:
                    turnIndicator0.Hide();
                    turnIndicator1.Hide();
                    break;
            }
        }

        private void SetupCombatStage()
        {
            if (ally.Count == 0) // If there are no allies, hide ally controls.
            {
                ally0.Hide();
                ally0HP.Hide();
                ally1.Hide();
                ally1HP.Hide();
            }
            else if (ally.Count == 1) // If one ally, show one ally control.
            {
                ally0.Show();
                ally0HP.Show();
                ally0.Text = ally[0].Name;
                SetupAlly0Image();
                ally0HP.Maximum = ally[0].MaxHp;
                ally0HP.Value = ally[0].Hp;
                ally1.Hide();
                ally1HP.Hide();
            }
            else // If two allies, show two ally controls.
            {
                ally0.Show();
                ally0HP.Show();
                ally0.Text = ally[0].Name;
                SetupAlly0Image();
                ally0HP.Maximum = ally[0].MaxHp;
                ally0HP.Value = ally[0].Hp;
                ally1.Show();
                ally1HP.Show();
                ally1.Text = ally[1].Name;
                SetupAlly1Image();
                ally1HP.Maximum = ally[1].MaxHp;
                ally1HP.Value = ally[1].Hp;
            }

            if (enemy.Count == 0) // If there are no enemies, hide enemy controls.
            {
                enemy0.Hide();
                enemy0HP.Hide();
                enemy1.Hide();
                enemy1HP.Hide();
                enemy2.Hide();
                enemy2HP.Hide();
            }
            else if (enemy.Count == 1) // If there is one enemy, show one enemy control.
            {
                enemy0.Show();
                enemy0HP.Show();
                enemy0.Text = enemy[0].Name;
                SetupEnemy0Image();
                enemy0HP.Maximum = enemy[0].MaxHp;
                enemy0HP.Value = enemy[0].Hp;
                enemy1.Hide();
                enemy1HP.Hide();
                enemy2.Hide();
                enemy2HP.Hide();
            }
            else if (enemy.Count == 2) // If there are two enemies, show two enemy controls.
            {
                enemy0.Show();
                enemy0HP.Show();
                enemy0.Text = enemy[0].Name;
                SetupEnemy0Image();
                enemy0HP.Maximum = enemy[0].MaxHp;
                enemy0HP.Value = enemy[0].Hp;
                enemy1.Show();
                enemy1HP.Show();
                enemy1.Text = enemy[1].Name;
                SetupEnemy1Image();
                enemy1HP.Maximum = enemy[1].MaxHp;
                enemy1HP.Value = enemy[1].Hp;
                enemy2.Hide();
                enemy2HP.Hide();
            }
            else // If there are three enemies, show three enemy controls.
            {
                enemy0.Show();
                enemy0HP.Show();
                enemy0.Text = enemy[0].Name;
                SetupEnemy0Image();
                enemy0HP.Maximum = enemy[0].MaxHp;
                enemy0HP.Value = enemy[0].Hp;
                enemy1.Show();
                enemy1HP.Show();
                enemy1.Text = enemy[1].Name;
                SetupEnemy1Image();
                enemy1HP.Maximum = enemy[1].MaxHp;
                enemy1HP.Value = enemy[1].Hp;
                enemy2.Show();
                enemy2HP.Show();
                enemy2.Text = enemy[2].Name;
                SetupEnemy2Image();
                enemy2HP.Maximum = enemy[2].MaxHp;
                enemy2HP.Value = enemy[2].Hp;
            }
            if (battle2) // If it is th second battle, show the ability2 button
                ability2.Show();

        }

        private void SetupAlly0Image()
        {
            switch (ally[0].ClassType)
                    {
                        case EClassType.ShadowDancer:
                            ally0.Image = global::DPS.Properties.Resources.ShadowDancer;
                            break;
                        case EClassType.Scorcher:
                            ally0.Image = global::DPS.Properties.Resources.Scorcher;
                            break;
                        case EClassType.CyberEnforcer:
                            ally0.Image = global::DPS.Properties.Resources.CyberEnforcer;
                            break;
                        case EClassType.Bulletmancer:
                            ally0.Image = global::DPS.Properties.Resources.Bulletmancer_temp;
                            break;
                        case EClassType.Kraken:
                            ally0.Image = global::DPS.Properties.Resources.Kraken;
                            break;
                        case EClassType.Spawn:
                            ally0.Image = global::DPS.Properties.Resources.Spawn;
                            break;
                    }
        }

        private void SetupAlly1Image()
        {
            switch (ally[1].ClassType)
            {
                case EClassType.ShadowDancer:
                    ally1.Image = global::DPS.Properties.Resources.ShadowDancer;
                    break;
                case EClassType.Scorcher:
                    ally1.Image = global::DPS.Properties.Resources.Scorcher;
                    break;
                case EClassType.CyberEnforcer:
                    ally1.Image = global::DPS.Properties.Resources.CyberEnforcer;
                    break;
                case EClassType.Bulletmancer:
                    ally1.Image = global::DPS.Properties.Resources.Bulletmancer_temp;
                    break;
                case EClassType.Kraken:
                    ally1.Image = global::DPS.Properties.Resources.Kraken;
                    break;
                case EClassType.Spawn:
                    ally1.Image = global::DPS.Properties.Resources.Spawn;
                    break;
            }
        }

        private void SetupEnemy0Image()
        {
            switch (enemy[0].ClassType)
            {
                case EClassType.ShadowDancer:
                    enemy0.Image = global::DPS.Properties.Resources.ShadowDancer;
                    break;
                case EClassType.Scorcher:
                    enemy0.Image = global::DPS.Properties.Resources.Scorcher;
                    break;
                case EClassType.CyberEnforcer:
                    enemy0.Image = global::DPS.Properties.Resources.CyberEnforcer;
                    break;
                case EClassType.Bulletmancer:
                    enemy0.Image = global::DPS.Properties.Resources.Bulletmancer_temp;
                    break;
                case EClassType.Kraken:
                    enemy0.Image = global::DPS.Properties.Resources.Kraken;
                    break;
                case EClassType.Spawn:
                    enemy0.Image = global::DPS.Properties.Resources.Spawn;
                    break;
            }
        }

        private void SetupEnemy1Image()
        {
            switch (enemy[1].ClassType)
            {
                case EClassType.ShadowDancer:
                    enemy1.Image = global::DPS.Properties.Resources.ShadowDancer;
                    break;
                case EClassType.Scorcher:
                    enemy1.Image = global::DPS.Properties.Resources.Scorcher;
                    break;
                case EClassType.CyberEnforcer:
                    enemy1.Image = global::DPS.Properties.Resources.CyberEnforcer;
                    break;
                case EClassType.Bulletmancer:
                    enemy1.Image = global::DPS.Properties.Resources.Bulletmancer_temp;
                    break;
                case EClassType.Kraken:
                    enemy1.Image = global::DPS.Properties.Resources.Kraken;
                    break;
                case EClassType.Spawn:
                    enemy1.Image = global::DPS.Properties.Resources.Spawn;
                    break;
            }
        }

        private void SetupEnemy2Image()
        {
            switch (enemy[2].ClassType)
            {
                case EClassType.ShadowDancer:
                    enemy2.Image = global::DPS.Properties.Resources.ShadowDancer;
                    break;
                case EClassType.Scorcher:
                    enemy2.Image = global::DPS.Properties.Resources.Scorcher;
                    break;
                case EClassType.CyberEnforcer:
                    enemy2.Image = global::DPS.Properties.Resources.CyberEnforcer;
                    break;
                case EClassType.Bulletmancer:
                    enemy2.Image = global::DPS.Properties.Resources.Bulletmancer_temp;
                    break;
                case EClassType.Kraken:
                    enemy2.Image = global::DPS.Properties.Resources.Kraken;
                    break;
                case EClassType.Spawn:
                    enemy2.Image = global::DPS.Properties.Resources.Spawn;
                    break;
            }
        }

        private void SetHealth()
        {
            if (ally.Count == 1)
            {
                ally0HP.Value = ally[0].Hp;
            }
            else if (ally.Count == 2)
            {
                ally0HP.Value = ally[0].Hp;
                ally1HP.Value = ally[1].Hp;
            }
            if (enemy.Count == 1)
            {
                enemy0HP.Value = enemy[0].Hp;
            }
            if (enemy.Count == 2)
            {
                enemy0HP.Value = enemy[0].Hp;
                enemy1HP.Value = enemy[1].Hp;
            }
            if (enemy.Count == 3)
            {
                enemy0HP.Value = enemy[0].Hp;
                enemy1HP.Value = enemy[1].Hp;
                enemy2HP.Value = enemy[2].Hp;
            }
        }

        /// <summary>
        /// Adds a line of text to the combat log.
        /// </summary>
        /// <param name="text">Text to be added to the log.</param>
        private void AddLogText(string text)
        {
            log.Text += text + "\r\n"; // Enter line of text and go to next line.
            //Scroll to bottom of log.
            log.SelectionStart = log.Text.Length;
            log.ScrollToCaret();
        }

        #endregion

        #region Button Clicks

        private void ally0_Click(object sender, EventArgs e)
        {
            if (targetable == "allies" || targetable == "all")
            {
                switch (action)
                {
                    case "ability1":
                        AddLogText(ally[turn].Ability1(ally[0]));
                        turn = 5;
                        targetable = "";
                        playerTurn = false;
                        break;
                    case "ability2":
                        AddLogText(ally[turn].Ability2(ally[0]));
                        turn = 5;
                        targetable = "";
                        playerTurn = false;
                        break;
                }
            }
        }

        private void ally1_Click(object sender, EventArgs e)
        {
            if (targetable == "allies" || targetable == "all")
            {
                switch (action)
                {
                    case "ability1":
                        AddLogText(ally[turn].Ability1(ally[1]));
                        turn = 5;
                        targetable = "";
                        playerTurn = false;
                        break;
                    case "ability2":
                        AddLogText(ally[turn].Ability2(ally[1]));
                        turn = 5;
                        targetable = "";
                        playerTurn = false;
                        break;
                }
            }
        }

        private void Enemy0_Click(object sender, EventArgs e)
        {
            if (targetable == "enemies" || targetable == "all")
            {
                switch (action)
                {
                    case "attack":
                        AddLogText(ally[turn].Attack(enemy[0]));
                        turn = 5;
                        targetable = "";
                        playerTurn = false;
                        break;
                    case "ability1":
                        AddLogText(ally[turn].Ability1(enemy[0]));
                        turn = 5;
                        targetable = "";
                        playerTurn = false;
                        break;
                    case "ability2":
                        AddLogText(ally[turn].Ability2(enemy[0]));
                        turn = 5;
                        targetable = "";
                        playerTurn = false;
                        break;
                }
                Next();
                enemy0_MouseEnter(enemy0, e);
            }
        }

        private void Enemy1_Click(object sender, EventArgs e)
        {
            if (targetable == "enemies" || targetable == "all")
            {
                switch (action)
                {
                    case "attack":
                        AddLogText(ally[turn].Attack(enemy[1]));
                        turn = 5;
                        targetable = "";
                        playerTurn = false;
                        break;
                    case "ability1":
                        AddLogText(ally[turn].Ability1(enemy[1]));
                        turn = 5;
                        targetable = "";
                        playerTurn = false;
                        break;
                    case "ability2":
                        AddLogText(ally[turn].Ability2(enemy[1]));
                        turn = 5;
                        targetable = "";
                        playerTurn = false;
                        break;
                }
                Next();
                enemy1_MouseEnter(enemy1, e);
            }
        }

        private void Enemy2_Click(object sender, EventArgs e)
        {
            if (targetable == "enemies" || targetable == "all")
            {
                switch (action)
                {
                    case "attack":
                        AddLogText(ally[turn].Attack(enemy[2]));
                        turn = 5;
                        targetable = "";
                        playerTurn = false;
                        break;
                    case "ability1":
                        AddLogText(ally[turn].Ability1(enemy[2]));
                        turn = 5;
                        targetable = "";
                        playerTurn = false;
                        break;
                    case "ability2":
                        AddLogText(ally[turn].Ability2(enemy[3]));
                        turn = 5;
                        targetable = "";
                        playerTurn = false;
                        break;
                }
                Next();
                enemy2_MouseEnter(enemy2, e);
            }
        }

        private void attack_Click(object sender, EventArgs e)
        {
            if (playerTurn)
            {
                action = "attack";
                targetable = "enemies";
                AddLogText("Select an enemy.");
            }
        }

        private void ability1_Click(object sender, EventArgs e)
        {
            if (playerTurn && ally[turn].Ability1Timer == 0)
            {
                action = "ability1";
                targetable = ally[turn].Ability1Target;
                switch (targetable)
                {
                    case "allies":
                        AddLogText("Select an ally.");
                        break;
                    case "enemies":
                        AddLogText("Select an enemy.");
                        break;
                    case "all":
                        AddLogText("Select a target.");
                        break;
                    default :
                        AddLogText(ally[turn].Ability1(ally, enemy));
                        turn = 5;
                        targetable = "";
                        playerTurn = false;
                        Next();
                        break;
                }
            }

        }

        private void ability2_Click(object sender, EventArgs e)
        {
            if (playerTurn && ally[turn].Ability2Timer == 0)
            {
                action = "ability2";
                targetable = ally[turn].Ability2Target;
                switch (targetable)
                {
                    case "allies":
                        break;
                    case "enemies":
                        break;
                    case "both":
                        break;
                    default:
                        AddLogText(ally[turn].Ability2(ally, enemy));
                        turn = 5;
                        targetable = "";
                        playerTurn = false;
                        Next();
                        break;
                }
            }
        }

        #endregion

        #region Mouseovers

        //character mouseovers show stats in statsBox
        private void ally0_MouseEnter(object sender, EventArgs e)
        {
            if (ally.Count > 0)
            {
                statsBox.Text = "HP: " + ally[0].Hp + "/" + ally[0].MaxHp + "\r\n" +
                    "Speed: " + ally[0].Speed + "\r\n" +
                    "Turn Counter: " + ally[0].Counter + "/100\r\n" +
                    "Power: " + ally[0].Power + "\r\n" +
                    "Defence: " + ally[0].Defence;
            }
        }

        private void ally0_MouseLeave(object sender, EventArgs e)
        {
            statsBox.Text = "HP:\r\n" +
                "Speed:\r\n" +
                "Turn Counter:\r\n" +
                "Power:\r\n" +
                "Defence:";
        }

        private void ally1_MouseEnter(object sender, EventArgs e)
        {
            if (ally.Count > 1)
            {
                statsBox.Text = "HP: " + ally[1].Hp + "/" + ally[1].MaxHp + "\r\n" +
                    "Speed: " + ally[1].Speed + "\r\n" +
                    "Turn Counter: " + ally[1].Counter + "/100\r\n" +
                    "Power: " + ally[1].Power + "\r\n" +
                    "Defence: " + ally[1].Defence;
            }
        }

        private void ally1_MouseLeave(object sender, EventArgs e)
        {
            statsBox.Text = "HP:\r\n" +
                "Speed:\r\n" +
                "Turn Counter:\r\n" +
                "Power:\r\n" +
                "Defence:";
        }

        private void enemy0_MouseEnter(object sender, EventArgs e)
        {
            if (enemy.Count > 0)
            {
                statsBox.Text = "HP: " + enemy[0].Hp + "/" + enemy[0].MaxHp + "\r\n" +
                    "Speed: " + enemy[0].Speed + "\r\n" +
                    "Turn Counter: " + enemy[0].Counter + "/100\r\n" +
                    "Power: " + enemy[0].Power + "\r\n" +
                    "Defence: " + enemy[0].Defence;
            }
        }

        private void enemy0_MouseLeave(object sender, EventArgs e)
        {
            statsBox.Text = "HP:\r\n" +
                "Speed:\r\n" +
                "Turn Counter:\r\n" +
                "Power:\r\n" +
                "Defence:";
        }

        private void enemy1_MouseEnter(object sender, EventArgs e)
        {
            if (enemy.Count > 1)
            {
                statsBox.Text = "HP: " + enemy[1].Hp + "/" + enemy[1].MaxHp + "\r\n" +
                    "Speed: " + enemy[1].Speed + "\r\n" +
                    "Turn Counter: " + enemy[1].Counter + "/100\r\n" +
                    "Power: " + enemy[1].Power + "\r\n" +
                    "Defence: " + enemy[1].Defence;
            }
        }

        private void enemy1_MouseLeave(object sender, EventArgs e)
        {
            statsBox.Text = "HP:\r\n" +
                "Speed:\r\n" +
                "Turn Counter:\r\n" +
                "Power:\r\n" +
                "Defence:";
        }

        private void enemy2_MouseEnter(object sender, EventArgs e)
        {
            if (enemy.Count > 2)
            {
                statsBox.Text = "HP: " + enemy[2].Hp + "/" + enemy[2].MaxHp + "\r\n" +
                    "Speed: " + enemy[2].Speed + "\r\n" +
                    "Turn Counter: " + enemy[2].Counter + "/100\r\n" +
                    "Power: " + enemy[2].Power + "\r\n" +
                    "Defence: " + enemy[2].Defence;
            }
        }

        private void enemy2_MouseLeave(object sender, EventArgs e)
        {
            statsBox.Text = "HP:\r\n" +
                "Speed:\r\n" +
                "Turn Counter:\r\n" +
                "Power:\r\n" +
                "Defence:";
        }

        // action mouseovers show the action's description in ActionText
        private void attack_MouseEnter(object sender, EventArgs e)
        {
            if (turn != 5)
                actionText.Text = ally[turn].AttackDescription;
            else
            {
                actionText.Text = "This is the description of an attack.\r\n" +
                    "Base Damage: (power/2)-(power)";
            }
        }

        private void attack_MouseLeave(object sender, EventArgs e)
        {
            actionText.Text = "";
        }

        private void ability1_MouseEnter(object sender, EventArgs e)
        {
            if (turn != 5)
            {
                actionText.Text = "Turns Until Usable: " + ally[turn].Ability1Timer + "\r\n";
                actionText.Text += ally[turn].Ability1Description;
            }
            else
            {
                actionText.Text = "This is the description for the first ability.\r\n" +
                    "Base Damage: (ability specific)\r\n" +
                    "(abilty specific extra)";
            }
        }

        private void ability1_MouseLeave(object sender, EventArgs e)
        {
            actionText.Text = "";
        }

        private void ability2_MouseEnter(object sender, EventArgs e)
        {
            if (turn != 5)
            {
                actionText.Text = "Turns Until Usable: " + ally[turn].Ability2Timer + "\r\n";
                actionText.Text += ally[turn].Ability2Description;
            }
            else
            {
                actionText.Text = "This is the description for the second ability.\r\n" +
                    "Damage Before Defence: (ability specific)\r\n" +
                    "(abilty specific extra";
            }
        }

        private void ability2_MouseLeave(object sender, EventArgs e)
        {
            actionText.Text = "";
        }

        #endregion

        #endregion
    }
}
