﻿var selected_display_id = -1;
var events = [];
var max_event_id = 0;
var today = new Date();
var Data = {};
var dataschedule;
var o_price;
var event_toappend = {};
//use this to initialize the calendar
var init = {
    schedulerLicenseKey: 'CC-Attribution-NonCommercial-NoDerivatives',
    defaultView: 'agendaDay',
    defaultDate: getDate(),
    minTime: '10:00:00',
    maxTime: '23:00:00',
    allDaySlot: false,
    eventStartEditable: true,
    editable: true,
    eventOverlap: false,
    slotDuration: '00:15:00',
    slotEventOverlap: false,
    ignoreTimezone: false,
    selectable: false,
    eventLimit: true, // allow "more" link when too many events
    eventConstraint: {
        start: '10:00', // a start time (10am in this example)
        end: '23:00' // an end time (6pm in this example)
    },

    header: {
        //                left: '',
        left: 'prev,next today',
        center: 'title',
        //                right: ''
        right: 'agendaDay,agendaTwoDay,agendaWeek,month'
    },
    views: {
        agendaTwoDay: {
            type: 'agenda',
            duration: { days: 2 },

            // views that are more than a day will NOT do this behavior by default
            // so, we need to explicitly enable it
            groupByResource: true

            //// uncomment this line to group by day FIRST with resources underneath
            //groupByDateAndResource: true
        }
    },

    //// uncomment this line to hide the all-day slot
    resources: [
        { id: '1', title: 'Hall 1', eventColor: '#00ABDE' },
        { id: '2', title: 'Hall 2', eventColor: '#00C4A8' },
        { id: '3', title: 'Hall 3', eventColor: '#F9EC68' },
        { id: '4', title: 'Hall 4', eventColor: '#FF4181' },
        { id: '5', title: 'Hall 5', eventColor: '#F0B556' }
    ],

    viewRender: function (view, element) {
        //alert(view.intervalStart);
    },

    select: function (start, end, jsEvent, view, resource) {
        console.log(
                'select',
                start.format(),
                end.format(),
                resource ? resource.id : '(no resource)'
        );
    },

    eventClick: function (calEvent, jsEvent, view) {

        console.log(calEvent);
        console.log('Event start: ' + calEvent.start);
        console.log('Event end: ' + calEvent.end);
        console.log('Coordinates: ' + jsEvent.pageX + ',' + jsEvent.pageY);
        console.log('View: ' + view.name);
    },

    dayClick: function (date, jsEvent, view, resource) {

        //选择了电影
        if (selected_display_id != -1) {
            event_toappend.start = date.format() + '+00:00:00';
            //                    alert(event_toappend.start);
            event_toappend.resourceId = resource.id;
            event_toappend.display_id = selected_display_id;
            max_event_id++;
            event_toappend.id = max_event_id;
            event_toappend.title = findNameByDisplayId(selected_display_id);
            var selected_length = findLengthByDisplayId(selected_display_id);
            selected_length = parseInt(selected_length / 15) * 15;
            var end = formatTime(date + selected_length * 60 * 1000 - 8 * 3600 * 1000 + 30 * 60 * 1000);
            event_toappend.end = end;
            //                    console.log(date);
            //                    console.log(end);
            var today_latest = date;
            today_latest = new Date(today_latest - 8 * 3600 * 1000);
            //                    console.log(date);
            today_latest.setHours(23);
            today_latest.setMinutes(0);
            today_latest.setSeconds(0);
            //                    console.log(end);
            //                    console.log(formatTime(today_latest.getTime()));
            if (end > formatTime(today_latest.getTime())) {
                alert('超时');
            }
            else if (isOverlapping(event)) {
                alert('冲突');
            }
            else {
                layer.prompt({
                    formType: 0,
                    value: '',
                    title: '请输入该排片的初始价格'
                }, function (value, index, elem) {
                    event_toappend.original_price = value; //得到value
                    var temp1 = getEvents();
                    $('#calendar').fullCalendar('removeEventSource', events);
                    events = temp1;
                    events.push(event_toappend);
                    event_toappend = {};
                    $('#calendar').fullCalendar('addEventSource', events);
                    layer.close(index);
                });
            }
        }

        console.log(
                'dayClick',
                date.format(),
                resource ? resource.id : '(no resource)'
        );
    }

};

