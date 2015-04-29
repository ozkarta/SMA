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
        private static string currentLanguage;

        public static void initVariables()
        {
            //_________________Gets_Language_List_From_DataBase___________________________________
            Comunication.getLanguages(languageTable);
            currentLanguage = "ქართული";

            //_________________Adds_Variables_Manually__________________________________________________
            variableTable.Add("@home", "");
            variableTable.Add("@about", "");
            variableTable.Add("@contact", "");
            variableTable.Add("@login", "");
            variableTable.Add("@register", "");



            //___________________Gets_Translated_Variable_Values_From_DataBase___________________________
            Comunication.setVariables(languageTable[currentLanguage].ToString(),variableTable);
        }

        static GlobalVariables()
        {
            initVariables();
        }
    }
}