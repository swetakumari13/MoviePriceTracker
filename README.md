## MoviePriceTracker

### Objective & Implementations

- Build a web app to allow customers to get the cheapest price for movies from these two providers in a timely manner.
    
    - ASP.NET MVC Web application is created to get data from respective APIs.
    - React framework is used to show data on the UI as per the data extracted and analysed.
    - Movies data is shown in ascending order with respect to `price` property.
    
- Design a solution to have a functioning app when not all of the providers are functioning at 100 %.

    - Appropriate exceptions while getting data from API is handled using `try-catch`.
    - If API of getting data for all movies is not working, it is handled by setting empty dataset which is shown with `try-again` message on the UI.
    - If API of getting data for particular movie on the basis of `ID` is not working, it is handled by setting default object with price `-1` which is later filtered out.

- The API token provided to you should not be exposed to the public.

    - This is handled by setting API token on server-side which is not sent from the UI or exposed at any level.
### Assumptions

- Data provided by different movie providers use same data structure. If any provider doesn't provide data in the same structure, then application won't work as expected.

- Request to provided APIs have timeout of 1 minute (60000 ms). After this, appropriate message is shown on the UI.

- Web API exposed by the application provides no authentication or authorization.

- This application is tested on `Chrome (v74) 64-bit` which supports V8 engine. React.NET for MVC is used with this application which is configured to use `JavaScriptEngineSwitcher.V8` as default engine factory.
