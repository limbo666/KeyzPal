# **KeyzPal**
![alt text](https://github.com/limbo666/KeyzPal/blob/master/additional_files/KeyzPal_Key_Logo_1.png)

KeyzPal is a Windows tray utility to indicate the **CAPS**, **NUM** and **SCROLL** key status. 



The program currently offers:

- *Lightweight interface - Runs on system tray.*

- *Selectable Lock keys to indicate.*

- *Option to auto start on windows start.*

- *Easy to use interface.*

- *Selectable icon sets.*  

- *Keys normalization function.*

- *Selectable keys normal state for normalization.*   

- *Selectable sounds! On normalization and/or on lock key press. *

- *On screen notifications.*

- *Conditional CAPS LOCK function * 

  

###### Normalization function: 

This function can set the lock keys state to "normal" after a selectable period of time. From version 1.0.3.8 the program can detect key presses on the keyboard and reset the remaining time each time a key is pressed. This way the program will normalize the keys only if the system is inactive for the predefined time. 

From version 1.0.4.11 the keys normal state can be selected by the user under settings.


###### Conditional CAPS LOCK function (beta): 

This function can be used to auto switch on (or off) CAPS LOCK dependind on the current active window. Up to 10 program titles per fucntion can be predifined on file lists.ini.
lists.ini file should be located and the same folder with keyzpal.exe and its contents will be readed upon program launch. A part of thetitle on target window should be enough to auto switch to predifined CAPS lock. 
Examples how to use: 
If is needed to have CAPS LOCK switched on each time NOTEPAD++ is selected, the keyword "Notepad++" should be added to one of the "UpperCase" lines on lists.ini file.
If is needed to have CAPS LOCK switched on each time a specific textfile (let's say mydailynotes.txt) is edited on NOTEPAD++ (or any other editor), the keyword "mydailynotes.txt" or the keyword "mydailynotes" should be added to one of the "UpperCase" lines on lists.ini file.

The keywords should be as much unique as possible to distinguish each window and avoid unnecessary CAPS LOCK forcing.
An example lists.ini file can be downloaded from [properties folder](https://github.com/limbo666/KeyzPal/blob/master/Properties/)


## GUI

![](https://github.com/limbo666/KeyzPal/blob/master/additional_files/gui_1.png?raw=true)

The GUI is simple and self explained. Once you are execute and configure it, the program will run silently on you system tray indicating the status of lock keys.

## Download 

You can get the latest executable from releases page: https://github.com/limbo666/KeyzPal/releases
