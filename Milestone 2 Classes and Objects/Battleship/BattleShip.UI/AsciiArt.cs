using System;

namespace BattleShip.UI
{
    class AsciiArt
    {
        public void Welcome()
        {


            Console.Write(@"                                                 # #  ( )
                                              ___#_#___|__
                                          _  |____________|  _
                                   _=====| | |            | | |==== _
                             =====| |.---------------------------. | |====
               <--------------------'   .  .  .  .  .  .  .  .   '--------------/
                 \                                                             /
                  \_______________________________________________WWS_________/
              wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww
            wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww
               wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww 

                         _           _   _   _           _     _       
                        | |         | | | | | |         | |   (_)      
                        | |__   __ _| |_| |_| | ___  ___| |__  _ _ __  
                        | '_ \ / _` | __| __| |/ _ \/ __| '_ \| | '_ \ 
                        | |_) | (_| | |_| |_| |  __/\__ \ | | | | |_) |
                        |_.__/ \__,_|\__|\__|_|\___||___/_| |_|_| .__/ 
                                                                | |    
                                                                |_|   
");


        }

        public void EndGameMessage()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(@"  _______ _                 _           __                   _             _             
 |__   __| |               | |         / _|                 | |           (_)            
    | |  | |__   __ _ _ __ | | _____  | |_ ___  _ __   _ __ | | __ _ _   _ _ _ __   __ _ 
    | |  | '_ \ / _` | '_ \| |/ / __| |  _/ _ \| '__| | '_ \| |/ _` | | | | | '_ \ / _` |
    | |  | | | | (_| | | | |   <\__ \ | || (_) | |    | |_) | | (_| | |_| | | | | | (_| |
    |_|  |_| |_|\__,_|_| |_|_|\_\___/ |_| \___/|_|    | .__/|_|\__,_|\__, |_|_| |_|\__, |
                                                      | |             __/ |         __/ |
                                                      |_|            |___/         |___/ 

");
            Console.ResetColor();
        }

        public void WinMessage(string name)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($@" __       __  ______  __    __  __    __  ________  _______   __ 
/  |  _  /  |/      |/  \  /  |/  \  /  |/        |/       \ /  | 
$$ | / \ $$ |$$$$$$/ $$  \ $$ |$$  \ $$ |$$$$$$$$/ $$$$$$$  |$$ |
$$ |/$  \$$ |  $$ |  $$$  \$$ |$$$  \$$ |$$ |__    $$ |__$$ |$$ |
$$ /$$$  $$ |  $$ |  $$$$  $$ |$$$$  $$ |$$    |   $$    $$< $$ | 
$$ $$/$$ $$ |  $$ |  $$ $$ $$ |$$ $$ $$ |$$$$$/    $$$$$$$  |$$/ 
$$$$/  $$$$ | _$$ |_ $$ |$$$$ |$$ |$$$$ |$$ |_____ $$ |  $$ | __ 
$$$/    $$$ |/ $$   |$$ | $$$ |$$ | $$$ |$$       |$$ |  $$ |/  |
$$/      $$/ $$$$$$/ $$/   $$/ $$/   $$/ $$$$$$$$/ $$/   $$/ $$/ 
                                                                 
        Congratuations on your Victory, {name.ToUpper()}                                                         
                                                                 ");
            Console.WriteLine();  
            Console.ResetColor();
        }

        public void LoseMessage(string name)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($@" __         ______    ______   ________  _______   __ 
/  |       /      \  /      \ /        |/       \ /  | 
$$ |      /$$$$$$  |/$$$$$$  |$$$$$$$$/ $$$$$$$  |$$ |
$$ |      $$ |  $$ |$$ \__$$/ $$ |__    $$ |__$$ |$$ |                  
$$ |      $$ |  $$ |$$      \ $$    |   $$    $$< $$ |
$$ |      $$ |  $$ | $$$$$$  |$$$$$/    $$$$$$$  |$$/ 
$$ |_____ $$ \__$$ |/  \__$$ |$$ |_____ $$ |  $$ | __ 
$$       |$$    $$/ $$    $$/ $$       |$$ |  $$ |/  |
$$$$$$$$/  $$$$$$/   $$$$$$/  $$$$$$$$/ $$/   $$/ $$/ 
                                                      
        Better luck next time, {name.ToUpper()}                                             
                                                      ");
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
