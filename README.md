# Capgemini ADCenter Network Code Challenge
## Gene Code Processing

### Introduction
This is a possible solution for the first Code Challenge by the ADCenter Network from Capgemini. This one is written in C# and is using the service/controller architecture.

### Installation .NET
This projects needs .NET 5.0 in order to be compiled and run successfully. NET 5.0 is a free and open-source, managed computer software framework for Windows, Linux, and macOS operating systems. It is a cross-platform successor to the .NET Framework on Windows and the previous .NET Core. The project is developed by the .NET Foundation (primary with Microsoft support), and released under the MIT License. You can find instructions on how to install for you platform on the Microsoft site.

### Compile and run 
Opening with Visual Studio de solution by clicking in the file ADCenterNetworkCodeChallenge.sln located in the root directory and clicking in the menu build/build solution:

![alt text](https://github.com/[username]/[reponame]/blob/[branch]/image.jpg?raw=true)

All unit-tests can be run with Visual Studio by doing right click on the Test project of the solution, opening the Tests Panel and running the tests:

![alt text](https://github.com/[username]/[reponame]/blob/[branch]/image.jpg?raw=true)

The executable can be run with Visual Studio opening the solution and clicking in the green arrow to execute IIS Express.

![alt text](https://github.com/[username]/[reponame]/blob/[branch]/image.jpg?raw=true)

Once the swagger opens in your favourite project you will find two services to use:

#### Sequence_mRNA

With this service you will be able to copy paste a string with the mRNA sequence and it will return when you push in the execute button all the DNA strings that are there or an error.

![alt text](https://github.com/[username]/[reponame]/blob/[branch]/image.jpg?raw=true)

It will show the results as follows:

![alt text](https://github.com/[username]/[reponame]/blob/[branch]/image.jpg?raw=true)

#### Sequence_mRNAStream

With this service you will be able to insert a path to a txt file where a mRNA sequence is located and to introduce as well the position of the DNA string you want to recover and it will return when you push in the execute button the DNA string in the position you introduced that is there or an error.

![alt text](https://github.com/[username]/[reponame]/blob/[branch]/image.jpg?raw=true)

It will show the results as follows:

![alt text](https://github.com/[username]/[reponame]/blob/[branch]/image.jpg?raw=true)

Note that the sample file is refMrna.fa.corrected.txt which is valid. The original file refMrna.fa.txt can be used but contains (intentionally) coding errors.
I also have other txt files with test information for the different tests I have, the titles of them are quite meaningful.

### Why C# and service/controller architecture
I chose to do this in C# because it is my favourite programming language and I think it is quite robust and is quite world wide used nowadays.

![](https://github.com/jbasmut/ADCenterNetworkCodeChallenge/blob/master/C_Sharp_wordmark.svg)

I chose service/controller architecture due to I think with it we could use these services with any frontend we would like if we would decide to provide one, for example you could program the frontend in ASP.NET, in Angular, in Blazor... and with any of those or most of others you could call the services I programmed and your application would work.
I chose .NET 5.0 because is the latest and so this solution would have the latest updates from Microsoft.

C# is a general-purpose, multi-paradigm programming language encompassing static typing, strong typing, lexically scoped, imperative, declarative, functional, generic, object-oriented (class-based), and component-oriented programming disciplines.

C# was developed around 2000 by Microsoft as part of its .NET initiative and later approved as an international standard by Ecma (ECMA-334) in 2002 and ISO (ISO/IEC 23270) in 2003.

### Build & Test status
![Main build and test](https://github.com/jbasmut/ADCenterNetworkCodeChallenge/blob/master/badge.svg)

### License
[https://img.shields.io/badge/License-Apache%202.0-blue.svg](https://opensource.org/licenses/Apache-2.0)
<p><a href="https://opensource.org/licenses/Apache-2.0" rel="nofollow"><img src="https://camo.githubusercontent.com/2a2157c971b7ae1deb8eb095799440551c33dcf61ea3d965d86b496a5a65df55/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f4c6963656e73652d417061636865253230322e302d626c75652e737667" alt="License" data-canonical-src="https://img.shields.io/badge/License-Apache%202.0-blue.svg" style="max-width:100%;"></a></p>

Copyright © 2021 Iwan van der Kleijn

Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
