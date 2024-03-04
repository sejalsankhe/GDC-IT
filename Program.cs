using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using System.ComponentModel.DataAnnotations;

Console.WriteLine("Enter your file name (add .csv )");
var filename = Console.ReadLine();

// checks if the file doesnt exists displays a error message
if(!File.Exists(filename))
{
    Console.WriteLine("ERROR: File does not exist. Enter a valid filename");
    return;
}

//creating variables that can store the valid and invalid emails so that its easier to print them later.
//so i have used constructor call to store the email from csv file as a string in a list format 

var validemails = new List<string>();
var invalidemails = new List<string>();
var emailregex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

foreach(var line in File.ReadLines(filename)){

    var field = line.Split(',');
var email = field[2];

if(emailregex.IsMatch(email)){
    validemails.Add(email);
}
else {

    invalidemails.Add(email);
}
};

Console.WriteLine("The Valid Emails are: ");
Console.WriteLine(); 
foreach (var vemail in validemails)
{
    Console.WriteLine(vemail);
}

Console.WriteLine(); 

Console.WriteLine("The Invalid Emails are: ");

Console.WriteLine(); 
foreach (var invemail in invalidemails)
{
    Console.WriteLine(invemail);
}
    
