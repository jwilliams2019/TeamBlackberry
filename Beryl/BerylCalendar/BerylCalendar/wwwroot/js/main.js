// function CreateError(a){
//     var text = "";
//     if (a.num == 1){
//         window.alert("Invalid model");
//     } else {
//         switch (a.num){
//             case 0:
//                 break;
//             case 2:
//                 text += "Ending Date and Time are prior to Starting Date and Time\n";
//                 continue;
//             default:
//                 window.alert(text);
//                 break;
//         }
        
//         window.alert(text);
//     }
// }




var displayColors = false;

$("#eventOptionToggle").click(function () {
    //some borrowed code: https://www.codexworld.com/how-to/toggle-show-hide-element-using-javascript/
    var elem = document.getElementById("displayOptions");
    var button = document.getElementById("eventOptionToggle");
    if(elem.style.display === "none"){
        elem.style.display = "block";
        button.innerText = "Hide";
    }else{
        elem.style.display = "none";
        button.innerText = "Show";
    }
});

$("#displayColorToggle").click(function () {
    if (displayColors === false){
        colorTypes();
        document.getElementById("displayColorToggle").innerText = "Disable Colors";
        displayColors = true;
    } else {
        monoTypes();
        document.getElementById("displayColorToggle").innerText = "Enable Colors";
        displayColors = false;
    }
});

function colorTypes() {
    var events = document.getElementsByClassName("event");
    var types = document.getElementsByClassName("eventType");
    var i;

    for (i = 0; i < events.length; i++){
        switch(types[i].innerText){
            case "Activity":
                events[i].style.borderColor = "red";
                events[i].style.backgroundColor = "#faa"
                break;
            case "Meal":
                events[i].style.borderColor = "yellow";
                events[i].style.backgroundColor = "#ff9"
                break;
            case "Shopping":
                events[i].style.borderColor = "blue";
                events[i].style.backgroundColor = "#aaf"
                break;
            case "Visit":
                events[i].style.borderColor = "green";
                events[i].style.backgroundColor = "#afa"
                break;
        }
    }
}

function monoTypes() {
    var events = document.getElementsByClassName("event");
    var types = document.getElementsByClassName("eventType");
    var i;

    for (i = 0; i < events.length; i++){
        events[i].style.borderColor = "lightgrey";
        events[i].style.backgroundColor = "#fff"
    }
}




$("#ReadAsCommand").click(function () {
    console.log("Luis Language Comprehension Used");
    let address = "/Luis/Interpret";
    var params = { command: document.getElementById("phrase").value };
    console.log(params);
    $.ajax({
        type: "POST",
        dataType: "json",
        url: address,
        data: params,
        success: displayIntent,
        error: LuisAjaxError
    });

});

function displayIntent(data){
    console.log(data);
}

function LuisAjaxError() {
    console.log("Error in Ajax call");
}