using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace SMA.CS
{
    public static class GlobalVariables
    {
        public static Hashtable variableTable=new Hashtable();
        public static Hashtable languageTable=new Hashtable();
        public static string currentLanguage;

        public static void initVariables()
        {
            //_________________Gets_Language_List_From_DataBase___________________________________
            //Comunication.getLanguages(languageTable);
            currentLanguage = "ქართული";

            //________________Sets_Languages_Manually__________________________________________________

            languageTable.Add("ქართული", "11");
            languageTable.Add("English", "12");
            languageTable.Add("Russian", "13");


            //_________________Adds_Variables_Manually__________________________________________________
            variableTable.Add("@home", "სახლი");
            variableTable.Add("@about", "ჩვენს შესახებ");
            variableTable.Add("@contact", "კონტაქტი");
            variableTable.Add("@login", "სისტემაში შესვლა");
            variableTable.Add("@register", "რეგისტრაციის გავლა");


           


            //___________________Gets_Translated_Variable_Values_From_DataBase___________________________
            //Comunication.setVariables(languageTable[currentLanguage].ToString(),variableTable);
        }

        static GlobalVariables()
        {
            initVariables();
        }

        public static string getVariableValue(string key)
        {
            string toReturn = variableTable[key].ToString();


            return toReturn;
        }
    }
}