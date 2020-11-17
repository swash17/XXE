# XXE

<img src="XXE SplashScreen.jpg"/>

## Program Description

XXE is a traffic assignment program based on the standard user equilibrium principle, which is defined as:

*"The travel time between a specified origin and destination on all used routes is the same and is less than or equal to the travel time that would be experienced by a traveler on any unused route."*

With a defined network and a given origin-destination matrix, XXE assigns traffic flows by setting up the user equilibrium problem as a mathematical program as shown in Equation 8.8 in Mannering and Washburn (2012).

## Background

The original version of the program was developed by Fred Mannering in 1984 for a research project that was to assess traffic impacts of new highway construction in Altoona, PA. The program was written in FORTRAN and was originally written for use on a main frame computer and later was used on a PC, with the Disk Operating System (DOS). The program was developed further by Mannering in subsequent research projects with the Washington State Department of Transportation. A very detailed discussion of the program is provided in Mannering et al. (1989). From 1983 to 2001, the program was used extensively as an instructional tool in classes at the Pennsylvania State University (1983-1986) and the University of Washington (1986-2001).

In 2007, Scott Washburn adapted the DOS version of XXE (Ver. 1.0) for use in the WINDOWS operating system, of which the latest version of that particular release is Ver. 2.3. 

In 2019, updates to the program, as part of the dissertation work of Wei Sun at the University of Florida, were released. This release is Ver. 3.0. Please see the <a href="Get Started.docx">'Get Started.docx'</a> and <a href="User Guide.docx">'User Guide.docx'</a> documents to learn how to use this version.

As a final point, the name XXE has no specific meaning. The initial version of the program was simply called "X", and after the first major revision (which streamlined some of the data inputs) it was called "XX", and all subsequent revisions were called "XXE", with the "E" implying an extended version of the "XX" program.

## Program Download

See the Releases section for the installation files.

Download this file to any location on your computer's hard drive. After unzipping this file, there should be two files (setup.msi and setup.exe).

Run the setup.exe file and follow the installation instructions. Note that the .NET Framework is required for this program. If it is not already installed on your computer, the installation routine will prompt you to download the .NET Framework from Microsoft's web site. Once installation is complete, you can delete the setup files.

[//]: # (<a href="XXEinstall.zip">XXE 2.3 Installation Program</a>, updated 4/28/11)

## Program Users Guide

This <a href="XXE%20Users%20Guide.pdf">document</a> provides a basic set of instructions for program use and operation. This file is also accessible from the 'Help' menu of the program.

## Examples

Several example networks are provided with the program installation, and also are repeated here. Additional examples that were created after the program installation build are also included here. Note: To save a file directly to your hard drive, right-click on the link and then select 'Save Link As...'.

Simple Network:    <a href="Simple%20network.pdf">Network Diagram</a> : <a href="Simple%20network.xml">Input File</a></p>
Rectangle Network: <a href="Rectangle%20network.pdf">Network Diagram</a> : <a href="Rectangle%20network.xml">Input File</a></p>
Horseshoe Network: <a href="Horseshoe%20network.pdf">Network Diagram</a> : <a href="Horseshoe%20network.xml">Input File</a></p>
Example based on Figure 8.8/Table 8.2 from Principles of Highway Engineering and Traffic Analysis, 5e 
(These files will be provided to instructors by request to Dr. Washburn).

## References
Mannering, F. and Washburn, S. (2019). <a href="https://www.wiley.com/en-us/Principles+of+Highway+Engineering+and+Traffic+Analysis%2C+7th+Edition-p-9781119493969">Principles of Highway Engineering and Traffic Analysis</a>. John Wiley and Sons, 
New York, NY. Seventh edition.

Mannering, F., Garrison, D. and Sebranke. B. (1989). <a href="TNW90-11vol4.pdf">Generation and Assessment of Incident Management Strategies, Volume IV: Seattle-Area Incident Impact Analysis: Microcomputer Traffic Simulation Results</a>. WA-RD 204.4 and TNW90-11vol4.

Wei, Sun (2019). Freeway Network Travel Time Reliability Analysis Methodology and Software Tool Development. Dissertation. University of Florida.
