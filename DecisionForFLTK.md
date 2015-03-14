# Our Decision #

The toolkit recommended for use in creating the GUI was the Fast Light Toolkit (FLTK). That toolkit is C++ based and uses OpenGL and Fluid to the developer in order to create a GUI. We decided to not use FLTK, opting instead for Microsoft Visual Studio's built-in C# Windows Form Application.


# Reasons For Our Decision #

The main reason for not using FLTK was our choice of programming language. Since we want to do this project in C#, it would be difficult to weave FLTK and the C# code-behind together.

Another reason for not using FLTK is our emphasis and priority of concerns in this project. As stated, the goal of this project is to create a basic image manipulation software. As such, our team decided that the creation of the GUI should not be biggest priority. Rather, we place the highest priority in the creation of methods to perform the image manipulation. FLTK has a much steeper learning curve than Windows Form, which does not coincide with our focus on this project. We want to spend the bulk of our time learning the algorithms for manipulating pixelmaps, not learning how to create a GUI.

Lastly, another reason is our team's familiarity with Visual Studio's offerings. This allows us to optimize our time spent together in lab, working on the image manipulation algorithms instead of figuring out another IDE such as Fluid.