# Space Invaders
Windows Forms Project by: Nikola Dimov
***
## 1. Опис на проектот
Со цел да обезбедам задоволство и носталгија кај играчот, самиот дизајн е направен едноставен и со ретро елементи, имплементиран е код за креирање, чување и бришење на сметката на корисникот каде се чуваат неговите последно достигнати поени.
## 2. Упатство за користење
### 2.1 Креирање на сметка
![alt text](https://github.com/DimovNikola/SpaceInvaders/blob/master/createAccount.png "Create Account")

Креирањето на сметка е едноставно.
При стартување на апликацијата се отвора прозорец како на „слика 1“. Доколку сакате да додадете нова сметка, тогаш најпрвин го пополнувате празното поле со вашето име. Потоа со притискање на копчето „Create Account“ ја креирате вашата нова сметка при што ќе бидете известени како и на самата слика.

### 2.2 Бришење на сметка
![alt text](https://github.com/DimovNikola/SpaceInvaders/blob/master/deleteAccount.png "Delete Account")

Бришењето на сметка се извршува така што ја селектирате сметката која што сакате да ја избришите и притискате на дугмето „Delete Account“, при што ќе се отвори прозорец на кој треба да потврдите дали сакате да ја избришете селектираната сметка, како и што е прикажано на „слика 2“.

### 2.3 Стартување на играта
![alt text](https://github.com/DimovNikola/SpaceInvaders/blob/master/playGame.png "Play Game")

Доколку сакате да ја стартувате играта, тоа го правите така што ја селектирате сметката на која што сакате да се зачуваат вашите поени и потоа притискате на копчето „Play“ како што е прикажано на „слика 3“ со што се отвора новиот прозорец каде што започнува самата игра („слика 4“). 

![alt text](https://github.com/DimovNikola/SpaceInvaders/blob/master/gameplay.png "Gameplay")

Моментот кога ќе се стартува апликацијата излегува прозорец за да се отвори документот каде што се чуваат сметките. Откако ќе заврши играта излегува истиот прозорец но овој пат за да се зачува новиот број на достигнати поени. Ова е постигнато користејки *серијализација*. Новите поени зачувани на сметката ќе се прикажат при следното стартување на самата апликација!

### 2.4 Правила на играта
* Играта никогаш не се победува!
* После секој уништен бран од непријатели се појавуа нов бран со нови непријатели
* вашата цел е што подолго време да избегнете колизија помеѓу некои од непријателите и „борбената линија“ на херојот(висината на која што се наоѓа херојот на самата „мапа“). Ова се постигнува со уништување на непријателот.

## 3. Претставување на проблемот
Главните податоци и функции се чуваат во класата GameMap која што наследува од класата Form. 
```c#
public partial class GameMap : Form
    {
        Form1 form = new Form1();
        //move left
        bool goLeft = false;
        //move right
        bool goRight = false;
        //speed for enemies
        int speed = 1;
        //overall score
        int score = 0;
        //if button is pressed
        bool isPressed;
        //keep the number of enemies (added dynamically)
        int totalEnemies = 0;
        //the players speed
        int playerSpeed = 6;
        //account document
        AccountDoc accDoc;
        //an account
        Account account;
        //name of the file used to store accounts
        private String FileName;
        //gameplay audio
        private SoundPlayer soundPlayer;
        //game over audio
        private SoundPlayer soundPlayer1;
        //list to keep all of the enemies
        List<Control> enemies = new List<Control>();
    }
```

При секое стартување на играта, се читаат сметките од фајлот каде што се чуваат, а при завршување на играта се зачувуваат во истиот фајл. Ова работи со серијализација и десеријализација.

```c#
[Serializable]
public class AccountDoc
```
```c#
[Serializable]
public class Account : ISerializable
```

Со цел да се изврши серијализација и десеријализација се користат следните функции:

* saveFile() ; Да се зачуваат податоци во посебен фајл.
* openFile() ; Да се отвори фајлот и да се прочитаат зачуваните податоци.

### 3.1 Алгоритми
Со цел да се достигни функционалноста на самата програма потребно е создавањето на специфични функции. Некои од користените функции се:

* newDoc() ; Се користи за креирање нов „документ“ за сметки.
* fillList() ; Ја пополнува листата со непријатели.

    Во оваа функција ја повикуваме и функцијата *generateEnemy(int x, int y);* преку која генерираме нов непријател(слика со свои димензии, свој таг и координати).

* generateNewWave() ; Генерира нов бран од непријатели.
* timer1_Tick(object sender, EventArgs e) ; Многу битна функција која што овозможува движење на самите слики во формата (непријатели/херој/куршуми). Без оваа функција формата ќе беше само „замрзната“ слика.

    Како дел од оваа функција спаѓаат и функциите *updateEnemiesPosition();* која што воедно ги проверува дали куршумите се надвор од мапата, дали непријателот пристигна до висината на херојот и дали има колизија помеѓу куршум и непријател.
    Исто така се користи и функцијата *generateNewWave();* која што ја повикува функцијата *fillList();* и додава нови непријатели односно нов бран.
    
* shootBullet() ; Генерира нов „куршум“ односно нова слика од куршум со свои димензии и координати.

* gameOver() ; Го означува крајот на играта. 

***
***

# 1. Documentation in English

## 1. Description
This application represents the classic arcade game Space Invaders. However even if it's not exactly the same as the original, it is fairly close to it. The application design is in a retro like style, the game has some functionalities such as saving and deleting the accounts along with their last scores.

## 2. Instructions
When the first window opens you have the options to create a new account by filling the empty textbox with your name and clicking on the "Create Account" button. After that you are able to select an account and press the "Play" button. When the button "Play" is pressed, a new form will appear that represents the actuall game. 

## 2.1 Instructions to play the game
You play the game by using the left and right keys on your keyboard to move your character left and right.When You press the spacebar on your keyboard your character (the hero) will shoot at the enemies who are dropping down twords him. If the enemies bounds intersect with your characters bounds the game is over!

## 2.2 What's the goal?

* The goal here is to get as manny points as possible by killing more and more enemies! 
* The game cannot be won!
* New waves of enemies will appear after the previous wave is destroyed! 

# Licence:
#License This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.

# Disclaimer:
1. I am not the legal owner of the audio files nor images used in this project!
2. The song used in the gameplay is "I am the program" by "Mega Drive"
3. Given that the project is a non profit one, I have no intent of gaining any financial income (nor any kind of income) whilst using content I do not own.
4. This is a school project and it will remain as such.