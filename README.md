# Pomoda (Pocket Movie Database)

A demo app created with .NET Minimal APIs, Razor Components and HTMX _(light-heartedly coined as the **MARCH**-stack)_. 

The project aims for a minimalistic approach to creating a client-server web application. 

The apps front-end is a simple HTML/CSS/JS-file combo, which is hosted by the .NET backend API as static files. 

The front-end is augmented with HTMX, which it uses to call the backend API. The backend responds with HTML fragments, using Razor Components as HTML templates. HTMX dynamically replaces the DOM elements returned from the backend API, 
making the application feel like a SPA (no full page loads/refreshes).

Try the live demo at [pomoda.azurewebsites.net](https://pomoda.azurewebsites.net/).
___

The project folder structure aims to be straight-forward and easy to understand:

``Pomoda/Frontend``\
&emsp;&emsp;``/Components``\
&emsp;&emsp;&emsp;&emsp;Razor components for HTML templating\
&emsp;&emsp;``index.html``\
&emsp;&emsp;&emsp;&emsp;Main page of our application\
&emsp;&emsp;``styles.css``\
&emsp;&emsp;&emsp;&emsp;CSS styles for the front end\
&emsp;&emsp;``scripts.js``\
&emsp;&emsp;&emsp;&emsp;Simple JS for UI effects

``Pomoda/Backend``\
&emsp;&emsp;``/Endpoints``\
&emsp;&emsp;&emsp;&emsp;HTTP endpoints for the front-end to call\
&emsp;&emsp;``/Middleware``\
&emsp;&emsp;&emsp;&emsp;Middleware for processing HTTP traffic\
&emsp;&emsp;``/Services``\
&emsp;&emsp;&emsp;&emsp;Services for fetching data from 3rd party APIs etc.

``Pomoda/Shared``\
&emsp;&emsp;``/Models``\
&emsp;&emsp;&emsp;&emsp;Common data models/DTOs\
&emsp;&emsp;``/Utils``\
&emsp;&emsp;&emsp;&emsp;Common utility methods, helpers etc.
