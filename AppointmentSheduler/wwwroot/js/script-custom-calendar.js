var routeUrl = location.protocol + "//" + location.host;
$(document).ready(function () {
    $("#startDate").kendoDateTimePicker({
        value: new Date(),
        dateInput: true
    });
    initCalender();
});


function initCalender() {
    var calendarEl = document.getElementById('calendar');
    var calendar = new FullCalendar.Calendar(calendarEl, {
        initialView: 'dayGridMonth',
        headerToolbar: {
            left: 'prev,next,today',
            center: "title",
            right: "dayGridMonth,timeGridWeek,timeGridDay"

        },
        selectable: true,
        editable: false,
        select: function (event) {
            onShowModal(event, null);
        }

    });
    calendar.render();
}

   


function onShowModal(obj, isEventDetail) {
    $("#appointmentInput").modal("show");
    
}

function onCloseModal() {
    $("#appointmentInput").modal("hide");
}

function onSubmitForm() {
    var resultData =
    {
        Id: parseInt($("#id").val()),
        Title: $("#title").val(),
        Description: $("#description").val(),
        StartDate: $("#startDate").val(),
        Duration: $("#duration").val(),
        DoctorId: $("#doctorId").val(),
        Patient: $("#patientId").val()
    }
    $.ajax({
        url: routeUrl + "/api/Appointment/Index",
        type: "POST",
        data: JSON.stringify(resultData),
        contentType: "application/json",
        success: function (response) {
            if (response.status === 1) {
                console.log("success");
            }
            else {
                console.log("Error");
            }
        },
        error: function (xhr) {
            console.log("Error");
        }
    });
}