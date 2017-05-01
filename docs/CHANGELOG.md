# [Changelog](https://github.com/LateStartStudio/Hero6/blob/master/docs/CHANGELOG.md)

## v0.1.0 First Pre Alpha Release

### General

* Made A* pathfinder to make characters move from one location to another.
* Logging utility will write a log file to disk if Hero6 were to crash.

### Campaign

* Made a basic engine for running Adventure Game Point N' Click games, in form of a "Campaign".

#### Rites Of Passage

* Added room "Albion - Hill Over Albion".
  * Player can interact with the sign.
  * Player can interact with a sword on the ground.
  * Player can exit north.
* Added room "Albion - Fountain".
  * Player can interact with the fountain.
  * Player can interact with NPC "Llewella".
  * Player can exit south.
* Added walking animation to player character Hero.
* Added default language "English" translation file.

### User Interface

* Made a small basic UI framework.

#### Sierra VGA Verb Bar

* Added mouse support.
  * Mouse cursors, walk, look, grab, talk, idle, and arrow.
  * Left click will interact with what the mouse is hovering over.
  * Scroll wheel click will reset the cursor back to the walk cursor.
  * Right click will cycle through the cursors, walk, look, grab, and talk.
* Added a basic text box.
* Added the status bar.
  * Currently the status bar is empty except for a wood background.
  * On mouse over this will hide the status bar and show the verb bar.
* Added the verb bar.
  * On mouse leave this hide the verb bar and show the status bar.
  * Added button for walk, look, grab, talk, sub menu, magic, current item, inventory and options.
    * On mouse over the buttons will light up.
    * On mouse leave the buttons will go dark.
    * Pressing walk, look, grab or talk button will change cursor.
    * Pressing sub menu, magic, current item, inventory and options will show a "Work in process" text box".

### Platform

#### Windows

* Added a basic Windows Installer made with [Advanced Installer](http://www.advancedinstaller.com/).

#### Linux

* Introduced experimental support, so anyone should be able to build the Hero6 source code on Linux in a C# compatible IDE or by using the shell script "src/build.sh".

#### OS X

* Introduced experimental support, so anyone should be able to build the Hero6 source code on OS X in a C# compatible IDE or by using the shell script "src/build.sh".

#### Android

* Introduced experimental support, so anyone should be able to build the Hero6 source code on Android in a C# compatible IDE with Xamarin support.
