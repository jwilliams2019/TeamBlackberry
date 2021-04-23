// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function CreateError(a){
    var text = "";
    if (a.num == 1){
        window.alert("Invalid model");
    } else {
        switch (a.num){
            case 0:
                break;
            case 2:
                text += "Ending Date and Time are prior to Starting Date and Time\n";
                continue;
            default:
                window.alert(text);
                break;
        }
        
        window.alert(text);
    }
}
var num = document.getElementById("errorNum");