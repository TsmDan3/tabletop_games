using System;
using System.IO;
using System.Text;

class reader {

  public static void Main (string[] args) {
    String filename = "savefile.dan";
    int ExpectedFileSizeDueToUpdate = 1024;
    byte[] file = new byte [ExpectedFileSizeDueToUpdate];

    byte updateType;
    byte updateLocation;
    byte timesWritten;
    byte nameLength;
    byte[] name;
    byte currentHealth;
    byte maxHealth;
    byte currentHunger;
    byte maxHunger;
    byte currentThirst;
    byte maxThirst;
    byte suffocating;
    byte currentOxygen;
    byte maxOxygen;
    byte currentStamina;
    byte maxStamina;
    byte[] hahaFunnyNumber = new byte[4];
    byte updateMajor;
    byte updateMinor;
    byte updateSecurity;
    byte updateBugFix;
    //byte fileSize;

    //int b;

    using (FileStream fs = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
    {
      while (fs.Read(file,0,file.Length) > 0)
      {
        updateType = file[0];
        updateLocation = file[1];
        timesWritten = file[2];
        nameLength = file[3];
        name = new byte[Convert.ToInt32(nameLength)];
        Array.Copy(file, 4, name, 0, Convert.ToInt32(nameLength));
        currentHealth = file[Convert.ToInt32(nameLength) + 5];
        maxHealth = file[Convert.ToInt32(nameLength) + 6];
        currentHunger = file[Convert.ToInt32(nameLength) + 7];
        maxHunger = file[Convert.ToInt32(nameLength) + 8];
        currentThirst = file[Convert.ToInt32(nameLength) + 9];
        maxThirst = file[Convert.ToInt32(nameLength) + 10];
        suffocating = file[Convert.ToInt32(nameLength) + 11];
        currentOxygen = file[Convert.ToInt32(nameLength) + 12];
        maxOxygen = file[Convert.ToInt32(nameLength) + 13];
        currentStamina = file[Convert.ToInt32(nameLength) + 14];
        maxStamina = file[Convert.ToInt32(nameLength) + 15];
        Array.Copy(file, Convert.ToInt32(nameLength) + 16, hahaFunnyNumber, 0, 4);
        updateMajor = file[Convert.ToInt32(updateLocation)];
        updateMinor = file[Convert.ToInt32(updateLocation) + 1];
        updateSecurity = file[Convert.ToInt32(updateLocation) + 2];
        updateBugFix = file[Convert.ToInt32(updateLocation) + 3];
        //fileSize = file[1023];

        /*
        Update Types:
        0: Prototype
        1: Alpha
        2: Beta
        3: Pre-Release
        4: Initial Release
        5: Update Prototype
        6: Update Alpha
        7: Update Beta
        8: Update Pre-Release
        9: Updated Release
        */
        Console.Write(updateMajor + "." + updateMinor + "." + updateSecurity + "." + updateBugFix + " ");
        switch(updateType){
          case 1:
            Console.WriteLine("Initial Prototype");
            break;
          case 2:
            Console.WriteLine("Initial Alpha");
            break;
          case 3:
            Console.WriteLine("Initial Beta");
            break;
          case 4:
            Console.WriteLine("Initial Pre-Release");
            break;
          case 5:
            Console.WriteLine("Initial Release");
            break;
          case 6:
            Console.WriteLine("Prototype");
            break;
          case 7:
            Console.WriteLine("Alpha");
            break;
          case 8:
            Console.WriteLine("Beta");
            break;
          case 9:
            Console.WriteLine("Release");
            break;
          default:
            Console.WriteLine("- Update Type unknown");
            break;
          }
          Console.WriteLine("This save has been written to " + timesWritten + " times.");
          Console.WriteLine("This file belong to " + System.Text.Encoding.Default.GetString(name) + ". Hello :).");
          if (Convert.ToInt32(currentHealth) == 0) {
            Console.WriteLine(System.Text.Encoding.Default.GetString(name) + " is currently dead. :(");
          }else if (Convert.ToInt32(currentHealth) < 0) {
            Console.WriteLine("Have you been fucking with the save file? Because there's no fucking way that" + System.Text.Encoding.Default.GetString(name) + " is more dead than dead");
          }else if (Convert.ToInt32(currentHealth) > Convert.ToInt32(maxHealth)){
            Console.WriteLine("Have you been fucking with the save file? Because there's no fucking way that" + System.Text.Encoding.Default.GetString(name) + " has more health than max health");
          }else if (Convert.ToInt32(maxHealth) < 100){
            Console.WriteLine("You fucked with the maximum health. It's less than usual. I assume you're trying to make your life harder. Please don't do that.");
          }else if (Convert.ToInt32(maxHealth) > 100){
            Console.WriteLine("You fucked with the maximum health. It's greater than usual. Cheater.");
          }else {
            Console.WriteLine(System.Text.Encoding.Default.GetString(name) + " is at " + currentHealth + " health out of a maximum of " + maxHealth);
          }

          if (Convert.ToInt32(currentHunger) == 0) {
            Console.WriteLine("Aaaaaaaaaaaaaaaaannnnnnnnnnnnnnnnd " + System.Text.Encoding.Default.GetString(name) + " is currently starving. :(");
          }else if (Convert.ToInt32(currentHunger) < 0) {
            Console.WriteLine("Have you been fucking with the save file? Because there's no fucking way that" + System.Text.Encoding.Default.GetString(name) + " is more hungry than hungry");
          }else if (Convert.ToInt32(currentHunger) > Convert.ToInt32(maxHunger)){
            Console.WriteLine("Have you been fucking with the save file? Because there's no fucking way that" + System.Text.Encoding.Default.GetString(name) + " has more hunger than max hunger");
          }else if (Convert.ToInt32(maxHunger) < 100){
            Console.WriteLine("You fucked with the maximum hunger. It's less than usual. I assume you're trying to make your life harder. Please, if you want harder, change maximum health.");
          }else if (Convert.ToInt32(maxHunger) > 100){
            Console.WriteLine("You fucked with the maximum hunger. It's greater than usual. Cheater.");
          }else {
            Console.WriteLine(System.Text.Encoding.Default.GetString(name) + " is at " + currentHunger + " hunger out of a maximum of " + maxHunger);
          }

          if (Convert.ToInt32(currentThirst) == 0) {
            Console.WriteLine("Aaaaaaaaaaaaaaaaannnnnnnnnnnnnnnnd " + System.Text.Encoding.Default.GetString(name) + " is currently dying of thirst. :(");
          }else if (Convert.ToInt32(currentThirst) < 0) {
            Console.WriteLine("Have you been fucking with the save file? Because there's no fucking way that" + System.Text.Encoding.Default.GetString(name) + " is more thirsty than thirsty");
          }else if (Convert.ToInt32(currentThirst) > Convert.ToInt32(maxThirst)){
            Console.WriteLine("Have you been fucking with the save file? Because there's no fucking way that" + System.Text.Encoding.Default.GetString(name) + " has more thirst than max thirst");
          }else if (Convert.ToInt32(maxThirst) < 100){
            Console.WriteLine("You fucked with the maximum thirst. It's less than usual. I assume you're trying to make your life harder. Please, if you want harder change health.");
          }else if (Convert.ToInt32(maxThirst) > 100){
            Console.WriteLine("You fucked with the maximum thirst. It's greater than usual. Cheater.");
          }else {
            Console.WriteLine(System.Text.Encoding.Default.GetString(name) + " is at " + currentThirst + " thirst out of a maximum of " + maxThirst);
          }

          if (Convert.ToBoolean(suffocating) == true) {
            Console.WriteLine(System.Text.Encoding.Default.GetString(name) + " is currently suffocating and has " + currentOxygen + " oxygen left.");
          }
           if (Convert.ToInt32(currentOxygen) == 0) {
            Console.WriteLine("Aaaaaaaaaaaaaaaaannnnnnnnnnnnnnnnd " + System.Text.Encoding.Default.GetString(name) + " is currently suffocating.");
          }else if (Convert.ToInt32(currentOxygen) < 0) {
            Console.WriteLine("Have you been fucking with the save file? Because there's no fucking way that" + System.Text.Encoding.Default.GetString(name) + " is more drowning(?) than drowning");
          }else if (Convert.ToInt32(currentOxygen) > Convert.ToInt32(maxOxygen)){
            Console.WriteLine( System.Text.Encoding.Default.GetString(name) + " got those XXXL lungs i see.");
          }else if (Convert.ToInt32(maxOxygen) < 100){
            Console.WriteLine("lung too smol. get replacement.");
          }else if (Convert.ToInt32(maxOxygen) > 100){
            Console.WriteLine("You fucked with the maximum oxy. It's greater than usual. Cheater.");
          }else {
            Console.WriteLine(System.Text.Encoding.Default.GetString(name) + " is at " + currentOxygen + " Oxygen out of a maximum of " + maxOxygen);
          }
          
           if (Convert.ToInt32(currentStamina) == 0) {
            Console.WriteLine("If you go back into the game you will see that " + System.Text.Encoding.Default.GetString(name) + " can not run for his life.");
          }else if (Convert.ToInt32(currentStamina) < 0) {
            Console.WriteLine("Have you been fucking with the save file? Because there's no fucking way that" + System.Text.Encoding.Default.GetString(name) + " is more exhausted than exhausted.");
          }else if (Convert.ToInt32(currentStamina) > Convert.ToInt32(maxThirst)){
            Console.WriteLine("Have you been fucking with the save file? Because there's no fucking way that" + System.Text.Encoding.Default.GetString(name) + " has more energy than max energy");
          }else if (Convert.ToInt32(maxStamina) < 100){
            Console.WriteLine("You fucked with the maximum NRG. It's less than usual. I assume you're trying to make your life harder. Please, the game becomes almost impossible when the stamina is lower");
          }else if (Convert.ToInt32(maxStamina) > 100){
            Console.WriteLine("You fucked with the maximum NRG. It's greater than usual. Cheater.");
          }else {
            Console.WriteLine(System.Text.Encoding.Default.GetString(name) + " is at " + currentStamina + " energy out of a maximum of " + maxStamina);
          }
          switch (BitConverter.ToInt32(hahaFunnyNumber)){
            case 69:
              Console.WriteLine("I guess you find sex humorous. Whatever works, at this point. (Definitely not talking about COVID)");
              break;
            case 420:
              Console.WriteLine("Remember to tell your local lawmaker to vote \"YES\" on marijuana legalization. I copy-pased marijuana from the wiki btw.");
              break;
            case 666:
              Console.WriteLine("Ah yes, a fellow Church of Satan member. Hail Satan.");
              break;
            case 69420:
              Console.WriteLine("haha xtra funny number cus it has 420 and 69 at the same time hahahahahahahahahahahadhahahahahaahah");
              break;
            case 42069:
              Console.WriteLine("You thought you could avoid me by changing the order, did you?");
              Console.WriteLine("haha xtra funny number cus it has 420 and 69 at the same time hahahahahahahahahahahadhahahahahaahah");
              break;
            case 69666:
              Console.WriteLine("haha satan has secks");
              break;
            case 66669:
              Console.WriteLine("what the shit are u trying to say");
              break;
            case 177013:
              Console.WriteLine("no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no no");
              break;
            case 420666:
              Console.WriteLine("Satan does weed. I approve this message");
              break;
            case 666420:
              Console.WriteLine("Okay, I feel like you\'re just trying to fuck with me rn.");
              break;
            case 69420666:
              Console.WriteLine("haha");
              break;
            case 2147483647:
            Console.WriteLine("Yeah, no. You're just fucking with me.");
              break;
            default:
              Console.WriteLine("The funny number is " + BitConverter.ToInt32(hahaFunnyNumber));
              break;
          }
      }
    }
  }
}