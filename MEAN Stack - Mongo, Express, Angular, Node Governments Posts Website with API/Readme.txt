To Run:

1. open project
2. run npm install in terminal
3. run npm run start:server in terminal
4. run ng serve --ssl true --ssl-cert "keys\certificate.pem" --ssl-key "keys\privatekey.pem" --proxy-config proxy.conf.json in new terminal

Currently using online MongoDB (VC firewall may cause issues, but working at home):

Username: 	Karl
Password: 	VHl0MLhuWt2kL899
Schema:		post-system

2FA has been implemented using Firebase Authentication OTP

Test Account:

Email: karl.dicks@gmail.com
Password: P@ssword123!
One Time Pin: 123456

*** Please note the front end uses a proxy server so the command has to be:
ng serve --ssl true --ssl-cert "keys\certificate.pem" --ssl-key "keys\privatekey.pem" --proxy-config proxy.conf.json
***

*** Please note the application requires Git: https://git-scm.com/download/win ***

*** Please note the application may require package-lock to be deleted in some environments ***
