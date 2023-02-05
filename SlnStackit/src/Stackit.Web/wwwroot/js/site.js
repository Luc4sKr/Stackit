// DATATABLE
$(document).ready(function () {
    getDataTable("#contact-table");
    getDataTable("#user-table")
});

function getDataTable(id) {
    $(id).DataTable({
        "ordering": true,
        "paging": true,
        "searching": true,
    });
}

// ALERT
$(".close-alert").click(function () {
    $(".alert").hide("hide");
})