//initialize when web is ready
$(document).ready(function () {

    initCalendar();

});

//refresh the scheduler with current events
function refreshSchedule() {
    var temp = getEvents();
    $('#calendar').fullCalendar('removeEventSource', events);
    events = temp;
    $('#calendar').fullCalendar('addEventSource', events);
}

function initCalendar() {
    Data = eval("(" + document.getElementById("json").value + ")");
    dataschedule = Data.schedule;
    var events = [];
    for (var i in dataschedule) {
        var event = {};
        event.id = i;
        max_event_id = i;
        event.schedule_id = dataschedule[i].SCHEDULE_ID;
        event.resourceId = dataschedule[i].HALL_ID;
        event.display_id = dataschedule[i].DISPLAY_ID;
        event.original_price = dataschedule[i].ORIGINAL_PRICE;
        event.start = formatTime(parseInt(dataschedule[i].START_TIME.substring(6, 19)));
        event.end = formatTime(parseInt(dataschedule[i].END_TIME.substring(6, 19)));
        event.title = findNameByDisplayId(event.display_id);
        events.push(event);
    }
    $('#calendar').fullCalendar(init);
    $('#calendar').fullCalendar('addEventSource', events);
    initMovieList(Data);
    //add trigger to rows in movie list
    $("#movieList tr").click(function () {

        if (selected_display_id == $(this).find("td").html()) {
            $("#movieList tr").css('background-color', '');
            selected_display_id = -1;
        }
        else {
            $("#movieList tr").css('background-color', '');
            $(this).css('background-color', 'yellow');
            selected_display_id = parseInt($(this).find("td").html());
        }
        console.log(selected_display_id);
    });
}

function initMovieList(Data) {
    document.getElementById('movieList').innerHTML = '';
    var data_display = Data.display;
    $("#movieList").append("<tr> <th> 电影标识号 </th> <th> 电影名称 </th> <th> 时长 </th> <th> 语言 </th> <th> 档期结束时间 </th> </tr>");
    for (i in data_display) {
        var trtoappend = document.createElement('tr');
        var name = document.createElement("td"),
                length = document.createElement("td"),
                language = document.createElement("td"),
                expire_date = document.createElement("td"),
                display = document.createElement("td");
        name.innerHTML = data_display[i].Name;
        length.innerHTML = data_display[i].LENGTH;
        language.innerHTML = data_display[i].LANGUAGE;
        expire_date.innerHTML = new Date(parseInt(data_display[i].Expire_date.substring(6, 19)));
        display.innerHTML = data_display[i].DISPLAY_ID;
        trtoappend.appendChild(display);
        trtoappend.appendChild(name);
        trtoappend.appendChild(length);
        trtoappend.appendChild(language);
        trtoappend.appendChild(expire_date);
        document.getElementById('movieList').appendChild(trtoappend);
    }
}

function getEventData(date) {
    var xmlhttp;
    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
        xmlhttp = new XMLHttpRequest();
    }
    else {// code for IE6, IE5
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }
    date = '2016-07-18';
    var requestString = '/schedule_movie/info/' + date;
    xmlhttp.open('GET', requestString, true);
    xmlhttp.send();
    xmlhttp.onreadystatechange = function () {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
            console.log(xmlhttp.responseText);
            Data = xmlhttp.responseText;
        }
    };
}

