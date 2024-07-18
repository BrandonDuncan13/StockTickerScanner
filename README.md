# Stock Ticker Scanner C# WinForms .NET App
## Overview
This was a final project assigned to students in the operating systems course at NNU taught by Dr.McCarty. The goal of the project was to use WinForms .NET to create an 
application that could read JSON files containing a snapshot of the stock market, scan through all of the stock tickers in that snapshot, and then display the key 
information (no penny stocks or low volume stocks were used) from a snapshot onto the user interface (UI). Some other notable goals were to display the time of the market snapshot that's being processed and to add a 
UI thread to get the form to be responsive while it's running. The file system was also necessary for this project to retrieve files from the directory in which
the user put the JSON market snapshot data. This repository includes two minutes of sample market snapshot data for those interested in running the application. Overall, 
I learned a lot about OOP, the filesystem, UI threads, aggregating data, deserialization, WinForms .NET, C#, and the stock market from completing the stock ticker scanner.

## Program Screenshots
Application before selecting any stock market snapshot files. Three data-grid-view components exist to display the top 10 stocks by percent, bottom 10 stocks by percent, and top 10 stocks by highest relative value.

![empty](https://github.com/user-attachments/assets/3604fa18-da1c-473d-908d-fea44cb5e446)

Example file path of the directory containing stock market snapshot JSON files:

![fileselect](https://github.com/user-attachments/assets/464a94b7-c612-402d-b8b1-94821777e7e4)

Application during the processing of market snapshot data. All of the data-grid-view components are filled in with useful data to inform the user of the state of the stock market at that market snapshot's time:

![scannedstocks](https://github.com/user-attachments/assets/1ec1648e-071c-4b4a-84e6-5ba33b743fb5)
