using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Web.Mvc;

namespace SMA.CS
{
    public static class GlobalVariables
    {
        public static Hashtable variableTable;
        public static Hashtable languageTable;
        public static string currentLanguageTrial;
        public static string currentLanguage;
        public static List<SelectListItem> languageListItems = new List<SelectListItem>();


        public static void initVariables()
        {
            //_________________Gets_Language_List_From_DataBase___________________________________
            

            //________________Sets_Languages_Manually__________________________________________________

            

            //_________________Adds_Variables_Manually__________________________________________________
           

           


            //___________________Gets_Translated_Variable_Values_From_DataBase___________________________
            Comunication.setVariables(languageTable[currentLanguageTrial].ToString(),variableTable);
            initDropDownList();
        }
        public static void initDropDownList()
        {
            languageListItems.Clear();

            foreach (DictionaryEntry lang in GlobalVariables.languageTable)
            {
                
                SelectListItem i = new SelectListItem() { Text = lang.Key.ToString(), Value = lang.Value.ToString() };
                if (i.Text == GlobalVariables.currentLanguage)
                {
                    i.Selected = true;
                }
                languageListItems.Add(i);

            }

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