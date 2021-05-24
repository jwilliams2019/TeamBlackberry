var baseMonth = new Date();
var numberOfDaysInMonth = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
var isDayUsed = new Array(31);
var model = [];

function setBaseMonth(year, month) {
    baseMonth.setFullYear(year);
    baseMonth.setMonth(month);
    if ((year % 4) == 0) {
        numberOfDaysInMonth[1] = 29;
    }
}

function initializeArray() {
    for (var i = 0; i < 31; i++) {
        isDayUsed[i] = false;
    }
}

function setModel(listOfUsedDates) {
    model = listOfUsedDates;
}

function findUsedDays() {
    initializeArray();
    for (var i = 0; i < model.length; i++) {
        if (model[i].getMonth() == baseMonth.getMonth()) {
            isDayUsed[model[i].getDate() - 1] = true;
        }
    }
}

const monthNames = ["January", "February", "March", "April", "May", "June",
    "July", "August", "September", "October", "November", "December"
];

$("#prev").click(function () {
    setBaseMonth(baseMonth.getFullYear(), baseMonth.getMonth() - 1);
    formatMonth();
});

$("#next").click(function () {
    setBaseMonth(baseMonth.getFullYear(), baseMonth.getMonth() + 1);
    formatMonth();
});

function formatMonth() {
    document.getElementById("monthName").innerText = monthNames[baseMonth.getMonth()];
    document.getElementById("days").textContent = '';
    findUsedDays();

    var firstDayOfMonth = new Date(baseMonth.getFullYear(), baseMonth.getMonth(), 1);
    var firstDayCodeOfMonth = firstDayOfMonth.getDay();
    for (var i = 0; i < 42; i++)
    {
        if ((i >= firstDayCodeOfMonth)
            && (i < (numberOfDaysInMonth[baseMonth.getMonth()] + firstDayCodeOfMonth))) {
            var dayLink = "/Event/Display/" + (i - firstDayCodeOfMonth + 1) + "/" + (firstDayOfMonth.getMonth() + 1) + "/" + (firstDayOfMonth.getFullYear());
            var dayOfMonth = i - firstDayCodeOfMonth + 1;
            var elem = document.createElement("li");
            var linkElem = document.createElement("a");
            linkElem.href = dayLink;
            linkElem.innerText = dayOfMonth;
            elem.appendChild(linkElem);
            if (isDayUsed[dayOfMonth - 1]) {
                elem.classList.add("used");
            }
            document.getElementById("days").appendChild(elem);
        }
        else {
            var elem = document.createElement("li");
            elem.innerText = '';
            document.getElementById("days").appendChild(elem);
        }
    }
}