# Guidelines

## Langauges:
* C#
* JavaScript (Ajax)
* CSS
* HTML
* SQL

## C#

* Function Setup Example (For non-auto-generated functions)<br>
    *Arbitrary data types* <br>
    ``` 
    int function(int a, int b) {
        // some code here
    } 
    ```
* Function Setup Example (For auto-generated functions) <br>
    *Arbitrary data types* <br>
    ``` 
    int function(int a, int b) 
    {
        // some code here
    } 
    ```

* Like-types can be declared together within a Controller
    ```
    int a, b, c;
    ```
* All variables in a Model are declared separately

## JavaScript (Ajax)

## CSS

* A hierarchy of CSS stylings:
    1. General Tags <br>
        ex: a {//css}, img{//css}, etc.
    2. Class <br>
        ex: .shopping {//css}, .event {//css}, etc.
    3. Id <br>
        ex: #welcome_video_frame {//css}, #register_logo {//css}, etc.

## HTML

## SQL
1. Foreign key names
    * [source_table_FK_foreign_table] <br>
    ex: [Event_FK_Account]
2. Foreign key fields in tables
    * *Table***Field** <br>
    ex: *Account***Id**
3. *ACTION* <br>
    GO <br>
    ex: <br>
    CREATE TABLE {//sql}<br>
    GO