using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace SMA.CS
{
    public static class GlobalVariables
    {
        public static Hashtable variableTable;
        public static Hashtable languageTable;
        public static string currentLanguageTrial;
        public static string currentLanguage;

        public static void initVariables()
        {
            //_________________Gets_Language_List_From_DataBase___________________________________
            

            //________________Sets_Languages_Manually__________________________________________________

            

            //_________________Adds_Variables_Manually__________________________________________________
           

           


            //___________________Gets_Translated_Variable_Values_From_DataBase___________________________
            Comunication.setVariables(languageTable[currentLanguageTrial].ToString(),variableTable);
        }

        static GlobalVariables()
        {
            variableTable = new Hashtable();
            languageTable = new Hashtable();

            manualInit();
            initVariables();
        }

        public static string getVariableValue(string key)
        {
            string toReturn="NULL";
            if (variableTable[key] != null)
            {
                toReturn=variableTable[key].ToString();
            }


            return toReturn;
        }

        public static  void manualInit()
        {
            Comunication.getLanguages(languageTable);
            currentLanguageTrial = "ქართული";
            currentLanguage = "ქართული";

            variableTable.Add("home", "");
            variableTable.Add("about", "");
            variableTable.Add("contact", "");
            variableTable.Add("login", "");
            variableTable.Add("register", "");

        }
         public static void rollBackLanguage()
         {
             currentLanguageTrial=currentLanguage.ToString();
         }
         public static void updateLanguage()
         {
             currentLanguage = currentLanguageTrial.ToString();
         }
    }
}