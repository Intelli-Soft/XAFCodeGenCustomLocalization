using System;
using System.Collections.Generic;
using System.Linq;

namespace XAFCodeGenCustomLocalization.CodeGenerator
{
    internal class PlaceholderRemover
    {
        int myCountOfPlaceHolder = 0;

        //bool myHasPlaceholder = false;
        System.Text.RegularExpressions.Regex myIrregularStrings = new(@"[<>'""/;`%@]");

        List<string> myListOfPlaceHolders = new();
        string myName;
        System.Text.RegularExpressions.Regex myRegularExpressionToFindPlaceholder = new(@"{\d+}");
        string myReturnNameWithoutPlaceHolder = string.Empty;


        public PlaceholderRemover(string name)
        {
            myName = name;
            myReturnNameWithoutPlaceHolder = name;
            CheckForPlaceHolder();
        }

        internal void CheckForPlaceHolder()
        {
            myCountOfPlaceHolder = myRegularExpressionToFindPlaceholder.Matches(myName).Count();
            if(myCountOfPlaceHolder > 0)
            {
                PartGivenString();
            }
        }

        internal void PartGivenString()
        {
            var locMatch = myRegularExpressionToFindPlaceholder.Match(myName);
            myReturnNameWithoutPlaceHolder = myName;
            while(locMatch.Success)
            {
                if(myListOfPlaceHolders.Contains(locMatch.Value) == false)
                    myListOfPlaceHolders.Add(locMatch.Value);
                myReturnNameWithoutPlaceHolder = myReturnNameWithoutPlaceHolder.Replace(locMatch.Value.ToString(), "_");
                locMatch = locMatch.NextMatch();
            }
            if(myReturnNameWithoutPlaceHolder.EndsWith("_"))
                myReturnNameWithoutPlaceHolder = myReturnNameWithoutPlaceHolder.TrimEnd('_');

            myReturnNameWithoutPlaceHolder = RemoveIrregularCharacters(myReturnNameWithoutPlaceHolder);
        }

        internal string RemoveIrregularCharacters(string stringToCheck)
        {
            var locReturnString = stringToCheck;
            var locIrregularMatch = myIrregularStrings.Match(stringToCheck);
            while(locIrregularMatch.Success)
            {
                locReturnString = locReturnString.Replace(locIrregularMatch.Value.ToString(), string.Empty);
            }
            return locReturnString;
        }

        public int Count() { return myCountOfPlaceHolder; }
        public List<string> GetListOfPlaceHolders() { return myListOfPlaceHolders; }

        public bool HasPlaceholder() { return myListOfPlaceHolders.Count > 0; }

        public string NameWithoutPlaceHolder() { return myReturnNameWithoutPlaceHolder; }

        public override string ToString() { return myReturnNameWithoutPlaceHolder; }
    }
}
