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
    }
```