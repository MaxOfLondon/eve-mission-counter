# eve-mission-counter
EVE Online faction standing mission counter with skin mode

Don't know about you but I am kinda forgetful when it comes to remembering how many missions I run for particular faction (any NPC corp agent on the same level) when working towards faction standing and I can never tell how many more I need to run to get a storyline mission. You could look at the agent's standings to inspect all contributing transactions but with time it becomes easy to lose track especially if you are running missions for multiple NPC corps within same faction. 

Using tool is simple. Install, add characters you want to keep track of then every time you hand in your mish click the +1 button to increase selected level count. You can also edit numbers in place if you want to start from a different count (press F2 or double click the number to edit). Next time you launch EVEMC all counts will load up and you can continue clocking up from where you left off. After 16 missions the count will reset. To add new, change or delete an existing character right-click on its name and select relevant command. To switch to skinned mode select the count you will be increasing then click Skin Mode button. Mini counter can be moved around the screen by dragging the count number to desired location. To exit skin mode right-click on the number.

This code is provided 'as is' without any direct or implied warranties. In return I appreciate feedback on how you use it and any suggestions of how it could be improved. In the future, depending on the interest, I might consider building online database and adding synchronisation mechanism so counts could be easily shared between computers if you are playing on more than one.

## Installation
- Clone repo
- Run `dotnet build -c release` to compile
- Run generated EVE Mission Counter.exe

## How to use

A new default character named "Character 1" will be created when you run program for the first time. Right-click on "Character 1" name and select Rename to name it as you want. 

To add more or delete characters right-click on character name then select New or Delete. An xml file with character name is created in the folder where the exe is which tracks progress.

Select the level of an agent you are running mission for faction the agent belongs to by clicking inside grid and after you complete a mission click '+1' button to increase the count.

To use counter in the skin mode select the counter you want to be increasing on the grid then click 'Skin mode' button. To exit skin mode right-click anywhere on the counter. To move skin to different position drag it by its border (top of counter where the number is).

P.S. This program was created in 2014 and few months later I stopped playing EVE due to other commitments but hope you'll find it useful.
