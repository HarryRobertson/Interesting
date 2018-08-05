# Interesting

Welcome. 
I imagine that you get lots of games submitted for this challenge, and possibly cryptocurrency apps too as 
you are a financial company, and blockchain is in vogue at the moment (though I would like to experiment with
this too at some point).
In my quest to do something different I have decided to make a plugin framework with an assortment of simple 
plugins that can be loaded by the console host. This is something I have wanted to explore for some time, so 
I can say with absolute certainty that it is very interesting to me.
The framework is based off of an MSDN tutorial (https://msdn.microsoft.com/en-us/library/ms972962.aspx) but as
I have heavily modified it to suit my needs I believe it still qualifies as my own work. (In fact, the code
as written in the tutorial did not appear to work, so I had to make some changes just to get it to run.)
For full disclosure, the Animation plugin is also heavily modified from a code snippet that I found online 
(https://www.arungudelli.com/tutorial/c-sharp/3-funny-things-you-can-do-with-csharp-console/).
The project is not as well tested as I would like, as much of it was experimental and TDD is difficult where 
the shape of the application is not already known, but I have tried to include a few tests where appropriate.
I hope you find this app as interesting as I have found developing it.

How to run:
	All the projects (except the Test project) should build to the same output location. Launch the Console 
	app with a xml Config document from the Config folder passed as the first argument.
	e.g. Interesting.Console.exe HelloWorld[.xml]

TODO: 
	- make IPlugin.Name match name defined in config without having to implement it in every derived class
	  (I don't feel like the AbstractPlugin is a good solution to this)
	- wrap the XDocument handling in a custom class to make config manipulation simpler
	- more testing, especially more TDD with further plugins now that the interfaces are well established
	- mock the TextReader/Writer on the Console to allow testing the plugins that just do IO
	- allow loading of nested plugin classes

Third party references:
	- xUnit.net for testing (I didn't have time to implement my own testing framework too)