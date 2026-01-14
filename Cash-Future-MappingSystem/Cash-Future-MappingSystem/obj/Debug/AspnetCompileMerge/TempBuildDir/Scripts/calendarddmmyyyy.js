$(document).ready(function () {
    var currentdate = new Date().toISOString().slice(0, 10)
    $("input[type=date]").val(currentdate);
    $("input[type=date]").on("change", function () {
        this.setAttribute(
            "data-date",
            //"2022-11-17",
            moment(this.value, "YYYY-MM-DD")
                .format(this.getAttribute("data-date-format"))
        )
    }).trigger("change")
});