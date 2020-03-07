// Project created for the AP Computer Science Principles Create Task
// By Mark Rizko
// Loyola High School Class of 2017
using UnityEngine;
using UnityEngine.UI;

public class TextStory : MonoBehaviour {
	public int HP, time, HPMAX = 100, EMAX = 100;
	// Create UI object of type "Text" in order to change scene text
	public Text text,hp_bar,time_bar,control;
	// Each state of the game will correspond to "Levels"
	private enum Levels{intro, intro_2, getout_1, enter_1, out_of_time,dead, duel_0, getout_2, 
	blast_0, chop_0, bleedout, chop_1, bleedout_alt, win_screen, help_death, escape_pod, yell,
	enter_2,pullback_0, surrender, charge}
	// currentLevel will keep track of level user is on
	private Levels currentLevel;
	// Start function is only called once when game is ran
	void Start () {
		time = 100;
		HP = 50;
		// Sets starting level to intro, rest is done in Update function
		currentLevel = Levels.intro;
	}
	
	// Update is called once per frame
	void Update () {
		// HP and Time variables control their corresponding text elements in the UI
		// Setting HP and Time so that if they are single digits, a 0 appears before them, for asthetics
		if (HP <10){
			hp_bar.text = 0.ToString() + HP.ToString();
		}
		else {
			hp_bar.text = HP.ToString();
		}
		if (time <10){
			time_bar.text = 0.ToString() + time.ToString();
		}
		else {
			time_bar.text = time.ToString();
		}
		// Define maximum values of HP and Time
		if (HP > HPMAX) {
			HP = 100;
		}
		if (time > EMAX){
			time = 100;
		}
		// print current level to the console for testing purposes
		print(currentLevel);
		// Attaches function to each level
		switch (currentLevel) {
			case Levels.intro:
			lvl_intro();
			break;
			case Levels.intro_2:
			lvl_intro_2();
			break;
			case Levels.out_of_time:
			time_up();
			break;
			case Levels.getout_1:
			lvl_getout_1();
			break;
			case Levels.enter_1:
			lvl_enter_1();
			break;
			case Levels.duel_0:
			lvl_duel_0();
			break;
			case Levels.blast_0:
			lvl_blast_0();
			break;
			case Levels.chop_0:
			lvl_chop_0();
			break;
			case Levels.bleedout:
			lvl_bleedout();
			break;
			case Levels.dead:
			death();
			break;
			case Levels.bleedout_alt:
			lvl_bleedout_alt();
			break;
			case Levels.chop_1:
			lvl_chop_1();
			break;
			case Levels.win_screen:
			lvl_win_screen();
			break;
			case Levels.help_death:
			lvl_help_death();
			break;
			case Levels.escape_pod:
			lvl_escape_pod();
			break;
			case Levels.getout_2:
			lvl_getout_2();
			break;
			case Levels.yell:
			lvl_yell();
			break;
			case Levels.enter_2:
			lvl_enter_2();
			break;
			case Levels.pullback_0:
			lvl_pullback_0();
			break;
			case Levels.charge:
			lvl_charge();
			break;
			case Levels.surrender:
			lvl_surrender();
			break;


		}
		// Death and time out scenarios
		// HP and time are set to 0 so the UI does not display a negative number and overlap text
		if (time <= 0){
			time = 0;
			currentLevel = Levels.out_of_time;
		}
		if (HP <= 0){
			HP = 0;
			currentLevel = Levels.dead;
		}
	}
	void lvl_intro() {
			// text.text controls main text on screen
			text.text = "Lotheus the wise looms over to the deck of the spaceship, blaster in hand, " +
			"the fate of his great empire is at stake. The enemy forces have advanced and taken over " +
			"his once mighty fleet of officers.";
			// control.text controls text on bottom of screen prompting an action
			control.text = "Press C to continue...";
			// will change current level when user presses the specific key it asks for
			if (Input.GetKeyDown(KeyCode.C)){
				currentLevel = Levels.intro_2;
			}
		}