function sendAddUpdateList() {
    var xmlhttp;
    var postStr;
    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
        xmlhttp = new XMLHttpRequest();
    }
    else {// code for IE6, IE5
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }
    xmlhttp.open('POST', '/schedules/addupdate', true);
    xmlhttp.send('.....');
    xmlhttp.onreadystatechange = function () {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
            document.getElementById("myDiv").innerHTML = xmlhttp.responseText;
        }
    }
}

function sendDeleteList() {
    var xmlhttp;
    if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
        xmlhttp = new XMLHttpRequest();
    }
    else {// code for IE6, IE5
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }
}

function isOverlapping(event) {
    for (i in events) {
        if (events[i].resourceId == event.resourceId) {
            if ((events[i].start > event.start && event[i].start < events.end) || (events[i].end > event.start && events[i].end < event.end)) {
                return true;    //overlapped
            }
        }
    }
    return false;//no overlap
}

function formatTime(timestamp) {
    var date = new Date(timestamp);
    var year = date.getFullYear();
    var month = date.getMonth() + 1;
    var day = date.getDate();
    var hour = date.getHours();
    var minute = date.getMinutes();
    var second = date.getSeconds();
    var datestring = year
            + '-' + (month < 10 ? '0' + month : month)
            + '-' + (day < 10 ? '0' + day : day)
            + 'T' + (hour < 10 ? '0' + hour : hour)
            + ':' + (minute < 10 ? '0' + minute : minute)
            + ':' + (second < 10 ? '0' + second : second)
            + '+00:00:00';
    return datestring;
}

function findLengthByDisplayId(display_id) {
    for (var i in Data.display) {
        if (Data.display[i].DISPLAY_ID == display_id) {
            return Data.display[i].LENGTH;
        }
    }
    return -1;
}

function findNameByDisplayId(display_id) {
    for (var i in Data.display) {
        if (Data.display[i].DISPLAY_ID == display_id) {
            return Data.display[i].Name;
        }
    }
    return "can't find name";
}

function getEvents() {
    var eventsList = $('#calendar').fullCalendar('clientEvents');
    var x = [];
    for (i in eventsList) {
        var temp = {};

        temp.start = formatTime(new Date(eventsList[i].start - 8 * 3600 * 1000).getTime());
        temp.end = formatTime(new Date(eventsList[i].end - 8 * 3600 * 1000).getTime());
        temp.id = eventsList[i].id;
        temp.title = eventsList[i].title;
        temp.resourceId = eventsList[i].resourceId;
        temp.schedule_id = eventsList[i].schedule_id;
        temp.display_id = eventsList[i].display_id;
        x.push(temp);
    }
    return x;
}

function getDate() {
    //获取当前URL
    var local_url = document.location.href;
    //获取日期
    return local_url.substring(local_url.lastIndexOf("/") + 1);
}

function toNextDay() {
    today = new Date(today.getTime() + 24 * 3600 * 1000);

}

function toPreviousDay() {
    today = new Date(today.getTime() - 24 * 3600 * 1000);
}
var load_layer = [];
function submitChange() {
    events = getEvents();
    for (var i in events) {
        //                $("#SCHEDULE_ID").attr("value");
        //                $("#DISPLAY_ID").attr("value", events[i].display_id);
        //                $("#START_TIME").attr("value", events[i].start);
        //                $("#END_TIME").attr("value", events[i].end);
        //                $("#HALL_ID").attr("value", events[i].resourceId);
        //                $("#ORIGINAL_PRICE").attr("value", events[i].original_price);
        //                $("#START_SLOT").attr("value", 1);
        //                $("#END_SLOT").attr("value", 1);
        $.ajax({
            type: 'POST',
            url: '/schedule_movie/addupdate',
            data: {
                DISPLAY_ID: events[i].display_id,
                START_TIME: events[i].start,
                END_TIME: events[i].end,
                HALL_ID: events[i].resourceId,
                ORIGINAL_PRICE: events[i].original_price
            },
            beforeSend: function () {

            },
            success: function () {
                console.log("success");
            }
        });
    }
}
