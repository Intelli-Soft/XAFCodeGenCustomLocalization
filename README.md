# XAFCodeGenCustomLocalization

This tool should help with creating type safe localization for XAF
In XAF (DevExpress) you have to work with "CaptionHelper.GetLocalizedText" method, if you want to receive localized strings
The DevExpress documentation for this: https://docs.devexpress.com/eXpressAppFramework/112655/localization/how-to-localize-custom-string-constants


I have a lot of custom localized text and I don't want to write the method every time.
This is the reason of this tool.

It generates a complete useable class with all the localization text you entered.

Based on the Breaking Change T1121273 by DevExpress
https://supportcenter.devexpress.com/ticket/details/t1121273/core-valuemanager-api-availability-and-deprecated-static-helpers-in-xaf-net-6-apps

A new selection on the UI is added:
.Net 5- and .Net 6+

When you coose the .Net 6+ option, the new ICaptionHelperProvider (from Namespace DevExpress.ExpressApp.Services.Localization) method is used.
This is needed, when you work with Blazor for example. After talking to the support team, this option is yet not needed with WinForms projects
Even, they are .Net 6 compatible.

Since I started the project, I found stumbling blocks, which let me update this project quite often.
The actual version has a lot of bug fixes and changes (VB.Net code generator works now as well!).

Now placeholder get recognized by the tool and wraps them into functions.
The amount of placeholder must be in the ID's description.

For example: When the ID of a localization item is: 'Test Only {0} {1}'

Then the following code is generated:

            #region Function TestOnly{0}{1}
		  public static string TestOnly(string item1, string item2){return CaptionHelper.GetLocalizedText(@"\WhereEverStored", "TestOnly {0} {1}", new object () { item1, item2 }); }
		#endregion

You never miss a placeholder anymore.
Now, with the new update, you can use command line arguments to automatic create files on every build.
You can use the following arguments:

 /n:namespace     - Namespace of the generated code.
 
 /d:destination   - Filename of the generated code.
 
 /x:xafml file    - Filename of the xafml file.
  
 /l:language      - Language of the generated code.     Possible values: 'C', 'VB' 
 
 /t:textoptions   - Text options of the generated code. Possible values: 'None', 'FirstToUpper', 'ToLower', 'ToUpper'
 
 /f:framework     - Framework of the generated code.    Possible values: 'DotNetFive', 'DotNetSixPlus'

All of the above arguments are needed to execute the application correctly.

Optional arguments:

 /pre:prefix      - Prefix of the generated code.
 
 /post:suffix     - Suffix of the generated code.

 This means, you can use the prebuild task of your Module project
 
 At "Before build" you can use the following:
 
 C:[Path to the downloaded project]\net7.0-windows\xafcodegenCustomLocalization.exe 
 
 /n:OStudio.Module.Localization 
 
 /d:[Path to your XAF Module project (where the file get's generated)]\Module\Localization.cs 
 
 /x:[Path to your XAF Module project]\Model.DesignedDiffs.xafml 
 
 /l:C 
 
 /t:None 
 
 /f:DotNetSixPlus
 
      

Everybody is welcome this tool for free (MIT License)

I would be happy to get a pizza.... https://www.buymeacoffee.com/IntelliSoft



https://user-images.githubusercontent.com/14095003/197823305-18c80869-231f-4e67-aee3-99cde296f4d5.mp4