	void lvl_intro_2() {
		text.text = "You and your master Shoquun are slowly looming outside to cockpit, "+
		"listening and waiting for the perfect time to act. You look over at Shoquun:\n\n"+
		"1. 'We should get out of here and warn the fleet.'\n\n2. 'I'm tired of waiting!! Let's "+
		"take them on!'";
		control.text = "Press A for option 1. Press B for option 2.";
		if (Input.GetKeyDown(KeyCode.A)){
			time -=15;
			currentLevel = Levels.getout_1;
		}
		else if (Input.GetKeyDown(KeyCode.B)){
			time -= 10;
			currentLevel = Levels.enter_1;
		}
	} 
	void time_up() {
		text.text = "You have run out of time!! The imperial army has taken over your base "+
		"and all hope for the universe is lost!";
		control.text = "Press any key to restart with extra time...";
		if (Input.anyKeyDown){
			currentLevel = Levels.intro;
			time = 120;
			HP = 50;
		}
	}
	void death() {
		text.text = "YOU HAVE DIED";
		control.text = "Press any key to restart with an HP boost...";
		if (Input.anyKeyDown){
			currentLevel = Levels.intro;
			time = 100;
			HP = 60;
		}
	}
	void lvl_getout_1(){
		text.text = "You start running for the escape pods when BLAM! Shoquun is hit in the shoulder "+
		"by a laser blast from one of the imperial officers on duty. You reach for your plasma saber when "+
		"you feel a cold wind fall upon you and your master. Your master is telling you to go without him " +
		"but you can't leave your best friend behind.. Do you stay and help him or run?" ;
		control.text = "Press S to stay and help.. Press R to save yourself.";
		if (Input.GetKeyDown(KeyCode.S)){
			time -= 10;
			currentLevel = Levels.duel_0;
		}
		else if (Input.GetKeyDown(KeyCode.R)){
			currentLevel = Levels.getout_2;
			time -= 20;
		}
	}
	void lvl_getout_2() {
		text.text = "You run for the turbine room when you hear a loud scream from your master "+
		"behind you. You turn around but it's too late. You see a patch of darkness fall over the ship "+
		"and see your master's body left on the ground. Your commanding officer comes onto the comm and tells you "+
		"to head for the escape pods and flee.";
		control.text = "Press A to flee. Press B to go to Shoquun.";
		if (Input.GetKeyDown(KeyCode.A)){
			currentLevel = Levels.escape_pod;
		}
		else if (Input.GetKeyDown(KeyCode.B)){
			currentLevel = Levels.help_death;
		}
	}
	void lvl_enter_1(){
		text.text = "You charge into the room and see Lotheus the Wise speaking to the dark lord "+
		"Xandar. Upon your intrusion, imperial guards are immediately sent your way as you and your master "+
		"quickly dispose of them and advance on Lotheus, who fires three shots on you.\n'There's too many, my apprentice "+
		"we must leave quickly', your master tells you.";
		control.text = "Press A to advance. Press B to pull back.";
		if (Input.GetKeyDown(KeyCode.A)){
			currentLevel = Levels.enter_2;
		}
		else if (Input.GetKeyDown(KeyCode.B)){
			currentLevel = Levels.pullback_0;
			time = 1;
		}
	}
	void lvl_enter_2(){
		text.text = "'Master we can take them!!!'\nYou charge the dark lord and Lotheus only to have your "+
		"saber blasted immediately by Lotheus and now you lay pinned by the dark saber of Xandar.\n"+
		"'Surrender weakling, or die.'All of a sudden Shoquun yells and charges for the dark lord to his demise, "+
		"as he's taken down immediately. You see an opening.";
		control.text = "Press A to charge him. Press B to surrender.";
		if (Input.GetKeyDown(KeyCode.A)){
			currentLevel = Levels.charge;
		}
		else if (Input.GetKeyDown(KeyCode.B)){
			time -= 10;
			HP -= 35;
			currentLevel = Levels.surrender;
		}
	}
	void lvl_duel_0(){
		text.text = "You turn around and find the door behind you slowly opening, revealing " +
		"the dark Lord Xandar and his imperial escort. 'You've grown since I've last witnessed your "+
		"power, boy,' he states. 'Now, prepare to die.' He ignites his dark, black saber, the embodiement of evil.";
		control.text = "Press A to blast him. Press B to take out your saber and fight.";
		if (Input.GetKeyDown(KeyCode.A)){
			time -= 5;
			HP -= 30;
			currentLevel = Levels.blast_0;
		}
		else if (Input.GetKeyDown(KeyCode.B)){
			time -= 10;
			HP -= 15;
			currentLevel = Levels.chop_0;
		}
	}
	void lvl_blast_0(){
		text.text = "You fire three blaster shots to distract him, but he deflects all of them, "+
		"one of them even hits you in the shoulder, injuring you. All of a sudden, he's charged by " +
		"Shoquun, your master and a great battle breaks out. You're stuck on the floor, bleeding out.\n\n1. Yell for your "+
		"master to help you.\n\n2. Fire more shots on the dark lord and help Shoquun.";
		control.text = "Press A for option 1. Press B for option 2.";
		if (Input.GetKeyDown(KeyCode.A)){
			currentLevel = Levels.yell;
			time -= 14;
		}
		else if (Input.GetKeyDown(KeyCode.B)){
			// Takes health to single digits in any scenario for the bleedout cases, for dramatic effect
			if (HP % 10 == 0){
				HP = 5;
			}
			else {
			HP = HP % 10;
			}
			time -= 20;
			currentLevel = Levels.bleedout;
		}
	}
	void lvl_chop_0(){
		text.text = "Unsheating your saber and charging it up, you charge towards the dark lord, " +
		"exchanging blow after blow for some time. You know you're no match for his strength, but thank God "+
		"you have your master with you to support you. He charges at Xandar and disables his comm system, allowing you to "+
		"slice through and slice his arm off. He throws you back against the wall and goes for your master. You can throw the saber up or " +
		"towards Xandar, your decision is crucial.";
		control.text = "A to throw it up. B to throw it to Xandar.";
		if (Input.GetKeyDown(KeyCode.A)){
			currentLevel = Levels.chop_1;
		}
		else if (Input.GetKeyDown(KeyCode.B)){
			if (HP % 10 == 0){
				HP = 5;
			}
			else {
			HP = HP % 10;
			}
			time -= 10;
			currentLevel = Levels.bleedout_alt;
		}
	}
	void lvl_bleedout(){
		text.text = "You fire at the dark lord, and again he deflects them back to you. You sit there, "+
		"bleeding as you watch him take down your master and come for you. The evil forces have won this battle, " +
		"and conquered the galaxy once again. The dark lord Xandar stands over you now, saber to your throat.\n\n"+
		"'Prepare to be slain, scum.'";
		control.text = "Press D to die...";
		if (Input.GetKeyDown(KeyCode.D)){
			HP  -= 100;
		}
	}
	void lvl_bleedout_alt(){
		text.text = "You throw your saber at the dark lord, and he grabs the saber in the air and throws it back to you, severely wounding you. "+
		"You sit there, bleeding as you watch him take down your master and come for you. The evil forces have won this battle, " +
		"and conquered the galaxy once again. The dark lord Xandar stands over you now, saber to your throat.\n\n"+
		"'Prepare to be slain, scum.'";
		control.text = "Press D to die...";
		if (Input.GetKeyDown(KeyCode.D)){
			HP  -= 100;
		}
	}
	void lvl_chop_1(){
		text.text = "You toss your saber up towards the ceiling, hitting one of the main "+
		"air vents and blinding Xandar. Thanks to your distractions, "+
		"Shoquun is able to execute the dark lord, just in time for your reinforcements to come in. "+
		"Your squadron takes ove the grand ship, arresting Lotheus the Wise and ending this galactic war.";
		control.text = "Press any key to proceed.";
		if (Input.anyKeyDown){
			currentLevel = Levels.win_screen;
		}
	}
	void lvl_win_screen(){
		text.text = "Congratulations, you have taken over the galaxy once again and restored order and peace."+
		"Thank you for playing my game!! I hope you (and the "+
		"AP correctors) enjoy this game as much as I enjoyed making it!";
		control.text = "Press any key to play again.";
		if (Input.anyKeyDown){
			Start();
		}
	}
	void lvl_escape_pod(){
		text.text = "A selfish decision was made. At the end of the battle, you live but the galaxy "+
		"falls into crysis and turmoil due to your lack of courage. This is no victory, but is the story over?"+
		"\n\nTO BE CONTINUED...";
		control.text = "Press any key to play again.";
		if (Input.anyKeyDown){
			Start();
		}
	}
	void lvl_help_death(){
		text.text = "You run to your master but it's too late... His lifeless body lies "+
		"on the floor. Before you can escape, the room goes pitch black. You power on your laser "+
		"saber, but it's too late...\nAll of a sudden you feel cold and fall to the floor...";
		control.text = "Press any key to continue...";
		if (Input.anyKeyDown){
			HP -=100;
		}
	}
	void lvl_yell(){
		text.text = "You see Shoquun across the room, now engaged in battle with the dark lord. "+
		"Yelling for his help, you see three imperial troopers storm into the room and focus fire on your master. "+
		"Shoquun finally looks over at your distress call, but to his demise. In his distraction, he is "+
		"slain by the dark lord and takes five blaster shots to the chest. They now start to advance on you "+
		"as this might finally be the end for you";
		control.text = "Press any key to continue...";
		if (Input.anyKeyDown){
			currentLevel = Levels.dead;
		}
	}
	void lvl_pullback_0(){
		text.text = "You pull back from the front lines and head for the escape pods, "+
		"only issue is that you've wasted so much time in the cell that you may not even "+
		"have time to do anything else before they destroy the rebel defenses. (Hint:YOU DON'T)";
		control.text = "Press any key to continue...";
		if (Input.anyKeyDown){
			time -=100;
		}
	}
	void lvl_surrender(){
		text.text = "You lay your head down, accepting defeat. Lotheus places you under arrest "+
		"before the dark lord Xandar interjects, 'We're not taking prisoners today....'";
		control.text = "Press D to die...";
		if (Input.GetKeyDown(KeyCode.D)){
			currentLevel = Levels.dead;
		}
	}
	void lvl_charge(){
		text.text = "You see your opportunity, and you take it. Charging at Xandar, you catch him "+
		"off guard as he releases his grasp from your master and falls to the floor.\nShoquun, now free, "+
		"disarms Lotheus and puts him under arrest. You have taken the enemy ship and won this battle.";
		control.text = "Press any key to continue...";
		if (Input.anyKeyDown){
			currentLevel = Levels.win_screen;
		}
	}
}

