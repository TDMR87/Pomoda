# Pomoda (Pocket Movie Database)

A demo app created with .NET Minimal APIs, Razor Components and HTMX _(light-heartedly coined as the **MARCH**-stack)_.

Try the live demo at [pomoda.azurewebsites.net](https://pomoda.azurewebsites.net/)	

The project aims for a minimalistic and light-weight approach to creating a web application. We have a simple HTML/CSS/HTMX front-end which is hosted & served by 
the backend API as static files. The front-end calls the backend API endpoints via HTMX. 
The backend responds with HTML, which is generated using Razor Components. 
HTMX at the front-end then dynamically replaces the necessary DOM elements returned from the backend API, 
making the application act like a single-page-application.
___

The project folder sctructure aims to be straight-forward and easy to understand:

``Pomoda/Frontend``\
&emsp;&emsp;``Pomoda/Frontend/index.html``\
&emsp;&emsp;&emsp;&emsp;``- This is the main page of our application``\
&emsp;&emsp;``Pomoda/Frontend/styles.css``\
&emsp;&emsp;&emsp;&emsp;``- Contains CSS styles for our main page``\
&emsp;&emsp;``Pomoda/Frontend/Components``\
&emsp;&emsp;&emsp;&emsp;``- Razor components for HTML/HTMX templating``

``Pomoda/Backend``\
&emsp;&emsp;``Pomoda/Backend/Endpoints``\
&emsp;&emsp;&emsp;&emsp;``- Front-end htmx calls these HTTP endpoints``\
&emsp;&emsp;``Pomoda/Backend/Middleware``\
&emsp;&emsp;&emsp;&emsp;``- Middleware for processing HTTP traffic in the backend``\
&emsp;&emsp;``Pomoda/Backend/Services``\
&emsp;&emsp;&emsp;&emsp;``- Services for fetching data from 3rd party APIs or databases``

``Pomoda/Shared``\
&emsp;&emsp;``Pomoda/Shared/Models``\
&emsp;&emsp;&emsp;&emsp;``- Shared data model objects for serialization/deserialization``\
&emsp;&emsp;``Pomoda/Shared/Utils``\
&emsp;&emsp;&emsp;&emsp;``- Common utility methods, extension methods etc.``
