
#<img src = "https://github.com/zachdimitrov/ThunderFighter/blob/master/images/TF-Logo.png" width = 100px alt = "Thinder Fighter by Team Hestia"> Thunder Fighter  
###### by Team Hestia<sup>®</sup>

## Game Story

   In the not so near future.  
City of Sofia, Bulgaria.  
Boyana, Dragalevtsi and even Losenets became filthy getos where no one wants to live or visit any more! The best place in Sofia where all rich people live now is district of Obelya.  
###<img src = "https://github.com/zachdimitrov/ThunderFighter/blob/master/Images/Story.png" width = 880px alt = "Story of TF">
   **Year 2066.**  
Scientists from the world leading research facilities of **БАН** made a great discovery!   
A wormhole - a portal to another dimention, a double sided path to unexplored reality.  
Unfortuantely worlds in this dimention were populated by evil and ruthless creatures!  
They istantly penetrated the hole trying to invade our world starting with Obelya!  
They came with their killing machines and built tall and ugly towers in the middle of our beautiful district.  
No one could manage to stop them! The only thing that could resist the endless flow of evil flying aliens is - **Thunder Fighter**!  
Created by a brave team of C# developers Thunder Fighter is the only salvation.  
Your mission is to control it and kill as many evils as possible  

### Game Purpose

You have the **Thunder Fighter** in your hands (on the left of your screen). Control it using the control keys and kill the evils that come from the right.  
You can use bullets or bombs to kill enemies. Use only bombs to destroy evil pointed towers. Please do not destroy human houses and панелки or ЕПК, because real people live there! Each kill gains you points but also annoys the enemy and they come more and more. Your task is to kill as many enemies and destroy as many towers as you can!  
Remember they are endless!  
Good luck!

### The Console

Why we use the console, but not a fancy modern 3D realistic graphics?  
The answer is simple - smallest data ammount, because it's war time and data transfer should be kept to minimum!  
*And it's the best way to practice OOP of course.* :)  
You can choose among three color themes - white, black and blue. Themes are changed in the 'Game' class.

## Screen shots

<img src = "https://github.com/zachdimitrov/ThunderFighter/blob/master/Images/Play-White.png" height = 210px alt = "Game White">
<img src = "https://github.com/zachdimitrov/ThunderFighter/blob/master/Images/Play-Black.png" height = 210px alt = "Game Black">
<img src = "https://github.com/zachdimitrov/ThunderFighter/blob/master/Images/Play-Blue.png" height = 210px alt = "Game Blue">

## Controls

##### Move

key|key name|action
---|---|---
< | Left arrow | Move left
> | Right arrow | Move rigt
^ | Up arrow | Move up
v | Down arrow | Move down

##### Shoot

key|action
---|---
Space | Shoot bullets
B     | Throw bombs

##### Other

key|action
---|---
P     | Pause
Enter | Start game (on welcome screen)
Ecs   | Exit

# OOP Teamwork Project

### Team "Hestia"
1. Мирослав Марков - **marks**
 - Team leader and main game developer. 
 - Created the game plan, the main game structure and all required things that make the game fluent and working well. 
 - Also spent a lot of time in general game items.
2. Деляна Коларова - **Dellyana**
 - Major developer. 
 - Created many important parts of the game, including keyboard handling and message screens. 
3. Захари Димитров - **ZachD**
 - Graphic designer. 
 - Responsible mostly for graphic representation of the game.
 - Created heroes, buildings and menu appearance. 
 - Also spent some time on other code parts.
4. Ивайло Иванов - **Ivailo.P.Ivanov**  
 - Gave the idea for this type of game.  
5. Владислав Спасов - **vladislav_spass** 
 - ?  
6. Лени Йорданов - **Leni_Yordanov** 
 - ?  
7. Павел ТВ - **Jango** 
 - ?  

### Initial Game Plan

* 1.картинка за нашия самолет  
  - 1.1 картинка при попадение от изстрел на вражески самолет  
  - 1.2 картинка при сблъсък на нашия самолет с вражески
* 2. добавяне на нов вид Enemy (само картинката). Вижте как става в класа Fighter, метод private static List<Pixel> FighterBody(Point2D pos)  
  - 2.1 картинка при попадение от изстрел  
  - 2.2 картинка при попадение от ракета    
  - 2.3 картинка при сблъсък с нашия самолет  
* 3. добавяне на нов вид Building (само картинката). Същото като точка 1.  
  - 3.1 картинка при попадение от бомба  
* 4. добавяне на възможност самолета да стреля
* 5. добавяне на възможност самолета да изстрелва ракети
* 6. добавяне на възможност самолета да хвърля бомби
* 7. детектване на колизиите Enemies-Player
* 8. детектване на колизиите Enemies-Bullets
* 9. детектване на колизиите Bombs-Buildings
* 10. добавяне на панел с точки, животи, меню с клавиши за управление на играта и т.н.
* 11. движение на Enemies (само някои от тях на случаен принцип, без да се блъскат един в друг и да излизат постепенно от игралното поле)

### Class Diagram

<img src = "https://github.com/zachdimitrov/ThunderFighter/blob/master/Images/ClassDiagram.png" height = 210px alt = "Class Diagram">

### Other remarks
-
-
-
