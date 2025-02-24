# Security Operator Screen App
## Features
- GUI with buttons to simulate an entry event & display entries on screen.
- Grid view to display each entry.
- Invalid entry detection. A pop up form will appear to alert the operator that the entry had invalid status code. The operator is given an option to manually confirm the entry.
- Automated Mailing. In case of operator not confirming within 30 seconds, an email will be sent to the pre-set email address.
- Timed auto closing alerts.
## Build Requirements
- .NET 8.0 Framework
- NLog
- Build the source with Visual Studio 2022.
## Setup
- Clone the repo https://github.com/Tsptds/Operator-Screen-App.git
- Setup an email that will send the invalid entries. Recommended way is described below:
- Setup the account (Gmail, outlook etc.) with 2 factor authentication and obtain an application password. Then note it down.
- Navigate to root folder (cd Operator-Screen-App).
- Find Settings.ini file.
- Inside the ini, there are API, SMTP and MAIL headers.
### API
- The app is designed to be used on the following API: "interview.ones.com.tr" on the endpoint "/API/AccessLog". Fill the API settings accordingly.
### SMTP Server
- SMTP server is pre-set with gmail's smtp server. Use your newly created (or existing) email account and enter the credentials to username & password fields. Recommended to use the application password obtained above instead of the account password.
- Port is defaulted to one of gmail options (587). Check your email service provider's instructions on setting up an smtp email server for other email providers.
- Recommended to keep ssl on true, as many SMTP servers require it.
- Google's guide on setting an SMTP email sender https://support.google.com/a/answer/176600?hl=en
### MAIL
- MailTarget is the email address to receive the invalid entries.
### Side Notes
- Make sure all the fields are filled in every category. Ports have to be numeric, SSL is true/false.
## Usage
- Download .NET 8.0 Runtime x64 for windows.
- Launch the exe file. To simulate an entry, click on the "Simulate Operation" button. This will retrieve a JSON object from the API, deserialize it and add it to the grid view.
- If the entry has an invalid status code, the security operator will be alerted by a pop-up with 30 seconds of countdown.
- Security operator has the option to manually confirm the entry, or deny it.
- If the entry was denied or had not been confirmed within 30 seconds, app will send an email to the given email address with the information of the entry.
- The mail content includes the entry information formatted in an HTML table.
## Logs
- All actions are logged using NLog within "Logs" folder under the root directory of the program, with the following file name convention:
"ApplicationLog_{shortdate}.txt" where short day represents year-month-day.
- Log files are not reset on launch. New logs are appended by default for the same day.
- Logs use default format:
"year-month-day" "hour-minute-second-millisecond" |"Log Level"| "Message"