# Signing integration

This demo sample code shows how simple is to integrate digital signatures directly into your own website or application using the Bulksign platform.

# Technical details 

The demo is written in .NET Core (runs on Windows, Linux and OSX) and consists of a simple page with a form in which the user will enter his name and email address.
This simple page is the requivalent of the web application which will integrate Bulksign.  On postback, the following operations will happen :

- based on the user enter data, a new Bulksign bundle will be created and sent for signature.
- based on the bundle we obtain the url to sign the document.
- the document will be opened for signature directly in the "host" website with the Bulksign signing app running in a iframe.


# How it looks from the user perspective

<img src="demo.gif" alt="Bulksign Integration" style="width: 900px; height:550px"/>


### Running the code

- create a [Bulksign](http://bulksign.com) account
- login, go to Settings\Api Token.
- copy the value of the "Default" token
- edit BulksignIntegration.cs and replace the Token constants with your token value.
- build and run the project 

