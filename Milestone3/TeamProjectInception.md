Vision Statement:


For consumers who need to keep track of a busy schedule, the Online Event Planner is a calendar application that will allow users to input upcoming events and provide additional information related to them as well as display them in an easy to access manner. This application will allow users to save time by keeping track of their events and allowing the user to immediately gain information about the viability of their schedule. Unlike other calendar applications, our product will warn the user about potential conflicts in their schedule.


Needs, Features, E, U, T:
1. Login with multiple access levels
    * Levels:
        * Visitor: No login
        * Account Holder: Has account, can CRUD for own information
        * Admin: Has account, can CRUD for all information
    * Save login information in db
2. Manage events
    * CRUD implementation
    * Event class
3. Display current information
    * Upcoming events
    * Display routes between locations
* Past events
* Events within a time frame (by date)
4. Oustide information
    * Display nutrition information about meals?
    * Display financial information about planned purchases?
5. Share event information through Twitter
    * Twitter API access
    * Message template?



Initial Modeling:
* Event class
* Title
* Date
* Time
* Notes
* Location of event
* Event duration
* Event type
